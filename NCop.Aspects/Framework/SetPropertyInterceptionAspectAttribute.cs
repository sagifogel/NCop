using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SetPropertyInterceptionAspectAttribute : AspectAttribute
    {
        public SetPropertyInterceptionAspectAttribute(Type aspectType)
            : base(aspectType) {
        }
    }
}
