// This is the text editor interface. 
// Anything you type or change here will be seen by the other person in real time.
using System;
using System.Text;
using System.Collections.Generic;
public class Cache
{
    Dictionary<string, MyTuple> store;

    // Least recently used end
    ListNode Front;

    // Most recently used end
    ListNode Back;
    int Capacity;

    public int Get(string key)
    {
        // gets from dictionary
        if (!store.ContainsKey(key))
        {
            return int.MinValue;
        }

        var tuple = store[key];
        // update listnode to back
        var node = tuple.Item1;
        // node's previous and node's next
        if (node != Front)
        {
            node.Previous.Next = node.Next;
            if (node != Back)
            {
                node.Next.Previous = node.Previous;
            }
        }

        if (node != Back)
        {
            Back.Next = node;
            node.Previous = Back;
            node.Next = null;
            Back = node;
        }

        return tuple.Item2;
    }

    public void Put(string key, int value)
    {
        // capacity check
        if (store.Count == Capacity)
        {
            // evict if necessary
            store.Remove(Front.Data);
            Front = Front.Next;
        }

        // list node creation
        var node = new ListNode { Data = key };

        // front / back init if needed
        if (Front == null)
        {
            Front = Back = node;
        }
        else
        {
            // add list node to back
            Back.Next = node;
            node.Previous = Back;
            Back = node;
        }

        // add item to dictionary
        store.Add(key, new MyTuple(node, value));
    }

    public Cache(int capacity)
    {
        store = new Dictionary<string, MyTuple>(capacity);
        Capacity = capacity;
    }

    public string OutputState()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Store:");
        foreach (var key in store.Keys)
        {
            sb.AppendLine(key + "-" + store[key].Item2);
        }

        sb.AppendLine("Key doubly linked list: ");
        sb.Append("Front: " + Front.Data + "->");
        var node = Front.Next;
        while (node != null)
        {
            sb.Append(node.Data + "->");
            node = node.Next;
        }

        return sb.ToString();
    }

    public class ListNode
    {
        public string Data;
        public ListNode Previous;
        public ListNode Next;
    }

    public class MyTuple
{
    public ListNode Item1;
    public int Item2;

    public MyTuple(ListNode item1, int item2)
    {
        Item1 = item1;
        Item2 = item2;
    }
}

public static void Test()
{
    var cache = new Cache(4);
    cache.Put("a", 10);
    Console.WriteLine(cache.OutputState());
        Console.WriteLine();
    cache.Put("b", 20);
        Console.WriteLine(cache.OutputState());
        Console.WriteLine();
        cache.Put("x", 15);
        Console.WriteLine(cache.OutputState());
        Console.WriteLine();
        var output = cache.Get("b");
        Console.WriteLine("Value for b: " + output);
    cache.Put("y", 100);
        Console.WriteLine(cache.OutputState());
        Console.WriteLine();
        cache.Put("z", 50);
        Console.WriteLine(cache.OutputState());
        Console.WriteLine();
        cache.Put("d", 35);
        Console.WriteLine(cache.OutputState());
        Console.WriteLine();
    }
}