using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using System;

namespace NCop.Aspects.Weaving.Expressions
{
    public interface IAspectDefinitionVisitor
    {
        Func<IAspectDefinition, IAspectExpressionBuilder> Visit(OnMethodBoundaryAspectAttribute aspect);
        Func<IAspectDefinition, IAspectExpressionBuilder> Visit(MethodInterceptionAspectAttribute aspect);
        Func<IAspectDefinition, IAspectExpressionBuilder> Visit(GetPropertyFragmentInterceptionAspect aspect);
        Func<IAspectDefinition, IAspectExpressionBuilder> Visit(SetPropertyFragmentInterceptionAspect aspect); 
        Func<IAspectDefinition, IAspectExpressionBuilder> Visit(GetPropertyInterceptionAspectAttribute aspect);
        Func<IAspectDefinition, IAspectExpressionBuilder> Visit(SetPropertyInterceptionAspectAttribute aspect);
    }
}
