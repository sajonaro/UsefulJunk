namespace EnvironmentInfoProviders.Contracts
{
    /// <summary>
    /// Interface providing properties that contains paths to Qval API methods.
    /// </summary>
    public interface IQvalWebApiMethodPathProvider : IEnvironmentInfoProvider
    {
        string QvalSSORedirectPath { get; }

        string QvalQueryPath { get; }

        string GetCaptableDataAsyncPath { get; }

        string GetCaptableDataTermsAsyncPath { get; }

        string GetCaptableSeriesDataAsyncPath { get; }

        string GetOutcomeScenariosAsyncPath { get; }

        string GetOutcomeScenariosDetailsAsyncPath { get; }

        string GetOutcomeScenarioWaterfallPath { get; }

        string GetValuationsAsyncPath { get; }

        string GetParseRulesPath { get; }

        string GetNoteInvestmentPath { get; }

        string GetCaptableSeriesDataPath { get; }

        string QvalCaptablePagePath { get; }

        string QvalOutcomeAnalysisPagePath { get; }

        string QvalValuationsPagePath { get; }

        string GetCapTableDataPath { get; }

        string GetCompanyLevelData { get; }
    }
}
