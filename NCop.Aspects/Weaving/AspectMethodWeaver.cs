using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class AspectMethodWeaver : IMethodWeaver
    {
        private readonly MethodInfo methodInfo = null;
        private readonly IMethodEndWeaver methodEndWeaver = null;
        private readonly IMethodScopeWeaver methodScopeWeaver = null;
        private readonly IMethodSignatureWeaver methodSignatureWeaver = null;

        public AspectMethodWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            var aspectExpression = new AspectExpressionTreeBuilder(aspectDefinitions).Build();

            methodEndWeaver = new MethodEndWeaver();
            methodInfo = aspectDefinitions.First().Member;
            methodScopeWeaver = aspectExpression.Reduce(aspectWeavingSettings);
            methodSignatureWeaver = new MethodSignatureWeaver(aspectWeavingSettings.WeavingSettings.TypeDefinition);
        }

        public MethodBuilder DefineMethod() {
            return methodSignatureWeaver.Weave(methodInfo);
        }

        public IMethodEndWeaver MethodEndWeaver {
            get {
                return methodEndWeaver;
            }
        }

        public void WeaveEndMethod(ILGenerator ilGenerator) {
            methodEndWeaver.Weave(methodInfo, ilGenerator);
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
