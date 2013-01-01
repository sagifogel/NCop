using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class AttributeMixinTypeDescriptor : Attribute, IMixinTypeDescriptor
    {
        public AttributeMixinTypeDescriptor(Type mixin) {
            Mixin = mixin;
        }

        public Type Mixin { get; set; }
    }
}
