using System;

namespace CF.API.Objects
{

	[Serializable]
	public class AuditHistoryDocumentInfoRequest
	{

		#region Fields / Properties

		public string Entity_MDX { get; set; }
		public string Period_MDX { get; set; }
		public string ScenarioName { get; set; }

		#endregion

		#region Constructors

		public AuditHistoryDocumentInfoRequest()
		{
		}

		#endregion

	}

}