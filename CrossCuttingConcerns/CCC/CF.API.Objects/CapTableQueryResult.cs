namespace CF.API.Objects
{
    public class CapTableQueryResult
    {
        private string _message = string.Empty;
        private CapTableQueryList _capTableQueryList = new CapTableQueryList();

        public CapTableQueryList CapTableQueryList
        {
            get
            {
                return _capTableQueryList;
            }
            set
            {
                _capTableQueryList = value;
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }

    }
}
