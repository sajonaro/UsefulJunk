namespace CF.API.Objects
{
    public class ProfessionalServicesAssociate
    {

        private string _fullName = string.Empty;
        
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        private string _emailAddress = string.Empty;

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }


    }
}
