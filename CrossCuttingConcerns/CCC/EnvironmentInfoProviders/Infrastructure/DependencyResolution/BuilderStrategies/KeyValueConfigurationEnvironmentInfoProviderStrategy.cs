using EnvironmentInfoProviders.Contracts;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace EnvironmentInfoProviders.Infrastructure.DependencyResolution.BuilderStrategies
{
    /// <summary>
    /// <c>BuilderStrategy</c> for <c>UnityContainer</c> that enables it to
    /// resolve <c>IEnvironmentInfoProvider</c> implementation by means of <c>IEnvironmentInfoProviderFactory</c>
    /// </summary>
    class KeyValueConfigurationEnvironmentInfoProviderStrategy : BuilderStrategy
    {
        /// <summary>
        /// <c>UnityContainer</c> extension context.
        /// </summary>
        readonly ExtensionContext _baseContext;

        /// <summary>
        /// Constructs <c>KeyValueConfigurationEnvironmentInfoProviderStrategy</c> based on <c>KeyValueConfigurationCollection</c> from AppSettings.
        /// </summary>
        /// <param name="baseContext"><c>UnityContainer</c> extension context.</param>
        public KeyValueConfigurationEnvironmentInfoProviderStrategy(ExtensionContext baseContext)
        {
            _baseContext = baseContext;
        }

        /// <summary>
        /// Handles Container's <c>PreBuildUp</c> stage.
        /// </summary>
        /// <param name="context">Context, depepndency resolution is requested in.</param>
        public override void PreBuildUp(IBuilderContext context)
        {
            //Getting type which UnityContainer was asked to resolve
            var typeToResolve = context.OriginalBuildKey.Type;

            //This build strategy is used for IEnvironmentInfoProvider derived interfaces only
            if (!typeToResolve.IsInterface || !typeof (IEnvironmentInfoProvider).IsAssignableFrom(typeToResolve))
                return;

            //If concrete implementation of IEnvironmentInfoProvider is already registered - returning it.
            if (_baseContext.Container.IsRegistered(typeToResolve))
            {
                context.Existing = _baseContext.Container.Resolve(typeToResolve);
                return;
            }

            //Resolving EnvironmentInfoProviderFactory for this BuilderStrategy
            var envInfoProviderFactory = _baseContext.Container.Resolve<IEnvironmentInfoProviderFactory>();

            //Extracting method name to call 
            Expression<Func<IEnvironmentInfoProvider>> factoryGetExpression = () => envInfoProviderFactory.Get<IEnvironmentInfoProvider>();
            var factoryCallGetExpression = factoryGetExpression.Body as MethodCallExpression;
            string factoryGetMethodName = factoryCallGetExpression.Method.Name;

            //Getting IEnvironmentInfoProvider Mock implementation, constructed by EnvironmentInfoProviderFactory
            context.Existing = typeof(IEnvironmentInfoProviderFactory).
                GetMethod(factoryGetMethodName, BindingFlags.Instance | BindingFlags.Public).
                MakeGenericMethod(typeToResolve).
                Invoke(envInfoProviderFactory, null);

            //Registering constructed IEnvironmentInfoProvider implementation within Container
            _baseContext.Container.RegisterInstance(typeToResolve, context.Existing);
        }
    }
}
