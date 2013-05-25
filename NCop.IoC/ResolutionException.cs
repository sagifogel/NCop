﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by NCop Copyright © 2013
//    Changes to this file may cause incorrect behavior and will be lost if
//    the code is regenerated.
// </auto-generated
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NCop.IoC
{
	[Serializable]
	public class ResolutionException : ArgumentException
	{
		private static string message = "Type could not be resolved";
		
		public ResolutionException(string message = null) : base(message ?? ResolutionException.message) { }

		public ResolutionException(Exception innerException) : this(message, innerException) { }

		public ResolutionException(string parameterName, string message = null) : base(message ?? ResolutionException.message, parameterName) { }

		public ResolutionException(string message, Exception innerException) : base(message, innerException) { }

		protected ResolutionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
	