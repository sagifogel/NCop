using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorByRefArgumentsStoreWeaver : AbstractBindingByRefArgumentsWeaver
    {
        internal MethodDecoratorByRefArgumentsStoreWeaver(Type aspectArgumentType, MethodInfo methodInfoImpl, ILocalBuilderRepository localBuilderRepository)
            : base(aspectArgumentType,  methodInfoImpl, localBuilderRepository) {
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadArg(2);
        }
    }
}
