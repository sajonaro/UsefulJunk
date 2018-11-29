using System;


namespace CF.API.Objects
{
    public class EntityContext
    {

        public string EntityMDX { get; set; }
        public string EntityKey { get; set; }
        public Guid CFCompanyID { get; set; }
        public string CompanyName { get; set; }

    }
}
