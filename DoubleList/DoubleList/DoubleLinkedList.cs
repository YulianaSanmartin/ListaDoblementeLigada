using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleList;
public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public void Add(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = _tail = newNode;
            return;
        }

        var current = _head;
        while (current != null && current.Data.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        if (current == null)
        {
            _tail!.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
        else if (current == _head)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
        else
        {
            newNode.Prev = current.Prev;
            newNode.Next = current;
            current.Prev!.Next = newNode;
            current.Prev = newNode;
        }
    }

    public string GetForward()
    {
        var current = _head;
        var result = new List<string>();
        while (current != null)
        {
            result.Add(current.Data!.ToString()!);
            current = current.Next;
        }
        return string.Join(" <=> ", result);
    }

    public string GetBackward()
    {
        var current = _tail;
        var result = new List<string>();
        while (current != null)
        {
            result.Add(current.Data!.ToString()!);
            current = current.Prev;
        }
        return string.Join(" <=> ", result);
    }

    public void SortDescending()
    {
        var items = new List<T>();
        var current = _head;
        while (current != null)
        {
            items.Add(current.Data);
            current = current.Next;
        }

        items.Sort();
        items.Reverse();

        _head = _tail = null;
        foreach (var item in items)
        {
            var newNode = new DoubleNode<T>(item);
            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail!.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
        }
    }

    public List<T> GetModes()
    {
        var frequency = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            if (!frequency.ContainsKey(current.Data))
                frequency[current.Data] = 0;
            frequency[current.Data]++;
            current = current.Next;
        }

        int maxFreq = frequency.Values.Max();
        return frequency.Where(kvp => kvp.Value == maxFreq).Select(kvp => kvp.Key).ToList();
    }

    public string GetGraph()
    {
        var frequency = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            if (!frequency.ContainsKey(current.Data))
                frequency[current.Data] = 0;
            frequency[current.Data]++;
            current = current.Next;
        }

        return string.Join("\n", frequency.Select(kvp => $"{kvp.Key} {new string('*', kvp.Value)}"));
    }

    public bool Exists(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void RemoveOne(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev;
                return;
            }
            current = current.Next;
        }
    }
    public void RemoveAll(T data)
    {
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev;
            }
            current = next;
        }
    }
}
