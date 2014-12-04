using System;

namespace NCop.Aspects.Weaving
{
    public interface IArgumentsSettings
    {
        bool IsProperty { get; }
        Type ReturnType { get; }
        bool IsFunction { get; }
        Type ArgumentType { get; }
        Type[] Parameters { get; }
    }
}
