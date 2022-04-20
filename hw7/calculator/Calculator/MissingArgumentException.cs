namespace Calculator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class MissingArgumentException : Exception
{
    public MissingArgumentException() { }

    public MissingArgumentException(string message) : base(message) { }

    public MissingArgumentException(string message, Exception inner) : base(message, inner) { }

    protected MissingArgumentException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
