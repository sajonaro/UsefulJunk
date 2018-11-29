using System;


namespace CF.API.Objects
{

	[Serializable]
	public class AuditHistoryRequest
	{

		#region Fields
		
		private string	_scenarioName		= "Actual Data";
		private bool _showDeletedRecords = true;
		
		#endregion

		#region Properties 

		// 
		// This set of properties match-up with the underlying SPROC
		//
		public string	AccountKey			{ get; set; }
		public string	Entity_MDX			{ get; set; }
		public string	Period_MDX			{ get; set; }

		public string ScenarioName
		{
			get { return _scenarioName; }
			set { _scenarioName = value; }
		}

		public bool ShowDeletedRecords
		{
			get { return _showDeletedRecords; }
			set { _showDeletedRecords = value; }
		}

		
		//
		// Supporting properties for the UI
		//
		public string AccountName	{ get; set; }
		public string EntityName	{ get; set; }
		public string PeriodName	{ get; set; }
		

		#endregion

		#region Constructors

		public AuditHistoryRequest()
		{
		}

		#endregion

	}

}