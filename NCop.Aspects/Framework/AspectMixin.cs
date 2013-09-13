using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class AspectMixin : Attribute
    {
        public AspectMixin(Type mixin) {
        }
    }
}
