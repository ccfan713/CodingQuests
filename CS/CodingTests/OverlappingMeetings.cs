using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests
{
    public class OverlappingMeetings
    {
        public static void Test()
        {
            var tuples = new List<Tuple<int, int>>();
            tuples.Add(new Tuple<int, int>(1, 5));
            tuples.Add(new Tuple<int, int>(2, 3));
            var ret = FindOverlap(tuples);

            var tuples2 = new List<Tuple<int, int>>();
            tuples2.Add(new Tuple<int, int>(1, 3));
            tuples2.Add(new Tuple<int, int>(2, 6));
            ret = FindOverlap(tuples2);

            //var tuples3 = new List<Tuple<int, int>>();
            //tuples3.Add(new Tuple<int, int>(1, 3));
            //tuples3.Add(new Tuple<int, int>(4, 6));
            //tuples3.Add(new Tuple<int, int>(6, 8));
            //tuples3.Add(new Tuple<int, int>(9, 10));
            //ret = FindOverlap(tuples3);

            var tuples4 = new List<Tuple<int, int>>();
            tuples4.Add(new Tuple<int, int>(1, 3));
            tuples4.Add(new Tuple<int, int>(4, 10));
            tuples4.Add(new Tuple<int, int>(7, 8));
            tuples4.Add(new Tuple<int, int>(9, 11));
            ret = FindOverlap(tuples4);
        }

            private static bool FindOverlap(List<Tuple<int, int>> meetings)
        {
            // sort all start and end times
            SortedList<int, Tuple<int, int>> sortedList = new SortedList<int, Tuple<int, int>>(meetings.Count * 2);
            foreach(var meeting in meetings)
            {
                sortedList.Add(meeting.Item1, meeting);
                sortedList.Add(meeting.Item2, meeting);
            }

            bool overlapFound = false;
            int i = 0;
            while(!overlapFound && i < sortedList.Count - 1)
            {
                var time1 = sortedList.Keys[i];
                var time2 = sortedList.Keys[i + 1];

                overlapFound = sortedList[time1] != sortedList[time2];
                i++;
            }

            return overlapFound;
        }
    }
}
