using System;

namespace NCop.Aspects.Weaving
{
    public interface IArgumentsSettings : IHasMemberType
    {
        Type ReturnType { get; }
        Type ArgumentType { get; }
        Type[] Parameters { get; }
    }
}
