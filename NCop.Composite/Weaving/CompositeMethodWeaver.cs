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
        internal CompositeMethodWeaver(MethodInfo methodInfoImpl, Type implementationType, Type contractType, IMethodSignatureWeaver methodDefinitionWeaver, IEnumerable<IMethodWeaver> methodWeavers)
            : base(methodInfoImpl, implementationType, contractType) {
            MethodDefintionWeaver = methodDefinitionWeaver;
            MethodScopeWeaver = new MethodScopeWeaversQueue(methodWeavers.Select(weaver => weaver.MethodScopeWeaver));
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
