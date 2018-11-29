using System;
using System.Collections.Generic;
using System.Linq;

namespace CF.API.Objects
{
    [Serializable]
    public class MetricList : List<Metric>
    {
        
        /// <summary>
        /// A list of Metric objects which are generally processed as a group
        /// </summary>
        public MetricList()
        { }





	}

    public static class MetricList_Extensions
    {
        public static IEnumerable<IEnumerable<MetricETL>> PartitionMetricETL(this IEnumerable<MetricETL> collection, int batchSize)
        {
            List<MetricETL> nextbatch = new List<MetricETL>(batchSize);
            MetricETL previousMetric = collection.ElementAt(0);
            foreach (MetricETL item in collection)
            {
                
                if (nextbatch.Count + 1 == batchSize || item.ProcessingGroup != previousMetric.ProcessingGroup || item.EntityCommonKey != previousMetric.EntityCommonKey)
                {
                    yield return nextbatch;                     // Returns the list of batch size
                    nextbatch = new List<MetricETL>(batchSize);
                }
                nextbatch.Add(item);
                previousMetric = item;
            }
            if (nextbatch.Count > 0)
                yield return nextbatch;                         // Returns whatever is left (something < batchize)
        }



     

        //public static IEnumerable<IEnumerable<Metric>> PartitionMe(this IEnumerable<Metric> collection, int batchSize)
        //{
        //    List<Metric> nextbatch = new List<Metric>(batchSize);
        //    Metric previousMetric = collection.ElementAt(0);
        //    foreach (Metric item in collection)
        //    {
        //        nextbatch.Add(item);
        //        if (nextbatch.Count == batchSize || item.ProcessingGroup != previousMetric.ProcessingGroup)
        //        {
        //            yield return nextbatch;                     // Returns the list of batch size
        //            nextbatch = new List<Metric>(batchSize);
        //        }
        //        previousMetric = item;
        //    }
        //    if (nextbatch.Count > 0)
        //        yield return nextbatch;                         // Returns whatever is left (something < batchize)
        //}


    }



}

