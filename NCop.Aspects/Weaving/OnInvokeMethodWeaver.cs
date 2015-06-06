using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public class OnInvokeMethodWeaver : IMethodWeaver
    {
        private readonly IMethodEndWeaver methodEndWeaver = null;
        private readonly IAspectTypeDefinition typeDefinition = null;
        private readonly IMethodScopeWeaver methodScopeWeaver = null;
        private readonly IMethodSignatureWeaver methodSignatureWeaver = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IAspectDefinitionCollection aspectDefinitions = null;

        public OnInvokeMethodWeaver(EventInfo @event, IAspectTypeDefinition typeDefinition, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            this.typeDefinition = typeDefinition;
            this.aspectDefinitions = aspectDefinitions;
            this.methodEndWeaver = new MethodEndWeaver();
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.methodSignatureWeaver = new OnInvokeMethodSignatureWeaver(@event, typeDefinition);
            this.methodScopeWeaver = new OnInvokeMethodScopeWeaver(typeDefinition, aspectDefinitions, aspectWeavingSettings);
        }

        public MethodBuilder DefineMethod() {
            return methodSignatureWeaver.Weave();
        }

        public IMethodEndWeaver MethodEndWeaver {
            get {
                return methodEndWeaver;
            }
        }

        public void WeaveEndMethod(ILGenerator ilGenerator) {
            methodEndWeaver.Weave(ilGenerator);
        }

        public IMethodScopeWeaver MethodScopeWeaver {
            get {
                return methodScopeWeaver;
            }
        }

        public IMethodSignatureWeaver MethodDefintionWeaver {
            get {
                return methodSignatureWeaver;
            }
        }

        public void WeaveMethodScope(ILGenerator ilGenerator) {
            methodScopeWeaver.Weave(ilGenerator);
        }
    }
}
