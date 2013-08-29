using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core;

namespace NCop.Composite.Engine
{
	public class JoinedMethods : IGroupedMethods
	{
		private readonly ISet<MethodInfo> methods = new HashSet<MethodInfo>();

		public JoinedMethods(Type contractType, Type implementationType, MethodInfo compositeMethod, MethodInfo contractMethod, MethodInfo implementationMethod) {
			ContractType = contractType;
			ImplementationType = implementationType;
			methods.Add(ContractMethod = contractMethod);
			methods.Add(CompositeMethod = compositeMethod);
			methods.Add(ImplementationMethod = implementationMethod);
		}

		public Type ContractType { get; private set; }
		public Type ImplementationType { get; private set; }
		public MethodInfo ContractMethod { get; private set; }
		public MethodInfo CompositeMethod { get; private set; }
		public MethodInfo ImplementationMethod { get; private set; }

		public MethodInfo GroupedByMethod {
			get {
				return ImplementationMethod;
			}
		}

		public int Count {
			get {
				return methods.Count;
			}
		}

		public IEnumerator<MethodInfo> GetEnumerator() {
			return methods.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
