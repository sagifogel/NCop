using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class CompositeMethodWeaver : AbstractMethodWeaver
    {
        internal CompositeMethodWeaver(IEnumerable<IAspectDefinition> aspectDefinition, MethodInfo methodInfoImpl, Type implementationType, Type contractType)
            : base(methodInfoImpl, implementationType, contractType) {
            MethodDefintionWeaver = new MethodSignatureWeaver();
            MethodScopeWeaver = new MethodDecoratorScopeWeaver(methodInfoImpl, implementationType, contractType);
            MethodEndWeaver = new MethodEndWeaver();
        }

        public override MethodBuilder DefineMethod(ITypeDefinition typeDefinition) {
            return MethodDefintionWeaver.Weave(MethodInfoImpl, typeDefinition);
        }

        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            return MethodScopeWeaver.Weave(ilGenerator, typeDefinition);
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
            MethodEndWeaver.Weave(MethodInfoImpl, ilGenerator);
        }
    }
}
