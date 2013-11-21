using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using NCop.Aspects.Extensions;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Aspects
{
    internal abstract class AspectDefinition : IAspectDefinition, IAcceptsVisitor<IHasAspectExpression, AspectVisitor>
    {
        protected readonly AdviceDefinitionCollection advices = null;

        internal AspectDefinition(IAspect aspect) {
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

        protected virtual void BulidAdvices() {
            Aspect.AspectType
                  .GetOverridenMethods()
                  .ForEach(method => {
                      var advice = method.GetCustomAttribute<AdviceAttribute>(true);
                      var adviceDefinition = new AdviceDefinition(advice, method);

                      advices.Add(adviceDefinition);
                  });
        }

        public abstract IHasAspectExpression Accept(AspectVisitor visitor);
    }
}
