namespace SkipList;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class MySkipList<T> : IList<T> where T : IComparable<T>
{
    private class Node
    {
        public T? Value { get; private set; }
        public Node? Next { get; set; }
        public Node? Down { get; set; }

        public Node(T? value)
        {
            this.Value = value;
        }
        public Node(T? value, Node? next, Node? down)
        {
            this.Value = value;
            this.Next = next;
            this.Down = down;
        }
    }

    private int maxLevel;
    private const double NIL = 1e10;
    private Node head; 
    private Node bottomHead;

    public int Count { get; private set; }

    public bool IsReadOnly => throw new NotImplementedException();

    public T this[int index] {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int counter = 0;
            var node = bottomHead.Next;
            while (counter < index)
            {
                if (node == null)
                {
                    throw new ArgumentNullException();
                }
                node = node.Next;
                ++counter;
            }
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            return node.Value!;
        }
        set
        {
            throw new NotSupportedException("Can not change value by index!");
        }
    }

    public MySkipList()
    {
        head = new Node(default);
        bottomHead = new Node(default);
        maxLevel = 1;
    }

    private bool SearchRecursive(Node? node, T value)
    {
        if (node == null)
        {
            return false;
        }
        while (node.Next != null && value.CompareTo(node.Next.Value) > 0)
        {
            node = node.Next;
        }

        if (node.Next != null && node.Next.Value != null && node.Next.Value.Equals(value))
        {
            return true;
        }
        return SearchRecursive(node.Down, value);
    }

    public bool Contains(T value)
    {
        return SearchRecursive(head, value);
    }

    private Node? InsertRecursive(Node node, T value)
    {
        while (node.Next != null && value.CompareTo(node.Next.Value) >= 0)
        {
            node = node.Next;
        }

        Node? downNode;
        if (node.Down == null)
        {
            downNode = null;
        }
        else
        {
            downNode = InsertRecursive(node.Down, value);
        }

        if (downNode != null || node.Down == null)
        {
            Node? curNext = node.Next;
            node.Next = new Node(value, downNode, curNext);

            Random random = new();
            if (random.Next(2) == 1)
            {
                return node.Next;
            }
            return null;
        }
        return null;
    }

    public void Add(T value)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }

        if (head.Next == null)
        {
            head.Next = new Node(value);
            return;
        }
        InsertRecursive(head, value);
        ++Count;

        if (Count > Math.Pow(2, maxLevel))
        {
            var newHead = new Node(default);
            newHead.Down = head;
            head = newHead;
            ++maxLevel;
        }
    }

    private bool RemoveRecursive(Node node, T value)
    {
        while (node.Next != null && value.CompareTo(node.Next.Value) > 0)
        {
            node = node.Next;
        }
        var isRemoved = false;
        if (node.Down != null)
        {
            isRemoved = RemoveRecursive(node.Down, value);
        }
        if (node.Next != null && node.Next.Value != null && node.Next.Value.Equals(value))
        {
            node.Next = node.Next.Next;
            return true;
        }
        return isRemoved;
    }

    public bool Remove(T value)
    {
        if (RemoveRecursive(head, value))
        {
            --Count;
            return true;
        }
        return false;
    }

    public IEnumerator GetEnumerator()
    {
        var array = new T[Count];
        CopyTo(array, 0);
        return array.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return (IEnumerator<T>)GetEnumerator();
    }

    public int IndexOf(T value)
    {
        int counter = 0;
        Node? node = bottomHead.Next;
        while (node != null)
        {
            if (node.Value != null && node.Value.Equals(value))
            {
                return counter;
            }
            node = node.Next;
            ++counter;
        }
        return -1;
    }

    public void Insert(int index, T value)
    {
        throw new NotSupportedException("List is sorted!");
    }

    public void RemoveAt(int index)
    {
        throw new NotSupportedException("Can not remove by index, only by value!");
    }

    public void Clear()
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }
        head = new Node(default);
        bottomHead = new Node(default);
        maxLevel = 1;
        Count = 0;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex >= Count || array.Length < Count - arrayIndex)
        {
            throw new ArgumentOutOfRangeException();
        }
        var node = bottomHead.Next;
        for (int i = 0; i < arrayIndex; ++i)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            node = node.Next;
        }
        var counter = 0;
        while (node != null)
        {
            if (node.Value == null)
            {
                throw new ArgumentNullException();
            }
            array[counter] = node.Value;
            node = node.Next;
            ++counter;
        }
    }
}
