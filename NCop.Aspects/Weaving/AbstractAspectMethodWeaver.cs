using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public abstract class AbstractAspectMethodWeaver : IMethodWeaver
    {
        protected readonly MethodInfo method = null;
        protected readonly IMethodEndWeaver methodEndWeaver = null;
        protected IMethodSignatureWeaver methodSignatureWeaver = null;
        protected readonly IMethodScopeWeaver methodScopeWeaver = null;

        protected AbstractAspectMethodWeaver(MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            IAspectExpression aspectExpression = null;
            var aspectExpressionBuilder = new AspectExpressionTreeBuilder(aspectDefinitions);

            this.method = method;
            methodEndWeaver = new MethodEndWeaver();
            aspectExpression = aspectExpressionBuilder.Build();
            methodScopeWeaver = aspectExpression.Reduce(aspectWeavingSettings);
        }

        public virtual MethodBuilder DefineMethod() {
            return MethodBuilder = methodSignatureWeaver.Weave(method);
        }

        public IMethodEndWeaver MethodEndWeaver {
            get { return methodEndWeaver; }
        }

        public void WeaveEndMethod(ILGenerator ilGenerator) {
            methodEndWeaver.Weave(ilGenerator);
        }

        public IMethodScopeWeaver MethodScopeWeaver {
            get { return methodScopeWeaver; }
        }

        public IMethodSignatureWeaver MethodDefintionWeaver {
            get {
                return methodSignatureWeaver;
            }
        }

        public MethodBuilder MethodBuilder { get; private set; }

        public void WeaveMethodScope(ILGenerator ilGenerator) {
            methodScopeWeaver.Weave(ilGenerator);
        }
    }
}
