using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Mixins.Framework
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class MixinsAttribute : Attribute
    {
        public MixinsAttribute(params Type[] mixins) {
            Mixins = mixins;
        }

        public Type[] Mixins { get; private set; }
    }
}
