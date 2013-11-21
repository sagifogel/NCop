using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Advices
{
	public interface IAdviceDefinition : IAcceptsVisitor<IExpressionReducer, AdviceVisitor>
    {
        IAdvice Advice { get; }
        MethodInfo AdviceMethod { get; }
    }
}
