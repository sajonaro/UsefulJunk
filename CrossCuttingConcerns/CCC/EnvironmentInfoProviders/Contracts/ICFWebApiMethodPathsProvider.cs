namespace EnvironmentInfoProviders.Contracts
{
    /// <summary>
    /// Interface providing properties that contains paths to CF.API methods
    /// </summary>
    public interface ICFWebApiMethodPathsProvider : IEnvironmentInfoProvider
    {
        string ClearfinancialsCreateReportPath { get; }
        
        string AccountUserInfoPath { get; }
        
        string GetCFSitePath { get; }
        
        string ChangePasswordPath { get; }
        
        string GetTemplateAllCFSitePath { get; }
        
        string GetEntityContextPath { get; }
        
        string SetLastApprovedPeriodPath { get; }
        
        string ProductionProcessCubePath { get; }
        
        string GetEntityDataListPath { get; }
        
        string GetEntityDataValueBulkPath { get; }
        
        string GetCompanyLastCommonClosedPeriodPath { get; }
        
        string GetDateFromPeriodMDXPath { get; }
        
        string AddComentarySectionPath { get; }
        
        string GetComentarySectionPath { get; }
        
        string UpdateComentarySectionPath { get; }
        
        string GetAuditHistoryAsyncPath { get; }
        
        string GetComentarySectionNamePath { get; }
        
        string GetComentarySectionTitlesPath { get; }
        
        string GetCFComentaryValueBulkPath { get; }
        
        string GetPublishDataPath { get; }
        
        string DeletePublishDataPath { get; }
        
        string GetLastPublishDataByUserPath { get; }
        
        string SubmitHelpRequestPath { get; }
        
        string SaveMetricFormulaObjectsPath { get; }
        
        string GetMetricFormulaObjectPath { get; }
        
        string GetMetricFormulasPath { get; }
        
        string GetAccountPropertiesPath { get; }
        
        string ExcelDataPut_V2Path { get; }
        
        string UpdateCommentaryTitlesPath { get; }
        
        string GetEntitySpecBudgetPath { get; }

		string GetCubePropertyPath { get; }
    }
}
