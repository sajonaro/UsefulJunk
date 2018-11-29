using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using EnvironmentInfoProviders.Contracts;
using Moq;
using Utilities.Cryptography;

namespace EnvironmentInfoProviders
{
    /// <summary>
    ///(default) application settings based implementation of IInfrastructureInfoProviderFactory
    /// </summary>
    public sealed class EnvironmentInfoProviderFactory : IEnvironmentInfoProviderFactory
    {
        /// <summary>
        /// Using for caching configProviders that already used during runtime.
        /// </summary>
        private readonly IDictionary<Type, IEnvironmentInfoProvider> _cache = new Dictionary<Type, IEnvironmentInfoProvider>();

        /// <summary>
        /// Application settings read from appSettings section
        /// </summary>
        private static KeyValueConfigurationCollection _configurationCollection;

	    private static readonly IEncryptorDecryptor EncryptorDecryptor = new EncryptorDecryptor();

        /// <summary>
        /// ConfigurationCollection is supplied
        /// </summary>
        public EnvironmentInfoProviderFactory(KeyValueConfigurationCollection configurationCollection)
        {
            _configurationCollection = configurationCollection;
        }

        /// <summary>
        /// Generates IEnvironmentInfoProvider based on the key value collection 
        /// </summary>
        public T Get<T>() where T : class, IEnvironmentInfoProvider
        {
            IEnvironmentInfoProvider value;
            if (_cache.TryGetValue(typeof(T), out value))
            {
                return (T)value;
            }

            var mock = CreateReflectionBasedMock<T>(_configurationCollection);
            _cache.Add(typeof(T), mock);

            return mock;
        }

        private static T CreateReflectionBasedMock<T>(KeyValueConfigurationCollection settingsCollection) where T : class, IEnvironmentInfoProvider
        {
            var mock = new Mock<T>();
            var properties = typeof (T).GetProperties();

            foreach (var keyName in settingsCollection.AllKeys)
            {
                var propertyInfo = properties.FirstOrDefault(e => string.Compare(e.Name,keyName, StringComparison.CurrentCultureIgnoreCase)==0);
                if (propertyInfo == null)
                    continue;

				//decrypt encrypted values
	            string valueFromAppConfig = ReadAndDecryptValue(propertyInfo, settingsCollection[keyName].Value);

                if (propertyInfo.PropertyType.IsArray)
                {
                    var getter = GetPropGetterExpression<T, string[]>(propertyInfo);
					mock.SetupGet( getter ).Returns( valueFromAppConfig.Split( ';' ) );
                }
                else
                {
                    var getter = GetPropGetterExpression<T, string>(propertyInfo);
					mock.SetupGet( getter ).Returns( valueFromAppConfig );
                }
            }
         
            return mock.Object;
        }

		/// <summary>
		/// if property is marked as [RequiresEncryption] - return decrypted value
		/// or shout if something is wrong
		/// </summary>
		private static string ReadAndDecryptValue(MemberInfo propertyInfo,  string valueToDecrypt)
		{
			try
			{
			    //decrypt if property is marked with [RequiresEncryption] 
				if ( Attribute.IsDefined( propertyInfo, typeof( RequiresEncryptionAttribute)))
					return  EncryptorDecryptor.Decrypt(valueToDecrypt);
				
				//no decryption was required
				return valueToDecrypt;
			}
			catch (Exception ce )
			{
				throw new ApplicationException(string.Format("{0} [{1}] {2} {3} {4}",

					"Most probably, property ", propertyInfo.Name, " was marked as [RequiresEncryption] was supplied in plain form.. see details below ",
					Environment.NewLine,ce.Message));
			}
	    }


        /// <summary>
        /// returns property getter expression
        /// </summary>
        private static Expression<Func<TObject, TValue>> GetPropGetterExpression<TObject, TValue>(PropertyInfo propertyInfo)
        {
            if (typeof(TObject) != propertyInfo.DeclaringType)
            {
                throw new ArgumentException();
            }

            var paramExpression = Expression.Parameter(typeof(TObject), "value");
            var propertyGetterExpression = Expression.Property(paramExpression, propertyInfo);
            return Expression.Lambda<Func<TObject, TValue>>(propertyGetterExpression, paramExpression);
        }
    }
}