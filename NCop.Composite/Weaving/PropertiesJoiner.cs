using NCop.Aspects.Aspects;
using NCop.Core;
using NCop.Mixins.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core.Extensions;
using System.Collections;

namespace NCop.Composite.Weaving
{
    internal class PropertiesJoiner : AbstractMethodJoiner
    {
        internal PropertiesJoiner(IMixinsMap mixinsMap) {
            var joined = mixinsMap.Select(mixin => new {
                ContractType = mixin.ContractType,
                ImplementationType = mixin.ImplementationType,
                ContractMethods = ResolveProperties(mixin.ContractType),
                ImplMethods = ResolveProperties(mixin.ImplementationType).ToSet()
            });

            Values = joined.SelectMany(join => {
                var methods = join.ContractMethods;

                return methods.Select(method => {
                    var result = method.SelectFirst(join.ImplMethods,
                                                   (c, impl) => MethodMatch(c, impl),
                                                   (c, impl) => impl);

                    return Tuple.Create(result, join.ImplementationType, join.ContractType);
                });
            });
        }

        private static IEnumerable<MethodInfo> ResolveProperties(Type type) {
            return type.GetProperties()
                       .SelectMany(property => new[] { 
                            property.GetGetMethod(),
                            property.GetSetMethod()
                       });
        }
    }
}
