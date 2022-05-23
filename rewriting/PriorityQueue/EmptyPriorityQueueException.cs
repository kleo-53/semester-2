namespace PriorityQueue;

/// <summary>
/// This exception thrown if the priority queue is empty
/// </summary>
[System.Serializable]
public class EmptyPriorityQueueException : System.ArgumentNullException
{
    public EmptyPriorityQueueException() { }
    public EmptyPriorityQueueException(string message) : base(message) { }
    public EmptyPriorityQueueException(string message, System.Exception inner) : base(message, inner) { }
    protected EmptyPriorityQueueException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}