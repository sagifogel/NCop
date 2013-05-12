using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Framework
{	
	[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
	public class IgnoreRegistration : Attribute
	{
	}
}
