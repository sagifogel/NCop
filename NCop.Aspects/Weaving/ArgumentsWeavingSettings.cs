using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
	public class ArgumentsWeavingSettings : IArgumentsWeavingSettings
	{
        public Type AspectType { get; set; }
        public bool IsFunction { get; set; }
		public Type ArgumentType { get; set; }
		public Type[] Parameters { get; set; }
    }
}
