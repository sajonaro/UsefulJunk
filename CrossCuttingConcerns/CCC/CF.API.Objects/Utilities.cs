using System;
using System.Collections.Generic;
using Microsoft.AnalysisServices;

namespace CF.API.Objects
{


    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }

    class Utilities
    {
        #region Analysis_Service_Activity
        public Server analysisSqlServer;
        /// <summary>
        /// Process the cube
        /// </summary>
        /// <param name="server"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="cubeName"></param>
        /// <returns>Success if processed successfully else error message</returns>
        public string ProcessCube(string Server,string Username, string Password, string CubeName){

            try
            {
                string connectionString = "Data Source=" + Server
                                        + ";User ID=" + Username
                                            + ";Password=" + Password + ";";

                analysisSqlServer = new Server();
                analysisSqlServer.Connect(connectionString);


                Database db_PreviouslyCreated = analysisSqlServer.Databases.FindByName(CubeName);
                db_PreviouslyCreated.DataSourceImpersonationInfo.ImpersonationMode = ImpersonationMode.Default;
                db_PreviouslyCreated.Update();
                System.Collections.IEnumerator iteratorDataBaseCollection = db_PreviouslyCreated.DataSources.GetEnumerator();
                while (iteratorDataBaseCollection.MoveNext())
                {
                    ((DataSource)iteratorDataBaseCollection.Current).ImpersonationInfo.ImpersonationMode = ImpersonationMode.ImpersonateServiceAccount;
                    ((DataSource)iteratorDataBaseCollection.Current).Update();
                }

                ErrorConfiguration dbErrorConfiguration = new ErrorConfiguration();
                dbErrorConfiguration.KeyErrorLimitAction = KeyErrorLimitAction.StopLogging;
                db_PreviouslyCreated.Process(ProcessType.ProcessDefault, dbErrorConfiguration);

                Cube cube = db_PreviouslyCreated.Cubes.FindByName("Clear Financials AS");
                cube.ProactiveCaching.Enabled = false;
                cube.ErrorConfiguration = new ErrorConfiguration();
                cube.StorageMode = StorageMode.Molap;
                cube.ErrorConfiguration.KeyErrorLimitAction = KeyErrorLimitAction.StopLogging;
                cube.ProactiveCaching.Enabled = false;
                cube.Update(UpdateOptions.Default, UpdateMode.Update);
                cube.Refresh(true);
            }
            catch(Exception ex)
            {
                return ex.InnerException.ToString();
            }
            return "success";
        }

        /// <summary>
        /// Return cube last processed time
        /// </summary>
        /// <param name="server"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="cubeName"></param>
        /// <returns>Success if processed successfully else error message</returns>
        public string CubeLastProcessedTime(string Server, string Username, string Password, string CubeName)
        {
            try
            {
                Database db_PreviouslyCreated = analysisSqlServer.Databases.FindByName(CubeName);
                Cube cube = db_PreviouslyCreated.Cubes.FindByName("Clear Financials AS");
                return cube.LastProcessed.ToString();
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
            //return "success";
        }
        #endregion
    }
}
