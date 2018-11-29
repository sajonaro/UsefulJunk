using System;

namespace CF.API.Objects
{
    [Serializable]
    public class CFEntityNotesPeriod
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

		private DateTime _dateAdded = DateTime.MinValue;

		public DateTime DateAdded
		{
			get { return _dateAdded; }
			set { _dateAdded = value; }
		}

		private DateTime _dateChanged = DateTime.MinValue;

		public DateTime DateChanged
		{
			get { return _dateChanged; }
			set { _dateChanged = value; }
		}

		private string addedByEmail = string.Empty;

		public string AddedByEmail
		{
			get { return addedByEmail; }
			set { addedByEmail = value; }
		}

    }
}
