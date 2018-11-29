using EnvironmentInfoProviders.Infrastructure.DependencyResolution.BuilderStrategies;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;
using System;
using System.Configuration;
using EnvironmentInfoProviders.Contracts;

namespace EnvironmentInfoProviders.Infrastructure.DependencyResolution 
{
    /// <summary>
    /// <c>UnityContainerExtension</c> for <c>UnityContainer</c> that enables it to
    /// resolve <c>IEnvironmentInfoProvider</c> implementation by means of <c>IAssemblyBoundAppConfigEIPFactory</c>.
    /// Registers <c>IEnvironmentInfoProviderFactory</c> implementation and adds corresponding <c>AssemblyBoundAppConfigEnvironmentInfoProviderStrategy</c>
    /// to Unity Context Strategies.
    /// </summary>
    public class AssemblyBoundAppConfigEnvironmentInfoProviderExtension : UnityContainerExtension 
    {
        /// <summary>
        /// Allows to override way of how AppSettings is retrieved.
        /// </summary>
        public Func<KeyValueConfigurationCollection> DefaultKeyValueCollection { get; set; }

        /// <summary>
        /// Registers <c>IAssemblyBoundAppConfigEIPFactory</c> implementation and adds <c>AssemblyBoundAppConfigEnvironmentInfoProviderStrategy</c>
        /// to Unity Context strategies.
        /// </summary>
        protected override void Initialize()
        {
			Container.RegisterType<IAssemblyBoundAppConfigEIPFactory, AssemblyBoundAppConfigEIPFactory>();
            Context.Strategies.Add(new AssemblyBoundAppConfigEnvironmentInfoProviderStrategy(Context, DefaultKeyValueCollection), UnityBuildStage.PreCreation);
        }
    }
}
