using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using NCop.Aspects.Extensions;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
	internal abstract class AbstractAspectDefinition : IAspectDefinition
	{
		protected readonly AdviceDefinitionCollection advices = null;

		internal AbstractAspectDefinition(IAspect aspect) {
			Aspect = aspect;
			advices = new AdviceDefinitionCollection();
			BulidAdvices();
		}

		public IAspect Aspect { get; private set; }

		public abstract AspectType AspectType { get; }

		public IAdviceDefinitionCollection Advices {
			get {
				return advices;
			}
		}

		protected bool TryBulidAdvice<TAdvice>(MethodInfo method, Func<TAdvice, MethodInfo, IAdviceDefinition> adviceDefinitionFactory) where TAdvice : AdviceAttribute {
			var advice = method.GetCustomAttribute<TAdvice>(true);

			if (advice.IsNotNull()) {
				advices.Add(adviceDefinitionFactory(advice, method));

				return true;
			}

			return false;
		}

		protected abstract void BulidAdvices();

        public abstract IAspectExpressionBuilder Accept(AspectVisitor visitor);
    }
}
