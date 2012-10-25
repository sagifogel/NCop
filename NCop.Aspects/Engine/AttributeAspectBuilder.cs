using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Engine;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Core.Extensions;

namespace NCop.Aspects.Framework
{
    public class AttributeAspectBuilder : AbstractVisitor<Type>, IAspectBuilder
    {
        private Type _type = null;

        public AttributeAspectBuilder(Type type) {
            _type = type;
        }

        public void Build() {

            Visit(_type).ForEach(aspectType => {
                var provider = new AttributeAspectProvider(aspectType);

                AspectsRepository.Instance.GetOrAdd(_type, provider);
            });
        }

        public override IEnumerable<Type> Visit(MethodInfo[] methods) {
            var aspectAttributes = methods.Select(metod => {
                return metod.GetCustomAttributes<AspectAttribute>(true);
            });

            return aspectAttributes.Where(attributes => !attributes.IsNullOrEmpty())
                                   .SelectMany(attributes => attributes.Select(a => a.GetType()));
        }
    }
}
