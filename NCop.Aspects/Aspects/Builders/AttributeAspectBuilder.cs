using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Engine;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using NCop.Aspects.JoinPoints;

namespace NCop.Aspects.Aspects.Builders
{
    public class AttributeAspectBuilder : IAspectBuilder
    {
        private readonly MethodInfo _methodInfo = null;
        private AspectDefinitionBuilder _builder = AspectDefinitionBuilder.Instance;

        public AttributeAspectBuilder(MethodInfo methodInfo) {
            _methodInfo = methodInfo;
        }

        public IAspectDefinitionCollection Build() {
            return new AspectDefinitionCollection(BuildInternal());
        }

        private IEnumerable<IAspectDefinition> BuildInternal() {
            return GetAspectMetadata().Select(aspectTuple => {
                Type aspectType = aspectTuple.Item1;

                Func<IAspectProvider> provider = () => {
                    var type = aspectType;
                    return new AttributeAspectProvider(type);
                };

                return _builder.BuildDefinition(aspectType, provider, aspectTuple.Item2);
            });
        }

        public IEnumerable<Tuple<Type, JoinPointMetadata>> GetAspectMetadata() {
            var aspectAttributes = new {
                JoinPoint = new MethodJoinPointMetadata(_methodInfo) as JoinPointMetadata,
                Attributes = _methodInfo.GetCustomAttributes<AspectAttribute>(true)
            };

            return aspectAttributes.Attributes.Select(a => {
                return Tuple.Create(a.GetType(), aspectAttributes.JoinPoint);
            });
        }
    }
}
