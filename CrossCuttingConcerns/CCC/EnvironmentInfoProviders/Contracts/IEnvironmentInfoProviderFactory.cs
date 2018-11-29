namespace EnvironmentInfoProviders.Contracts
{
    public interface IEnvironmentInfoProviderFactory
    {
       T Get<T>() where T: class, IEnvironmentInfoProvider;
    }
}
