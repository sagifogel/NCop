using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorByRefArgumentsStoreWeaver : AbstractBindingByRefArgumentsWeaver
    {
        internal MethodDecoratorByRefArgumentsStoreWeaver(Type aspectArgumentType, MethodInfo method, ILocalBuilderRepository localBuilderRepository)
            : base(aspectArgumentType,  method, localBuilderRepository) {
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadArg(2);
        }
    }
}
