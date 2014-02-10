using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorArgumentsWeaver : IArgumentsWeaver
    {
        private readonly MethodInfo methodInfoImpl = null;
        private readonly IArgumentsWeavingSettings argumentWeavingSettings = null;
        private readonly MethodDecoratorByRefArgumentsStoreWeaver byRefArgumentsStoreWeaver = null;

        internal MethodDecoratorArgumentsWeaver(MethodInfo methodInfoImpl, IArgumentsWeavingSettings argumentWeavingSettings, MethodDecoratorByRefArgumentsStoreWeaver byRefArgumentsStoreWeaver) {
            this.methodInfoImpl = methodInfoImpl;
            this.argumentWeavingSettings = argumentWeavingSettings;
            this.byRefArgumentsStoreWeaver = byRefArgumentsStoreWeaver;
        }

        public void Weave(ILGenerator ilGenerator) {
            Type aspectArgsType = null;
            Type[] actualParameters = null;
            var argumentTypes = argumentWeavingSettings.ArgumentType.GetGenericArguments();
            var @params = new Type[argumentTypes.Length - 1];
            var methodImplParameters = methodInfoImpl.GetParameters();

            if (argumentWeavingSettings.IsFunction) {
                @params = new Type[argumentTypes.Length - 1];
                Array.Copy(argumentTypes, 0, @params, 0, argumentTypes.Length - 1);
            }
            else {
                @params = argumentTypes;
            }

            actualParameters = @params.Skip(1).ToArray();
            aspectArgsType = actualParameters.ToAspectArgumentContract(argumentWeavingSettings.IsFunction);

            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);

            methodImplParameters.ForEach((param) => {
                int argPosition = param.Position + 1;

                if (byRefArgumentsStoreWeaver.Contains(argPosition)) {
                    byRefArgumentsStoreWeaver.EmitLoadLocalAddress(ilGenerator, argPosition);
                }
                else {
                    var property = aspectArgsType.GetProperty("Arg{0}".Fmt(argPosition));

                    ilGenerator.EmitLoadArg(2);
                    ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                }
            });
        }
    }
}
