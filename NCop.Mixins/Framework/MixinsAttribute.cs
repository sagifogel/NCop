using System;

namespace NCop.Mixins.Framework
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class MixinsAttribute : Attribute
    {
        public MixinsAttribute(params Type[] mixins) {
            Mixins = mixins;
        }

        internal Type[] Mixins { get; private set; }
    }
}
