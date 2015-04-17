using System;

namespace NCop.Aspects.Weaving
{
    public interface IArgumentsSettings
    {
        Type ReturnType { get; }
        bool IsFunction { get; }
        Type ArgumentType { get; }
        Type[] Parameters { get; }
    }
}
