using System;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class AspectMixin : Attribute
    {
        public AspectMixin(Type mixin) {
        }
    }
}
