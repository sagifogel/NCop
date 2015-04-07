using System;

namespace NCop.Mixins.Framework
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class MixinsAttribute : Attribute
    {
        public MixinsAttribute(params Type[] mixins) {
            Mixins = mixins;
        }

        public MixinsAttribute(Type[] mixins, Type[] ignoreMixins) {
            Mixins = mixins;
            IgnoredMixins = ignoreMixins;
        }

        internal Type[] Mixins { get; private set; }
        internal Type[] IgnoredMixins { get; private set; }
    }
}
