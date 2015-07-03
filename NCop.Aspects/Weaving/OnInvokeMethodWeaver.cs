using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public class OnInvokeMethodWeaver : IMethodWeaver
    {
        private readonly IMethodEndWeaver methodEndWeaver = null;
        private readonly IMethodScopeWeaver methodScopeWeaver = null;
        private readonly IMethodSignatureWeaver methodSignatureWeaver = null;

        public OnInvokeMethodWeaver(EventInfo @event, IAspectTypeDefinition typeDefinition, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            methodEndWeaver = new MethodEndWeaver();
            methodSignatureWeaver = new OnEventInvokeMethodSignatureWeaver(@event, typeDefinition);
            methodScopeWeaver = new OnInvokeMethodScopeWeaver(typeDefinition, aspectDefinitions, aspectWeavingSettings);
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
