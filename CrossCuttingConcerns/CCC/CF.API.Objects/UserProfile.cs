using System.Collections.Generic;

namespace CF.API.Objects
{
    public class UserProfile
    {
        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string UsernameSAMAccount
        {
            get 
            { 
                string samAccountName = string.Empty;

                if (_email.Length > 20)
                {
                    samAccountName = _email.Replace("@", "_").Substring(0, 20);
                }
                else
                {
                    samAccountName = _email.Replace("@", "_");
                }

                samAccountName = samAccountName.TrimEnd('.');
                return samAccountName;
            }
        }

        private string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _fullName = string.Empty;
        public string FullName
        {
            get { return FirstName.Trim() + " " + LastName.Trim(); }
            set { _fullName = value; }
        }

        public Dictionary<string, ulong> Features { get; set; }
        


        private Site _customer = null;
        public Site Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        /*
        private string _siteName = string.Empty;
        public string SiteName
        {
            get { return _siteName; }
            set { _siteName = value; }
        }


        private string _applicationName = string.Empty;
        public string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }


        private string _portalURL = string.Empty;

        public string PortalURL
        {
            get { return _portalURL; }
            set { _portalURL = value; }
        }

        private string _cubeName = string.Empty;

        public string CustomerCubeName
        {
            get { return _cubeName; }
            set { _cubeName = value; }
        }*/


        private bool isPortfolioCompanyUser = false;
        public bool IsPortfolioCompanyUser
        {
            get { return isPortfolioCompanyUser; }
            set { isPortfolioCompanyUser = value; }
        }

        private ProfessionalServicesAssociate _professionalServicesAssociate = null;
        public ProfessionalServicesAssociate ProfessionalServicesAssociate
        {
            get { return _professionalServicesAssociate; }
            set { _professionalServicesAssociate = value; }
        }

        //private CFFeatures _features = null; 


        /*
        private string _company = string.Empty;
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }*/
    }
}
