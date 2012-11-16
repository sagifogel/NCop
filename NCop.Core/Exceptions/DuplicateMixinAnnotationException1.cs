using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NCop.Core.Exceptions
{
    [Serializable]
    public class DuplicateMixinAnnotationException : ArgumentException
    {
        private static string _message = "Duplicate mixin annotation has been found";

        public DuplicateMixinAnnotationException(string parameterName) : base(_message, parameterName) { }

        public DuplicateMixinAnnotationException(string parameterName, string message) : base(message, parameterName) { }

        public DuplicateMixinAnnotationException(string message, Exception innerException) : base(message, innerException) { }

        protected DuplicateMixinAnnotationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
