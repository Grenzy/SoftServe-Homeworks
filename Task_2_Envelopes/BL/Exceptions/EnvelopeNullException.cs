using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Envelopes.BL.Exceptions
{
    [Serializable()]
    public class EnvelopeIsNullException : Exception
    {
        public EnvelopeIsNullException() : base() { }
        public EnvelopeIsNullException(string message) : base(message) { }
        public EnvelopeIsNullException(string message, Exception inner) : base(message, inner) { }
        protected EnvelopeIsNullException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
