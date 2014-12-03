using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public ILocalBuilderRepository LocalBuilderRepository { get; set; }
	}
}
