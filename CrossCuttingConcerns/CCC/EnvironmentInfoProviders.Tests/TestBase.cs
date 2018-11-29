using System;
using System.Configuration;
using System.Linq;
using EnvironmentInfoProviders.Contracts;
using NUnit.Framework;
using Utilities;
using Utilities.Cryptography;

namespace EnvironmentInfoProviders.Tests
{
	/// <summary>
	/// Holds some common methods
	/// </summary>
	public abstract class TestBase
	{
		protected KeyValueConfigurationCollection ExpectedConfigurationCollection;

		protected void AssertAllProvidersAreCorrectlyFilled<T>( T factory = null)
			where T : class, IEnvironmentInfoProviderFactory
		{
			AssertProviderReturnsAllProperties<ICFWebApiMethodPathsProvider, T>( factory, ExpectedConfigurationCollection );
			AssertProviderReturnsAllProperties<IQvalWebApiMethodPathProvider, T>( factory, ExpectedConfigurationCollection );

			//test encrypted properties 
			AssertProviderReturnsSecuredProperties<ISmtpSettingsProvider, T>( factory, ExpectedConfigurationCollection );
			AssertProviderReturnsSecuredProperties<ILdapInfoProvider, T>( factory, ExpectedConfigurationCollection );
			AssertProviderReturnsSecuredProperties<ISupportInfoProvider, T>( factory, ExpectedConfigurationCollection );
			AssertProviderReturnsSecuredProperties<IDatabaseInfoProvider, T>( factory, ExpectedConfigurationCollection );
			AssertProviderReturnsSecuredProperties<ICfEnvironmentInfoProvider, T>( factory, ExpectedConfigurationCollection );
		}



		private static void AssertProviderReturnsAllProperties<T,TF>( TF factory, KeyValueConfigurationCollection settingsCollection )
			where T : class, IEnvironmentInfoProvider 
			where TF: class,IEnvironmentInfoProviderFactory
		{

			var provider = factory==null?TypeFactory.Get<T>():factory.Get<T>();

			foreach ( var propertyInfo in provider.GetType().GetProperties() )
			{
				if ( propertyInfo.Name.Contains( "Mock" ) )
					continue;
				if ( propertyInfo.PropertyType.IsArray )
				{
					var expected = settingsCollection[propertyInfo.Name].Value.Split( ';' );
					var actual = propertyInfo.GetValue( provider, null );

					//assert
					CollectionAssert.AreEqual( expected, (string[])actual );
				}
				else
				{
					var expected = settingsCollection[propertyInfo.Name].Value;
					var actual = propertyInfo.GetValue( provider, null );

					//assert
					Assert.AreEqual( expected, actual );
				}

			}
		}

	
		private static void AssertProviderReturnsSecuredProperties<T,TF>( TF factory, KeyValueConfigurationCollection settingsCollection )
			where T : class, IEnvironmentInfoProvider
			where TF :class, IEnvironmentInfoProviderFactory
		{
			var provider = factory == null ? TypeFactory.Get<T>() : factory.Get<T>();

			//only consider secured properties
			var collection = typeof (T).GetProperties().Where(e => Attribute.IsDefined(e, typeof (RequiresEncryptionAttribute))).ToList();

			//check scalar values
			foreach (var propertyInfo in collection.Where(e => !e.PropertyType.IsArray).ToList())
			{

				var expected = TypeFactory.Get<IEncryptorDecryptor>()
						.Decrypt( settingsCollection[propertyInfo.Name].Value );

				var actual = propertyInfo.GetValue( provider, null );

				//assert
				Assert.AreEqual( expected, actual );
			}


			//check vector values
			foreach (var propertyInfo in collection.Where(e => e.PropertyType.IsArray).ToList())
			{

				var expected = TypeFactory.Get<IEncryptorDecryptor>()
						.Decrypt(settingsCollection[propertyInfo.Name].Value)
						.Split(';');
				var actual = propertyInfo.GetValue(provider, null);

				//assert
				CollectionAssert.AreEqual(expected, (string[])actual);
			}

			
		}

	}
}
