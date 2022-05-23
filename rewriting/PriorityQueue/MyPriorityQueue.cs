namespace PriorityQueue;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Realisation of the priority queue
/// </summary>
public class MyPriorityQueue<TItem> : IEnumerable<TItem>
{
    private SortedDictionary<int, List<TItem>>? elements;
    private bool isEmpty = true;

    /// <summary>
    /// Returns if priority queue is empty
    /// </summary>
    public bool Empty => isEmpty;

    /// <summary>
    /// Adds element by its priority to the priority queue
    /// </summary>
    /// <param name="value">Value to add</param>
    /// <param name="priority">Priority of value</param>
    public void Enqueue(int priority, TItem value)
    {
        if (isEmpty)
        {
            elements = new SortedDictionary<int, List<TItem>>();
        }
        if (!elements.TryGetValue(priority, out var list))
        {
            elements[priority] = new List<TItem>();
        }
        elements[priority].Add(value);
        if (isEmpty)
        {
            isEmpty = false;
        }
    }

    /// <summary>
    /// Removes value with the most priority
    /// </summary>
    /// <returns>Removed value</returns>
    /// <exception cref="EmptyPriorityQueueException">Thrown exception if the priority queue is empty</exception>
    public TItem Dequeue()
    {
        if (isEmpty)
        {
            throw new EmptyPriorityQueueException();
        }
        var elementsWithTheMostPriority = elements.Last().Value;
        var result = elementsWithTheMostPriority[0];
        if (elementsWithTheMostPriority.Count == 1)
        {
            if (elements.Count == 1)
            {
                isEmpty = true;
            }
            elements.Last().Value.Remove(elementsWithTheMostPriority[0]);
            elements.Remove(elements.Last().Key);
        }
        else
        {
            elements.Last().Value.Remove(elementsWithTheMostPriority[0]);
            
        }
        return result;
    }

    /// <summary>
    /// Returns enumerator
    /// </summary>
    /// <returns>Enumerator</returns>
    /// <exception cref="NotImplementedException">Thrown then 
    /// operation is not implemented</exception>
    public IEnumerator<TItem> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns enumerator
    /// </summary>
    /// <returns>Enumerator</returns>
    /// <exception cref="NotImplementedException">Thrown then 
    /// operation is not implemented</exception>
    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
