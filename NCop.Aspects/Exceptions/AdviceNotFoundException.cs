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
using NCop.Core.Extensions;

namespace NCop.Aspects.Exceptions
{	
	[Serializable]
	public class AdviceNotFoundException : SystemException, ISerializable
	{
        private readonly string message = string.Empty;
		private readonly bool messageInitialized = false;
		
        public AdviceNotFoundException(string message) 
		    : base(message) {
            messageInitialized = true;
        }

        public AdviceNotFoundException(string message, Exception innerException) 
		    : base(message, innerException) {
            messageInitialized = true;
        }
		
		public AdviceNotFoundException(Type aspectType)
			: base(null) {
			AspectType = aspectType;
			message = "Could not find any advices on aspect {0}".Fmt(aspectType.FullName);
		}
	
		public Type AspectType { get; protected set; }

		public override string Message {
            get {
                if (messageInitialized) {
                    return base.Message;
                }

                return message;
            }
        }
		
		protected AdviceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
			object value = null;

            if (info == null) {
                throw new ArgumentNullException("info");
            }

            message = info.GetString("AspectMessage");
			value = info.GetValue("AspectType", typeof(Type));

			if (value != null) {
				AspectType = (Type)value;
			}
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            if (info == null) {
                throw new ArgumentNullException("info");
            }

            base.GetObjectData(info, context);
            info.AddValue("AspectMessage", Message);
			info.AddValue("AspectAspectType", AspectType, typeof(Type));
        }
	}	
}