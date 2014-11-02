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
	internal abstract class AbstractAspectDefinition<TMember> : IAspectDefinition where TMember : MemberInfo
	{
		protected readonly AdviceDefinitionCollection advices = null;

		internal AbstractAspectDefinition(IAspect aspect, Type aspectDeclaringType, MemberInfo member) {
			Aspect = aspect;
			Member = member;
			AspectDeclaringType = aspectDeclaringType;
			advices = new AdviceDefinitionCollection();
			BulidAdvices();
		}

		public IAspect Aspect { get; private set; }

		public MemberInfo Member { get; private set; }

		public abstract AspectType AspectType { get; }

		public Type AspectDeclaringType { get; private set; }

		public IAdviceDefinitionCollection Advices {
			get {
				return advices;
			}
		}

        protected bool TryBulidAdvice<TAdvice>(TMember member, Func<TAdvice, TMember, IAdviceDefinition> adviceDefinitionFactory) where TAdvice : AdviceAttribute {
			var advice = member.GetCustomAttribute<TAdvice>(true);

			return TryBulidAdvice(advice, member, adviceDefinitionFactory);
		}

        protected bool TryBulidAdvice<TAdvice>(TAdvice advice, TMember member, Func<TAdvice, TMember, IAdviceDefinition> adviceDefinitionFactory) where TAdvice : AdviceAttribute {
			if (advice.IsNotNull()) {
				advices.Add(adviceDefinitionFactory(advice, member));

				return true;
			}

			return false;
		}

		protected abstract void BulidAdvices();

		public abstract IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor);
	}
}
