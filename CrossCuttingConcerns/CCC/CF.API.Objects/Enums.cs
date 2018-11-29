using System;

namespace CF.API.Objects
{

    public interface IAttribute<T>
    {
        T Value { get; }
    }

    public sealed class AccountRootPathAttribute : System.Attribute, IAttribute<string>
    {
        private readonly string value;

        public AccountRootPathAttribute(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return this.value; }
        }
    }


}
