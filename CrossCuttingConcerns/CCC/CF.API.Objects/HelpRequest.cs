using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    [Serializable]
    public class HelpRequest
    {

        private string _toEmailAddress = string.Empty;
       public string ToEmailAddress
        {
            get { return _toEmailAddress; }
            set { _toEmailAddress = value; }
        }
       private string _subject = string.Empty;

       public string Subject
       {
           get { return _subject; }
           set { _subject = value; }
       }
       private string _message = string.Empty;

       public string Message
       {
           get { return _message; }
           set { _message = value; }
       }

       List<attachment> _attachments = new List<attachment>();

       public List<attachment> Attachments
       {
           get { return _attachments; }
           set { _attachments = value; }
       }

    }



     public class attachment
       {
           private string _name = string.Empty;

            public string Name
            {
              get { return _name; }
              set { _name = value; }
            }

            private string _fileExtension = string.Empty;
            public string FileExtension
            {
                get { return _fileExtension; }
                set { _fileExtension = value; }
            }


            private string _file = string.Empty;

            public string File
            {
                get { return _file; }
                set { _file = value; }
            }

       }

}
