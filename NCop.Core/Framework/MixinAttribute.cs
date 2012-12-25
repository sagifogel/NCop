using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Framework
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class MixinOfAttribute : Attribute
    {
        public MixinOfAttribute(Type mixin) {
            Mixin = mixin;
        }

        public Type Mixin { get; private set; }
    }
}