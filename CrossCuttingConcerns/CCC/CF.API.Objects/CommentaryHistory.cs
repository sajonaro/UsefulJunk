using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    [Serializable]
    public class commentaryHistoryDetails
    {
        private string _periodName;

        public string PeriodName
        {
            get { return _periodName; }
            set { _periodName = value; }
        }
        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }


        private string _value1;

        public string Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        private string _value2;

        public string Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        private string _value3;

        public string Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        private string _value4;

        public string Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        private string _value5;

        public string Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        private string _value6;

        public string Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        private string _value7;

        public string Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        private string _value8;

        public string Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        private string _value9;

        public string Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        private string _value10;

        public string Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }


        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _dateChanged;

        public DateTime DateChanged
        {
            get { return _dateChanged; }
            set { _dateChanged = value; }
        }


        private string _changedBy;

        public string ChangedBy
        {
            get { return _changedBy; }
            set { _changedBy = value; }
        }


    }
    [Serializable]
    public class CommentaryHistory
    {
        private List<commentaryHistoryDetails> _allCommentary;
        public List<commentaryHistoryDetails> AllCommentary
        {
            get { return _allCommentary; }
            set { _allCommentary = value; }
        }

        public CommentaryHistory()
        {
            _allCommentary = new List<commentaryHistoryDetails>();
        }

    }
}
