using NCop.Aspects.Advices;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects
{
    public class MethodAspectDefinition : AspectDefinition
    {
        public MethodAspectDefinition(IAspect aspect)
            : base(aspect) {
        }

        protected override void BulidAdvices() {
            Aspect.GetType()
                  .GetOverridenMethods()
                  .ForEach(method => {
                      method.GetCustomAttributes<AdviceAttribute>(true)
                            .ForEach(advice => {
                                var adviceDefinition = new AdviceDefinition(advice, method);

                                advices.Add(adviceDefinition);
                            });
                  });
        }
    }
}
