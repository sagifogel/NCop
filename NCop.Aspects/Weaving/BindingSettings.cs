using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
	internal class BindingSettings
	{
        public bool IsProperty { get; set; }
	    public bool IsFunction { get; set; }
		public Type BindingType { get; set; }
		public Type ArgumentType { get; set; }
		public FieldInfo BindingDependency { get; set; }
	}
}
