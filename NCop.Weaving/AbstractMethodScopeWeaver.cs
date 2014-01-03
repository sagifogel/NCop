using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
	public abstract class AbstractMethodScopeWeaver : IMethodScopeWeaver, IHasWeavingSettings
	{
		private readonly IWeavingSettings weavingSettings = null;

		public AbstractMethodScopeWeaver(IWeavingSettings weavingSettings) {
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

		public abstract ILGenerator Weave(ILGenerator ilGenerator);
	}
}
