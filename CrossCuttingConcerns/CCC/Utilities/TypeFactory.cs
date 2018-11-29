using System;
using Microsoft.Practices.Unity;

namespace Utilities
{
    /// <summary>
    /// Project wide Type Factory (IoC based)
    /// Simply a "service locator" (anti)pattern
    /// </summary>
    public static class TypeFactory
    {
        /// <summary>
        /// Static initialization of <c>TypeFactory</c>.
        /// </summary>
        static TypeFactory()
        {
            Container = new UnityContainer();
        }

        /// <summary>
        /// Container is open for client registrations
        /// </summary>
        static IUnityContainer Container { get; set; }

        /// <summary>
        /// Applies <c>UnityContainerExtension</c> to inner <c>IUnityContainer</c>.
        /// </summary>
        /// <param name="extension">Container extension to apply.</param>
        public static void ApplyContainerExtension(UnityContainerExtension extension) 
        {
            Container.AddExtension(extension);
        }

        /// <summary>
        /// Register instance within Container by mapping it to specific type.
        /// </summary>
        /// <param name="t">Type to map from.</param>
        /// <param name="instance">Instance to map to.</param>
        public static void RegisterInstance(Type t, object instance)
        {
            Container.RegisterInstance(t, instance);
        }

        /// <summary>
        /// Register instance within Container by mapping it to specific type.
        /// </summary>
        /// <typeparam name="TFrom">Type to map from.</typeparam>
        /// <param name="instance">Instance to map to.</param>
        public static void RegisterInstance<TFrom>(TFrom instance)
        {
            Container.RegisterInstance<TFrom>(instance);
        }

        /// <summary>
        /// Register type within Container by mapping it to specific type.
        /// </summary>
        /// <param name="from">Type to map from.</param>
        /// <param name="to">Type to map to.</param>
        /// <param name="injectionMembers">Dependency resolution overrides and specifications.</param>
        public static void RegisterType(Type from, Type to, params InjectionMember[] injectionMembers)
        {
            Container.RegisterType(from, to, injectionMembers);
        }

        /// <summary>
        /// Register type within Container by mapping it to specific type.
        /// </summary>
        /// <typeparam name="TFrom">Type to map from.</typeparam>
        /// <typeparam name="TTo">Type to map to</typeparam>
        /// <param name="injectionMembers">Dependency resolution overrides and specifications.</param>
        public static void RegisterType<TFrom, TTo>(params InjectionMember[] injectionMembers) where TTo : TFrom
        {
            Container.RegisterType<TFrom, TTo>(injectionMembers);
        }

        /// <summary>
        /// Resolve dependency.
        /// </summary>
        /// <typeparam name="T">Dependency type to resolve.</typeparam>
        /// <returns>Returns resolved type instance.</returns>
        public static T Get<T>()
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Resolve dependency.
        /// </summary>
        /// <param name="t">Dependency type to resolve.</param>
        /// <returns>Returns resolved type instance.</returns>
        public static object Get(Type t)
        {
            return Container.Resolve(t);
        }
    }
}