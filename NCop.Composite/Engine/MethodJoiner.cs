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
using NCop.Core.Engine;

namespace NCop.Composite.Engine
{
	internal class MethodJoiner : IMethodJoiner, IGroupedMethodsCollection
	{
		private readonly List<JoinedMethods> joinedMethods = null;

		internal MethodJoiner(Type compositeType, IMixinsMap mixinsMap) {
			Func<MethodInfo, bool> methodPredicate = (methodInfo) => {
				return !methodInfo.IsSpecialName;
			};

			var joined = mixinsMap.Select(mixin => new {
				ContractType = mixin.ContractType,
				ImplementationType = mixin.ImplementationType,
				ContractMethods = mixin.ContractType.GetMethods().Where(methodPredicate),
				ImplMethods = mixin.ImplementationType.GetMethods().ToSet(methodPredicate),
				CompositeMethods = compositeType.GetMethods()
			});

			var joinedMethodsEnumerable = joined.SelectMany(join => {
				var methods = join.ContractMethods;

				return methods.Select(method => {
					var match = method.SelectFirst(join.ImplMethods,
												  (c, impl) => c.IsMatchedTo(impl),
												  (c, impl) => new {
													  ImplMethod = impl,
													  ContractMethod = c
												  });

					var compositeMethod = join.CompositeMethods.FirstOrDefault(m => {
						return m.IsMatchedTo(match.ContractMethod);
					});

					return new JoinedMethods(join.ContractType,
											 join.ImplementationType,
											 compositeMethod ?? match.ContractMethod,
											 match.ImplMethod,
											 match.ContractMethod);
				});
			});

			joinedMethods = joinedMethodsEnumerable.ToList();
		}
		
		public IEnumerator<JoinedMethods> GetEnumerator() {
			return joinedMethods.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public int Count {
			get { 
				return joinedMethods.Count;
			}
		}

		IEnumerator<IGroupedMethods> IEnumerable<IGroupedMethods>.GetEnumerator() {
			return GetEnumerator();
		}
	}
}