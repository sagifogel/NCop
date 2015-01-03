using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public abstract class AbstractMethodScopeWeaver : IMethodScopeWeaver, IWeavingSettings
    {
        private readonly IWeavingSettings weavingSettings = null;

        protected AbstractMethodScopeWeaver(MethodInfo methodInfo, IWeavingSettings weavingSettings) {
            this.MethodInfo = methodInfo;
            this.weavingSettings = weavingSettings;
        }

        public Type ContractType {
            get {
                return weavingSettings.ContractType;
            }
        }

        public MethodInfo MethodInfo { get; private set; }

        public ITypeDefinition TypeDefinition {
            get {
                return weavingSettings.TypeDefinition;
            }
        }

        public abstract void Weave(ILGenerator ilGenerator);
    }
}
