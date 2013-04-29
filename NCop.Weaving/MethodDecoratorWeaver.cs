using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class MethodDecoratorWeaver : AbstractMethodWeaver
    {
        public MethodDecoratorWeaver(MethodInfo methodInfo, Type decoratedType)
            : base(methodInfo, decoratedType) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodDefintionWeaver = new MethodSignatureWeaver();
            MethodScopeWeaver = new MethodDecoratorScopeWeaver(methodInfo, decoratedType);
        }

        public override MethodBuilder DefineMethod(ITypeDefinition typeDefinition) {
            return MethodDefintionWeaver.Weave(MethodInfo, typeDefinition);
        }

        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            return MethodScopeWeaver.Weave(ilGenerator, typeDefinition);
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
            MethodEndWeaver.Weave(MethodInfo, ilGenerator);
        }
    }
}
