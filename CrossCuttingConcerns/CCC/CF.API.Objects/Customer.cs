using System;

namespace CF.API.Objects
{
    [Serializable]
    public class Customer
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Guid _identifier = Guid.NewGuid();
        public Guid identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }

        private string _applicationName;
        public string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        private ProfessionalServicesAssociate _professionalServicesAssociate = new ProfessionalServicesAssociate();
        public ProfessionalServicesAssociate ProfessionalServicesAssociate
        {
            get { return _professionalServicesAssociate; }
            set { _professionalServicesAssociate = value; }
        }

    }
}