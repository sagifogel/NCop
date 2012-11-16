using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NCop.Core.Exceptions
{
	[Serializable]
	public class MissingMixinException : ArgumentException
	{
		private static string _message = "Missing mixin annotation";
		
		public MissingMixinException(string parameterName) : base(_message, parameterName) { }

		public MissingMixinException(string parameterName, string message) : base(message, parameterName) { }

		public MissingMixinException(string message, Exception innerException) : base(message, innerException) { }

		protected MissingMixinException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
	