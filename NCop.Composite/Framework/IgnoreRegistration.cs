using System;

namespace NCop.Composite.Framework
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
	public class IgnoreRegistration : Attribute
	{
	}
}
