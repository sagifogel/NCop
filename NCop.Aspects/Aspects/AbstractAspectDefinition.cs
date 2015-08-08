using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public abstract class AbstractAspectDefinition<TMember> : IAspectDefinition where TMember : MemberInfo
    {
        protected readonly AdviceDefinitionCollection advices = null;

        internal AbstractAspectDefinition(Type aspectDeclaringType) {
            AspectDeclaringType = aspectDeclaringType;
            advices = new AdviceDefinitionCollection();
        }

        public IAspect Aspect { get; protected set; }

        public abstract AspectType AspectType { get; }

        public TMember Member { get; protected set; }

        public Type AspectDeclaringType { get; private set; }

        public IAdviceDefinitionCollection Advices {
            get {
                return advices;
            }
        }

        protected bool TryBulidAdvice<TBuildMember, TAdvice>(TBuildMember member, Func<TAdvice, TBuildMember, IAdviceDefinition> adviceDefinitionFactory)
            where TAdvice : AdviceAttribute
            where TBuildMember : MemberInfo {

            var advice = member.GetCustomAttribute<TAdvice>(true);

            return TryBulidAdvice(advice, member, adviceDefinitionFactory);
        }

        protected bool TryBulidAdvice<TBuildMember, TAdvice>(TAdvice advice, TBuildMember member, Func<TAdvice, TBuildMember, IAdviceDefinition> adviceDefinitionFactory)
            where TAdvice : AdviceAttribute
            where TBuildMember : MemberInfo {

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
