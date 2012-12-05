using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public class MethodAspectDefinition : AspectDefinition
    {
        public MethodAspectDefinition(IAspectProvider aspectProvider, JoinPointMetadata joinPointMetadata)
            : base(aspectProvider, joinPointMetadata) {
        }

        protected override void BulidAdvices() {
            Aspect.GetType()
                  .GetMethods(BindingFlags.Instance | BindingFlags.Public)
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
