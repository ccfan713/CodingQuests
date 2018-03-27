namespace CodingTests
{
    using System;
    using System.Collections.Generic;
    public enum Granularity
    {
        MINUTE, HOUR, DAY
    }

    interface ICountingService
    {
        void RecordEvent(string eventName, long timeInMillis);
        long[] GetEventCounts(Granularity granularity, string eventName, long startTime, long endTime);
    }

    public class CountingServiceImpl : ICountingService
    {
        Dictionary<Granularity, long> GranularityEpochs = new Dictionary<Granularity, long>();

        // key - epoch + event name
        Dictionary<Tuple<long, string>, long> epochEventBuckets = new Dictionary<Tuple<long, String>, long>();

        public void RecordEvent(string eventName, long timeInMillis)
        {
            var myKey = new Tuple<long, String>(timeInMillis, eventName);
            if (!epochEventBuckets.ContainsKey(myKey))
            {
                epochEventBuckets.Add(myKey, 0);
            }

            epochEventBuckets[myKey]++;
        }

        public long[] GetEventCounts(Granularity granularity, string eventName, long startTime, long endTime)
        {
            var granularityInEpochs = GranularityEpochs[granularity];
            var buckets = (endTime - startTime) / granularityInEpochs;
            var counts = new long[buckets];
            long countIndex = 0;
            long eventSum = 0;
            for (long epoch = startTime; epoch < endTime; epoch++)
            {
                if (epoch > startTime && epoch % granularityInEpochs == 0)
                {
                    counts[countIndex] = eventSum;
                    countIndex++;
                    eventSum = 0;
                }
                else
                {
                    var key = new Tuple<long, string>(epoch, eventName);
                    if (epochEventBuckets.ContainsKey(key))
                    {
                        eventSum += epochEventBuckets[key];
                    }
                }
            }

            return counts;
        }
    }
}

