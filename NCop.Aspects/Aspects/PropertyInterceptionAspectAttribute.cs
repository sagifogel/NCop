
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class PropertyInterceptionAspectAttribute : AspectAttribute
    {
		public PropertyInterceptionAspectAttribute(Type aspectType)
			: base(aspectType) {
		}
    }
}
