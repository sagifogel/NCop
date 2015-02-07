using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public class AspectMethodWeaver : IMethodWeaver
    {
        protected readonly MethodInfo method = null;
        private readonly IMethodEndWeaver methodEndWeaver = null;
        private readonly IMethodScopeWeaver methodScopeWeaver = null;
        private readonly IMethodSignatureWeaver methodSignatureWeaver = null;

        public AspectMethodWeaver(MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            IAspectExpression aspectExpression = null;
            var aspectExpressionBuilder = new AspectExpressionTreeBuilder(aspectDefinitions);

            this.method = method;
            methodEndWeaver = new MethodEndWeaver();
            aspectExpression = aspectExpressionBuilder.Build();
            methodScopeWeaver = aspectExpression.Reduce(aspectWeavingSettings);
            methodSignatureWeaver = new MethodSignatureWeaver(aspectWeavingSettings.WeavingSettings.TypeDefinition);
        }

        public MethodBuilder DefineMethod() {
            return methodSignatureWeaver.Weave(method);
        }

        public IMethodEndWeaver MethodEndWeaver {
            get {
                return methodEndWeaver;
            }
        }

        public void WeaveEndMethod(ILGenerator ilGenerator) {
            methodEndWeaver.Weave(method, ilGenerator);
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
