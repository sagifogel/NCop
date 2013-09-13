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
    public class MemberLevelAspectBuilder : IAspectBuilder
    {
		private readonly MemberInfo memberInfo = null;
        private AspectDefinitionBuilder builder = AspectDefinitionBuilder.Instance;

		public MemberLevelAspectBuilder(MemberInfo memberInfo) {
			this.memberInfo = memberInfo;
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

                return builder.BuildDefinition(aspectType, provider, aspectTuple.Item2);
            });
        }

        public IEnumerable<Tuple<Type, JoinPointMetadata>> GetAspectMetadata() {
            var aspectAttributes = new {
				JoinPoint = new MethodJoinPointMetadata(memberInfo) as JoinPointMetadata,
				Attributes = memberInfo.GetCustomAttributes<AspectAttribute>(true)
            };

            return aspectAttributes.Attributes.Select(a => {
                return Tuple.Create(a.GetType(), aspectAttributes.JoinPoint);
            });
        }
    }
}
