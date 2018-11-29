namespace CF.API.Objects
{
    public class DataQueryResult
    {
        private string _message = string.Empty;
        private DataQueryList _dataQueryList = new DataQueryList();

        public DataQueryList DataQueryList
        {
            get
            {
                return _dataQueryList;
            }
            set
            {
                _dataQueryList = value;
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
