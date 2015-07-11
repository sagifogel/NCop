using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class BindingSettings : IHasMemberType
    {
        public Type BindingType { get; set; }
        public Type ArgumentType { get; set; }
        public bool HasReturnType { get; set; }
        public MemberInfo MemberInfo { get; set; }
        public MemberTypes MemberType { get; set; }
        public FieldInfo BindingDependency { get; set; }
    }
}
