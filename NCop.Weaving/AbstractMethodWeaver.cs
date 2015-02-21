using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public abstract class AbstractMethodWeaver : IMethodWeaver, IWeavingSettings
    {
        protected readonly MethodInfo methodInfo = null;
        private readonly IWeavingSettings weavingSettings = null;

        protected AbstractMethodWeaver(MethodInfo methodInfo, IWeavingSettings weavingSettings) {
            this.methodInfo = methodInfo;
            this.weavingSettings = weavingSettings;
        }

        public Type ContractType {
            get {
                return weavingSettings.ContractType;
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
            return MethodDefintionWeaver.Weave(methodInfo);
        }

        public virtual void WeaveMethodScope(ILGenerator ilGenerator) {
            MethodScopeWeaver.Weave(ilGenerator);
        }

        public virtual void WeaveEndMethod(ILGenerator ilGenerator) {
            MethodEndWeaver.Weave(methodInfo, ilGenerator);
        }
    }
}
