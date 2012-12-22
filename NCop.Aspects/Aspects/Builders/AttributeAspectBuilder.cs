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
    public class AttributeAspectBuilder : AbstractTypeVisitor<Tuple<Type, JoinPointMetadata>>, IAspectBuilder
    {
        private Type _type = null;
        private AspectDefinitionBuilder _builder = AspectDefinitionBuilder.Instance;

        public IAspectDefinitionCollection Build(Type type) {
            _type = type;
            return new AspectDefinitionCollection(BuildInternal());
        }

        private IEnumerable<IAspectDefinition> BuildInternal() {
            return Visit(_type).Select(aspectTuple => {
                Type aspectType = aspectTuple.Item1;

                Func<IAspectProvider> provider = () => {
                    var type = aspectType;
                    return new AttributeAspectProvider(type);
                };

                return _builder.BuildDefinition(aspectType, provider, aspectTuple.Item2);
            });
        }

        public override IEnumerable<Tuple<Type, JoinPointMetadata>> Visit(MethodInfo[] methods) {
            var aspectAttributes = methods.Select(method => {
                return new {
                    JoinPoint = new MethodJoinPointMetadata(method) as JoinPointMetadata,
                    Attributes = method.GetCustomAttributes<AspectAttribute>(true)
                };
            });

            return aspectAttributes.Where(aspect => !aspect.Attributes.IsNullOrEmpty())
                                   .SelectMany(aspect => {
                                       return aspect.Attributes.Select(a => {
                                           return Tuple.Create(a.GetType(), aspect.JoinPoint);
                                       });
                                   });
        }
    }
}
