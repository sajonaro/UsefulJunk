using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    public class EntityListPlusMetrics
    {
        public List<Fund> funds = new List<Fund>();
        public List<string[]> defaultMetrics = new List<string[]>();

        public List<string[]> metricGroup1 = new List<string[]>();
        public List<string[]> metricGroup2 = new List<string[]>();
        public string metricGroup1Name = "Metric Group 1";
        public string metricGroup2Name = "Metric Group 2";

        public List<string[]> availableMetrics = new List<String[]>();

        public DateTime TimeRequestedData = DateTime.UtcNow;
    }
}
