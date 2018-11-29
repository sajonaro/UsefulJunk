using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
	public class AuditHistoryDetail
	{

		#region Fields / Properties

		public string		Account				{ get; set; }
		public string		AccountDisplayValue	{ get; set; }
		public string		ChangeType			{ get; set;}
		public string		CurrentValue		{ get; set; }
		public DateTime		ModifiedDate		{ get; set; }
		public string		ModifiedBy			{ get; set; }
		public DateTime		Period				{ get; set; }
		public string		PreviousValue		{ get; set; }
		public string		Entity				{ get; set; }

		public List<AuditHistoryDocumentInfo> HistoryDocumentInfo { get; set; }

		#endregion

		#region Constructors

		public AuditHistoryDetail()
		{
		}

		#endregion



	}

}