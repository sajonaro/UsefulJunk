namespace EnvironmentInfoProviders.Contracts {
    /// <summary>
    /// Convention based Environment InfoProvider factory
    /// Assumes that contracts (T) are defined in the same assembly that 
    /// contains appconfig file with parameters for this contract
    /// </summary>
    public interface IAssemblyBoundAppConfigEIPFactory: IEnvironmentInfoProviderFactory {
         
    }
}