namespace CF.API.Objects
{

    public enum QvalParseRuleType
    {
        ResourceIdentifier      = 1,
        ResourceDisplayLabel    = 2,
    }


    // [Serializable]
	public class QvalParseRule
	{

        public string Key { get; set; }
        public QvalParseRuleType RuleType { get; set; }

        public string Pattern { get; set; }
        public string FieldLookup { get; set; }
     
        public string ConcatenationPrefix { get; set; }
        public string ConcatenationSuffix { get; set; }

        public string TokenizedAccountPathToken { get; set; }
        public string TokenizedAccountPathIdentifier { get; set; }




        public QvalParseRule()
		{
		}

	}
}