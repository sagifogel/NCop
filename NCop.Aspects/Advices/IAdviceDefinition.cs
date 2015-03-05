using NCop.Aspects.Engine;
using NCop.Aspects.Weaving;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core;
using System.Reflection;

namespace NCop.Aspects.Advices
{
	public interface IAdviceDefinition : IAcceptsVisitor<AdviceVisitor, IAdviceExpression>, IAcceptsVisitor<AdviceDiscoveryVisitor>
	{
		IAdvice Advice { get; }
		MethodInfo AdviceMethod { get; }
	}
}
