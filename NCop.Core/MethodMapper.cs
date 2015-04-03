using NCop.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Core
{
    public class MethodMapper : IMethodMapper
    {
        private readonly List<IMethodMap> mappedMethods = null;

        public MethodMapper(ITypeMap typeMap) {
            Func<MethodInfo, bool> methodPredicate = methodInfo => !methodInfo.IsSpecialName;

            var mapped = typeMap.Select(map => new {
                map.ContractType,
                map.ImplementationType,
                ContractMethods = map.ContractType.GetPublicMethods().Where(methodPredicate),
                ImplMethods = map.ImplementationType.GetPublicMethods().ToSet(methodPredicate),
            });

            var mappedMethodsEnumerable = mapped.SelectMany(map => {
                var methods = map.ContractMethods;

                return methods.Select(method => {
                    var match = method.SelectFirst(map.ImplMethods,
                                                  (c, impl) => c.IsMatchedTo(impl),
                                                  (c, impl) => new {
                                                      ImplMethod = impl,
                                                      ContractMethod = c
                                                  });

                    return new MethodMap(map.ContractType,
                                         map.ImplementationType,
                                         match.ContractMethod,
                                         match.ImplMethod);
                });
            });

            mappedMethods = mappedMethodsEnumerable.ToListOf<IMethodMap>();
        }

        public IEnumerator<IMethodMap> GetEnumerator() {
            return mappedMethods.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public int Count {
            get {
                return mappedMethods.Count;
            }
        }
    }
}
