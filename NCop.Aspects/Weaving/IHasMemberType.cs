using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public interface IHasMemberType
    {
        bool HasReturnType { get; }
        MemberInfo MemberInfo { get; }
        MemberTypes MemberType { get; }
    }
}
