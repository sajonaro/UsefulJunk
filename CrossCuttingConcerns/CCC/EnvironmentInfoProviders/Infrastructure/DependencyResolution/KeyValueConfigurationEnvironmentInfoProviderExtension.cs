using EnvironmentInfoProviders.Contracts;
using EnvironmentInfoProviders.Infrastructure.DependencyResolution.BuilderStrategies;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;
using System.Configuration;

namespace EnvironmentInfoProviders.Infrastructure.DependencyResolution
{
    /// <summary>
    /// <c>UnityContainerExtension</c> for <c>UnityContainer</c> that enables it to
    /// resolve <c>IEnvironmentInfoProvider</c> implementation by means of <c>IEnvironmentInfoProviderFactory</c>.
    /// Registers <c>IEnvironmentInfoProviderFactory</c> implementation and adds corresponding <c>AssemblyBoundAppConfigEnvironmentInfoProviderStrategy</c>
    /// to Context Strategies.
    /// </summary>
    public class KeyValueConfigurationEnvironmentInfoProviderExtension : UnityContainerExtension
    {
        /// <summary>
        /// AppSettings to be passed to <c>IEnvironmentInfoProviderFactory</c>
        /// </summary>
        readonly KeyValueConfigurationCollection _configurationCollection;

        /// <summary>
        /// Constructs <c>KeyValueConfigurationEnvironmentInfoProviderExtension</c> based on <c>KeyValueConfigurationCollection</c> from AppSettings.
        /// </summary>
        /// <param name="configurationCollection">Configuration AppSettings to build <c>IEnvironmentInfoProvider</c> implementations from</param>
        public KeyValueConfigurationEnvironmentInfoProviderExtension(KeyValueConfigurationCollection configurationCollection)
        {
            _configurationCollection = configurationCollection;
        }

        /// <summary>
        /// Registers <c>IEnvironmentInfoProviderFactory</c> implementation and adds <c>KeyValueConfigurationEnvironmentInfoProviderStrategy</c>
        /// to Unity Context strategies.
        /// </summary>
        protected override void Initialize()
        {
            Container.RegisterType<IEnvironmentInfoProviderFactory, EnvironmentInfoProviderFactory>(new InjectionConstructor(_configurationCollection));
            Context.Strategies.Add(new KeyValueConfigurationEnvironmentInfoProviderStrategy(Context), UnityBuildStage.PreCreation);
        }
    }
}
