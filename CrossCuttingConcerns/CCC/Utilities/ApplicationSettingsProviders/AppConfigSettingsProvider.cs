using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;
using Utilities.Extensions;

namespace Utilities.ApplicationSettingsProviders
{
    /// <summary>
    /// <c>SettingsProvider</c> implementation for getting strongly typed application settings from App.config it's <c>Settings</c> defined for.
    /// Overrides standard behavior of <c>LocalFileSettingsProvider</c> be reading settings from *.dll.config.
    /// Use specifically for cases, where <c>Settings</c> are defined in child assembly.
    /// </summary>
    /// <example>
    /// <c>AppConfigSettingsProvider</c> association with specific <c>Settings</c>:
    /// <code>
    /// [SettingsProvider(typeof(AppConfigSettingsProvider))]
    /// internal sealed partial class Settings { ... }
    /// </code>
    /// </example>
    public sealed class AppConfigSettingsProvider : SettingsProvider, IApplicationSettingsProvider
    {
        /// <summary>
        /// App.config section group name for application settings.
        /// </summary>
        const string ApplicationSettingsGroupName = "applicationSettings";

        /// <summary>
        /// App.config section group name for user settings.
        /// </summary>
        const string UserSettingsGroupName = "userSettings";

        /// <summary>
        /// <c>SettingsContext</c> 'GorupName' key that is used to retrieve current <c>Settings</c> specific App.config section.
        /// </summary>
        const string SettingsGroupNameContextKey = "GroupName";

        /// <summary>
        /// <c>SettingsContext</c> 'SettingsClassType' key that is used to retrieve current <c>Settings</c> type.
        /// </summary>
        const string SettingsClassTypeContextKey = "SettingsClassType";

        /// <summary>
        /// Default setting values to initialize current settings provider and nested ones.
        /// </summary>
        readonly NameValueCollection _settingValues = new NameValueCollection();

        /// <summary>
        /// Initializes current instance of <c>AppConfigSettingsProvider</c> class.
        /// </summary>
        /// <param name="name">The name of the provider.</param>
        /// <param name="config">The values for initialization.</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(ApplicationName, _settingValues);
        }

        /// <summary>
        /// Name of the application containing <c>Settings</c> this provider is associated with.
        /// </summary>
        public override string ApplicationName
        {
            get { return Assembly.GetExecutingAssembly().GetName().Name; }
            set { }
        }

        /// <summary>
        /// Returns the collection of setting property values for the specified application instance and settings property group.
        /// </summary>
        /// <param name="context">A <c>System.Configuration.SettingsContext</c> that describes where the application settings property is used.</param>
        /// <param name="properties">A <c>System.Configuration.SettingsPropertyCollection</c> containing the settings property group whose values are to be retrieved.</param>
        /// <returns>A <c>System.Configuration.SettingsPropertyValueCollection</c> containing the values for the specified settings property group.</returns>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">A user-scoped setting was encountered but the current configuration only supports application-scoped settings.</exception>
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection properties)
        {
            var settingPropertyValues = new SettingsPropertyValueCollection();

            string settingsGroupName = Convert.ToString(context[SettingsGroupNameContextKey]);
            string connectionStringPrefix = settingsGroupName + Type.Delimiter;

            var appConfiguration = ConfigurationManager.OpenExeConfiguration(context[SettingsClassTypeContextKey].As<Type>().Assembly.Location);
            var userConfigurationLocal = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            var userConfigurationRoaming = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);

            var settingsProperties = properties.Cast<SettingsProperty>();
            var appSettingsProperties = settingsProperties.Where(prop => prop.Attributes.Contains(typeof(ApplicationScopedSettingAttribute))).ToList();
            var userSettingsProperties = settingsProperties.Where(prop => prop.Attributes.Contains(typeof(UserScopedSettingAttribute))).ToList();

            var userSettingsPropertiesLocal = userSettingsProperties.Where(prop => !prop.Attributes.Contains(typeof(SettingsManageabilityAttribute)));
            var userSettingsPropertiesRoaming = userSettingsProperties.Where(prop => prop.Attributes.Contains(typeof(SettingsManageabilityAttribute)));

            //Getting userSettings for 'Local' configuration:
            ApplyUserSettingsValuesToConfigurationElements(
                context,
                userConfigurationLocal,
                appConfiguration,
                settingPropertyValues,
                userSettingsPropertiesLocal);

            //Getting userSettings for 'Roaming' configuration:
            ApplyUserSettingsValuesToConfigurationElements(
                context,
                userConfigurationRoaming,
                appConfiguration,
                settingPropertyValues,
                userSettingsPropertiesRoaming);

            //Getting connectionStrings form 'appConfiguration':
            var connectionStrings = appConfiguration.ConnectionStrings.ConnectionStrings.OfType<ConnectionStringSettings>();
            ApplySettingsValuesToConfigurationElements(
                settingPropertyValues,
                connectionStrings,
                appSettingsProperties,
                (prop, configurationElement) => prop.Name == configurationElement.Name.Replace(connectionStringPrefix, string.Empty));

            //Getting application settings:
            appConfiguration.
                With(configuration => configuration.SectionGroups[ApplicationSettingsGroupName]).
                With(sectionGroup => sectionGroup.Sections[settingsGroupName].As<ClientSettingsSection>()).
                With(section => section.Settings.Cast<SettingElement>()).
                Do(applicationSettings =>
                    ApplySettingsValuesToConfigurationElements(
                        settingPropertyValues,
                        applicationSettings,
                        appSettingsProperties,
                        (prop, configurationElement) => prop.Name == configurationElement.Name));

            //Adding properties that were not set (just use default values):
            var propertiesAreSet = settingPropertyValues.Cast<SettingsPropertyValue>().Select(propValue => propValue.Name);
            var settingsAreNotSet = settingsProperties.Where(settingProperty => !propertiesAreSet.Contains(settingProperty.Name));
            settingsAreNotSet.
                ToList().
                ForEach(setting => settingPropertyValues.Add(new SettingsPropertyValue(setting)));

            return settingPropertyValues;
        }

        /// <summary>
        /// Applies user settings values to settings properties.
        /// </summary>
        /// <param name="context">A <c>System.Configuration.SettingsContext</c> that describes where the application settings property is used.</param>
        /// <param name="userConfiguration">User configuration to retrieve settings from.</param>
        /// <param name="appConfiguration">Fallback application configuration to retrieve settings from once User configuration file not found.</param>
        /// <param name="settingPropertyValues">Collection of <c>Settings</c> associated with thier values.</param>
        /// <param name="userSettingsProperties"><c>Settings</c> user scoped properties, that needs to be initialized.</param>
        void ApplyUserSettingsValuesToConfigurationElements(
            SettingsContext context,
            Configuration userConfiguration,
            Configuration appConfiguration,
            SettingsPropertyValueCollection settingPropertyValues,
            IEnumerable<SettingsProperty> userSettingsProperties)
        {
            string settingsGroupName = Convert.ToString(context[SettingsGroupNameContextKey]);

            var initializedSettings = new List<SettingsProperty>();

            //Once corresponding 'user.config' file exists - use default settings provider to initialize user settings:
            if (userConfiguration.HasFile)
            {
                var settingsActuallySet = XDocument.
                        Load(userConfiguration.FilePath).
                        XPathSelectElements(string.Format("/configuration/{0}/{1}/setting", UserSettingsGroupName, settingsGroupName)).
                        Select(settingElement => settingElement.Attribute("name").Value).
                        ToList();

                var userConfigDeclaredSettings = userSettingsProperties.
                    Where(setting => settingsActuallySet.Contains(setting.Name)).
                    ToList();

                var userPropertySettingsCollection = new SettingsPropertyCollection();
                userConfigDeclaredSettings.ForEach(userPropertySettingsCollection.Add);

                var defaultProvider = new LocalFileSettingsProvider();
                defaultProvider.Initialize(ApplicationName, _settingValues);
                var userPropertyValues = defaultProvider.GetPropertyValues(context, userPropertySettingsCollection);

                userPropertyValues.Cast<SettingsPropertyValue>().
                    ToList().
                    ForEach(settingPropertyValues.Add);

                initializedSettings.AddRange(userConfigDeclaredSettings);
            }
            //Reading defaults from application configuration:
            appConfiguration.
                With(configuration => configuration.SectionGroups[UserSettingsGroupName]).
                With(sectionGroup => sectionGroup.Sections[settingsGroupName].As<ClientSettingsSection>()).
                With(section => section.Settings.Cast<SettingElement>()).
                Do(userSettings =>
                    ApplySettingsValuesToConfigurationElements(
                        settingPropertyValues,
                        userSettings,
                        userSettingsProperties.Except(initializedSettings),
                        (prop, configurationElement) => prop.Name == configurationElement.Name));
        }

        /// <summary>
        /// Applies application settings values to settings properties.
        /// </summary>
        /// <typeparam name="T">Type of configuration settings, read from underlying store.</typeparam>
        /// <param name="settingPropertyValues">Collection of <c>Settings</c> associated with thier values.</param>
        /// <param name="configurationSettings">Configuration settings, read from underlying store.</param>
        /// <param name="settingsProperties"><c>Settings</c> properties, that needs to be initialized.</param>
        /// <param name="propertySettingNameMatcher">Predicate that is used to map settings properties to settings values.</param>
        static void ApplySettingsValuesToConfigurationElements<T>(
            SettingsPropertyValueCollection settingPropertyValues,
            IEnumerable<T> configurationSettings,
            IEnumerable<SettingsProperty> settingsProperties,
            Func<SettingsProperty, T, bool> propertySettingNameMatcher)
            where T : ConfigurationElement
        {
            foreach (var configurationSetting in configurationSettings)
            {
                var matchedSettingsProperty = settingsProperties.SingleOrDefault(prop => propertySettingNameMatcher(prop, configurationSetting));

                if (matchedSettingsProperty == null) continue;

                var applicationSettingValue = new SettingsPropertyValue(matchedSettingsProperty);

                configurationSetting.
                    If(e => e.Is<ConnectionStringSettings>()).
                    As<ConnectionStringSettings>().
                    Do(e => applicationSettingValue.PropertyValue = e.ConnectionString);

                configurationSetting.
                    If(e => e.Is<SettingElement>()).
                    As<SettingElement>().
                    Do(e => applicationSettingValue.SerializedValue = e.Value.ValueXml.InnerText);

                settingPropertyValues.Add(applicationSettingValue);
            }
        }

        /// <summary>
        /// Sets the values of the specified group of property settings.
        /// </summary>
        /// <param name="context">A <c>System.Configuration.SettingsContext</c> that describes where the application settings property is used.</param>
        /// <param name="values">A <c>System.Configuration.SettingsPropertyValueCollection</c> representing the group of property settings to set.</param>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">
        /// A user-scoped setting was encountered but the current configuration only supports application-scoped settings.
        /// -or-
        /// There was a general failure saving the settings to the configuration file.</exception>
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection values)
        {
            //Only user scope settings could be saved, so delegating this process to standard LocalFileSettingsProvider:
            var defaultProvider = new LocalFileSettingsProvider();
            defaultProvider.Initialize(ApplicationName, _settingValues);
            defaultProvider.SetPropertyValues(context, values);
        }

        /// <summary>
        /// Returns the value of the named settings property for the previous version of the same application.
        /// </summary>
        /// <param name="context">A <c>System.Configuration.SettingsContext</c> that describes where the application settings property is used.</param>
        /// <param name="property">The <c>System.Configuration.SettingsProperty</c> whose value is to be returned.</param>
        /// <returns>A <c>System.Configuration.SettingsPropertyValue</c> representing the application setting if found; otherwise, <c>null</c>.</returns>
        public SettingsPropertyValue GetPreviousVersion(SettingsContext context, SettingsProperty property)
        {
            throw new NotSupportedException("Get Previous Version is not supported");
        }

        /// <summary>
        /// Resets all application settings properties associated with the specified application to their default values.
        /// </summary>
        /// <param name="context">A <c>System.Configuration.SettingsContext</c> that describes where the application settings property is used.</param>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">A user-scoped setting was encountered but the current configuration only supports application-scoped settings.</exception>
        public void Reset(SettingsContext context) { }

        /// <summary>
        /// Attempts to migrate previous user-scoped settings from a previous version of the same application.
        /// </summary>
        /// <param name="context">A <c>System.Configuration.SettingsContext</c> that describes where the application settings property is used.</param>
        /// <param name="properties">A <c>System.Configuration.SettingsPropertyCollection</c> containing the settings property group whose values are to be retrieved.</param>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">
        /// A user-scoped setting was encountered but the current configuration only supports application-scoped settings.
        /// -or-
        /// The previous version of the configuration file could not be accessed.
        /// </exception>
        public void Upgrade(SettingsContext context, SettingsPropertyCollection properties) { }
    }
}
