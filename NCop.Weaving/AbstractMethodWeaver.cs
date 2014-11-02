using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
	public abstract class AbstractMethodWeaver : IMethodWeaver, IMethodWeavingSettings
	{
		private readonly IMethodWeavingSettings weavingSettings = null;

		protected AbstractMethodWeaver(IMethodWeavingSettings weavingSettings) {
			this.weavingSettings = weavingSettings;
		}

		public Type ContractType {
			get {
				return weavingSettings.ContractType;
			}
		}

		public Type ImplementationType {
			get {
				return weavingSettings.ImplementationType;
			}
		}

		public MethodInfo MethodInfoImpl {
			get {
				return weavingSettings.MethodInfoImpl;
			}
		}

		public ITypeDefinition TypeDefinition {
			get {
				return weavingSettings.TypeDefinition;
			}
		}

		public IMethodEndWeaver MethodEndWeaver { get; protected set; }

		public IMethodScopeWeaver MethodScopeWeaver { get; protected set; }

		public IMethodSignatureWeaver MethodDefintionWeaver { get; protected set; }

		public virtual MethodBuilder DefineMethod() {
			return MethodDefintionWeaver.Weave(MethodInfoImpl);
		}

		public virtual ILGenerator WeaveMethodScope(ILGenerator ilGenerator) {
			return MethodScopeWeaver.Weave(ilGenerator);
		}

		public virtual void WeaveEndMethod(ILGenerator ilGenerator) {
			MethodEndWeaver.Weave(MethodInfoImpl, ilGenerator);
		}
	}
}
