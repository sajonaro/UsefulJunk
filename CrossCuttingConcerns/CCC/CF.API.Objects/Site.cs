using System;

namespace CF.API.Objects
{
	//[Serializable]
	public class Site
	{
		
        public string ApplicationName { get; set; }

        public Guid ApplicationID { get; set; }

        public string Name { get; set; }
		public Guid	CFSiteID {get; set;}

        public string PortalURLEndPoint { get; set; }

        public string SSASPROXYEndPoint { get; set; }

        public string DataSourceEndPoint { get; set; }

        public string ApiURLEndPoint { get; set; }

        public string QvalURLEndPoint { get; set; }

		public string DataRoomLocation {get; set;}  
		public byte	CustomerHasOwnCube {get; set;}
        public string CustomerCubeName { get; set; }  
	}
}
