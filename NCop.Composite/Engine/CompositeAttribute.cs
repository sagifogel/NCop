﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Engine
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public abstract class CompositeAttribute : Attribute
    {
		public CompositeAttribute(Type castAs = null) {
			As = castAs;
		}       
		
		internal Type As { get; set; }
    }
}
