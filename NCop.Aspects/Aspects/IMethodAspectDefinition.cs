using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public interface IMethodAspectDefinition : IAspectDefinition
    {
        MethodInfo Method { get; }
    }
}
