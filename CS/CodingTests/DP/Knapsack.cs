using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.DP
{
    public class Knapsack
    {
        public static void Test()
        {
            int[] w = new int[] { 2, 3, 1, 5, 2 };
            int[] v = new int[] { 40, 50, 100, 90, 30 };
            //int[] rem = new int[5] { -1, -1, -1, -1, -1 };
            //int[] valueSum = new int[5];
            //var sum = GetKnapsack(w, v, rem, valueSum, 0, 8);
            var ds = GetKnapsack(w, v, 8);
        }

        private static ItemsByWeightAndValue GetKnapsack(int[] w, int[] v, int capacity)
        {
            var ds = new ItemsByWeightAndValue();
            int i = 0;
            while (ds.TotalWeight + w[i] <= capacity && i < w.Length)
            {
                ds.AddItem(v[i], w[i]);
                i++;
            }

            while (i < w.Length)
            {
                TryReplace(w[i], v[i], ds, capacity);
                i++;
            }

            return ds;
        }

        private static void TryReplace(int newWeight, int newValue, ItemsByWeightAndValue ds, int capacity)
        {
            int i = 0;
            int newSum = 0;
            int valueToReplace = -1;
            while (i < ds.Items.Count && ds.Items.Keys[i] < newValue)
            {
                int value = ds.Items.Keys[i];
                int weight = ds.Items.Values[i];
                if (ds.TotalWeight - weight + newWeight <= capacity)
                {
                    var tempSum = ds.TotalValue - value + newValue;
                    if (tempSum > newSum)
                    {
                        newSum = tempSum;
                        valueToReplace = value;
                    }
                }

                i++;
            }

            if (valueToReplace > -1)
            {
                ds.ReplaceItem(valueToReplace, newValue, newWeight);
            }
        }

        private class ItemsByWeightAndValue
        {
            // value -> weight
            public SortedList<int, int> Items = new SortedList<int, int>();
            public int TotalValue { get; set; }
            public int TotalWeight { get; set; }

            public void AddItem(int value, int weight)
            {
                Items.Add(value, weight);
                TotalValue += value;
                TotalWeight += weight;
            }

            public void ReplaceItem(int valueToBeReplaced, int newValue, int newWeight)
            {
                var oldWeight = Items[valueToBeReplaced];
                Items.Remove(valueToBeReplaced);
                TotalValue -= valueToBeReplaced;
                TotalWeight -= oldWeight;
                AddItem(newValue, newWeight);
            }
        }

        //private static int GetKnapsack(int[] w, int[] v, int[] remCapacity, int[] valueSum, int currentIndex, int currentCapacity)
        //{
        //    if (currentIndex < 0 || currentIndex >= w.Length)
        //    {
        //        return 0;
        //    }

        //    // doesn't fit
        //    if (currentCapacity - w[currentIndex] < 0)
        //    {
        //        remCapacity[currentIndex] = currentCapacity;
        //        valueSum[currentIndex] = currentIndex > 0 ? valueSum[currentIndex - 1] : 0;
        //        return GetKnapsack(w, v, remCapacity, valueSum, currentIndex + 1, currentCapacity);
        //    }

        //    // has a decision been reached for this index already?
        //    if (remCapacity[currentIndex] > - 1)
        //    {
        //        return valueSum[currentIndex];
        //    }

        //    var valueWith = GetKnapsack(w, v, remCapacity, valueSum, currentIndex + 1, currentCapacity - w[currentIndex]);
        //    var valueWithout = GetKnapsack(w, v, remCapacity, valueSum, currentIndex + 1, currentCapacity);
        //    if (valueWith >= valueWithout)
        //    {
        //        remCapacity[currentIndex] = currentCapacity - w[currentIndex];
        //        valueSum[currentIndex] = currentIndex > 0 ? valueSum[currentIndex - 1] + v[currentIndex] : v[currentIndex];
        //        return valueSum[currentIndex];
        //    }

        //    remCapacity[currentIndex] = currentCapacity;
        //    valueSum[currentIndex] = currentIndex > 0 ? valueSum[currentIndex - 1] : 0;
        //    return valueSum[currentIndex];
        //}
    }
}
