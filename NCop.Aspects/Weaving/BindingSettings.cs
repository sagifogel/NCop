using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
	public class BindingSettings
	{
		public bool IsFunction { get; set; }
		public Type BindingType { get; set; }
		public Type ArgumentType { get; set; }
		public FieldInfo BindingsDependency { get; set; }
		public ILocalBuilderRepository LocalBuilderRepository { get; set; }
	}
}
