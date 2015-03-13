using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public abstract class AbstractMethodScopeWeaver : IMethodScopeWeaver, IWeavingSettings
    {
        private readonly IWeavingSettings weavingSettings = null;

        protected AbstractMethodScopeWeaver(MethodInfo method, IWeavingSettings weavingSettings) {
            Method = method;
            this.weavingSettings = weavingSettings;
        }

        public Type ContractType {
            get {
                return weavingSettings.ContractType;
            }
        }

        public MethodInfo Method { get; private set; }

        public ITypeDefinition TypeDefinition {
            get {
                return weavingSettings.TypeDefinition;
            }
        }

        public abstract void Weave(ILGenerator ilGenerator);
    }
}
