using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.JoinPoints;
using NCop.Core.Extensions;
using System.Reflection;
using System.Linq;

namespace NCop.Aspects.Aspects
{
    public class MethodAspectDefinition : AspectDefinition
    {
        public MethodAspectDefinition(IAspectProvider aspectProvider, JoinPointMetadata joinPointMetadata, int aspectPriority)
            : base(aspectProvider, joinPointMetadata, aspectPriority) {
        }

        protected override void BulidAdvices() {
            Aspect.GetType()
                  .GetOverridenMethods()
                  .ForEach(method => {
                      method.GetCustomAttributes<AdviceAttribute>(true)
                            .ForEach(a => {
                                var advice = a.Accept(AdviceVisitor);

                                AdviceCollection.Add(advice);
                            });
                  });
        }
    }
}
