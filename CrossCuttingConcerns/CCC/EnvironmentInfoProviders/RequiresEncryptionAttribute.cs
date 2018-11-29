using System;

namespace EnvironmentInfoProviders
{
	[AttributeUsage(AttributeTargets.Property)]
	public class RequiresEncryptionAttribute : Attribute
	{
		//used to mark property as secured
	}
}