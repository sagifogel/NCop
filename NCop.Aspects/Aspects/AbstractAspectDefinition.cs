using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractAspectDefinition : IAspectDefinition
    {
        protected readonly AdviceDefinitionCollection advices = null;

        internal AbstractAspectDefinition(Type aspectDeclaringType) {
            AspectDeclaringType = aspectDeclaringType;
            advices = new AdviceDefinitionCollection();
        }

        public IAspect Aspect { get; protected set; }

        public abstract AspectType AspectType { get; }

        public Type AspectDeclaringType { get; private set; }

        public IAdviceDefinitionCollection Advices {
            get {
                return advices;
            }
        }

        protected bool TryBulidAdvice<TAdvice>(MethodInfo member, Func<TAdvice, MethodInfo, IAdviceDefinition> adviceDefinitionFactory) where TAdvice : AdviceAttribute {
            var advice = member.GetCustomAttribute<TAdvice>(true);

            return TryBulidAdvice(advice, member, adviceDefinitionFactory);
        }

        protected bool TryBulidAdvice<TAdvice>(TAdvice advice, MethodInfo member, Func<TAdvice, MethodInfo, IAdviceDefinition> adviceDefinitionFactory) where TAdvice : AdviceAttribute {
            if (advice.IsNotNull()) {
                advices.Add(adviceDefinitionFactory(advice, member));

                return true;
            }

            return false;
        }

        public abstract IAspectDefinition BuildAdvices();

        public abstract IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor);
    }
}
