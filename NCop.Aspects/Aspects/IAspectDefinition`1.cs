using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public interface IAspectDefinition : IAcceptsVisitor<IAspectDefinitionVisitor, IAspectExpressionBuilder>
    {
        IAspect Aspect { get; }
        MemberInfo Target { get; }
        AspectType AspectType { get; }
        IAspectDefinition BuildAdvices();
        Type AspectDeclaringType { get; }
        IAdviceDefinitionCollection Advices { get; }
    }
}
