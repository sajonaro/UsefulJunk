namespace CF.API.Objects
{
    public class AttributeQuery
    {
        public string EntityName { get; set; }

        public string Period { get; set; }

        public string Key { get; set; }

        public object AttributeValue { get; set; }

        public string EntityDataKey { get; set; }

        public string ScenarioName { get; set; }

        public string CurrencyTypeKey { get; set; }

    }
}
