using NCop.Aspects.Properties;
using System;
using System.Runtime.Serialization;

namespace NCop.Aspects.Exceptions
{
    [Serializable]
    public class TopAspectInvalidOperationException : InvalidOperationException
    {
        public TopAspectInvalidOperationException()
            : base(Resources.EmitLoadLocalAddressAtTopAspectIsInvalid) {
        }

        public TopAspectInvalidOperationException(string message)
            : base(message) {
        }

        public TopAspectInvalidOperationException(string message, Exception innerException)
            : base(message, innerException) {
        }

        public TopAspectInvalidOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
