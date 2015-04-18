using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public interface IArgumentsSettings
    {
        Type ReturnType { get; }
        Type ArgumentType { get; }
        Type[] Parameters { get; }
        bool HasReturnType { get; }
        MemberTypes MemberType { get; }
    }
}
