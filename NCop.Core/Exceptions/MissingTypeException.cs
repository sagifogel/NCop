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

namespace NCop.Core.Exceptions
{
	[Serializable]
	public class MissingTypeException : ArgumentException
	{
		private static string message = "Missing type annotation";
		
		public MissingTypeException(string message = null) : base(message ?? MissingTypeException.message) { }

		public MissingTypeException(Exception innerException) : this(message, innerException) { }

		public MissingTypeException(string parameterName, string message = null) : base(message ?? MissingTypeException.message, parameterName) { }

		public MissingTypeException(string message, Exception innerException) : base(message, innerException) { }

		protected MissingTypeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
	