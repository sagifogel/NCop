using NCop.Aspects.Advices;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects
{
    public class AspectDefinition : IAspectDefinition
    {
        protected readonly AdviceDefinitionCollection advices = null;

        public AspectDefinition(IAspect aspect) {
            Aspect = aspect;
            advices = new AdviceDefinitionCollection();
            
            BulidAdvices();
        }

        public IAspect Aspect { get; private set; }

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
    }
}
