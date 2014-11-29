using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Core
{
	public class MethodMapper : IMethodMapper
	{
		private readonly List<IMethodMap> mappedMethods = null;
		
		public MethodMapper(ITypeMap typeMap) {
			Func<MethodInfo, bool> methodPredicate = (methodInfo) => {
				return !methodInfo.IsSpecialName;
			};

			var mapped = typeMap.Select(map => new {
				map.ContractType,
				map.ImplementationType,
				ContractMethods = map.ContractType.GetMethods().Where(methodPredicate),
				ImplMethods = map.ImplementationType.GetMethods().ToSet(methodPredicate),
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

			mappedMethods = mappedMethodsEnumerable.Cast<IMethodMap>()
												   .ToList();
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
