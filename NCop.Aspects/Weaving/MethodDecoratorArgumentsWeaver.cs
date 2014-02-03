using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorArgumentsWeaver : IArgumentsWeaver
    {
        private readonly IArgumentsWeavingSettings argumentWeavingSettings = null;

        internal MethodDecoratorArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings) {
            this.argumentWeavingSettings = argumentWeavingSettings;
        }

        public void Weave(ILGenerator ilGenerator) {
            Type aspectArgsType = null;
            Type[] actualParameters = null;
            Type[] argumentTypes = argumentWeavingSettings.ArgumentType.GetGenericArguments();
            Type[] @params = new Type[argumentTypes.Length - 1];

            if (argumentWeavingSettings.IsFunction) {
                @params = new Type[argumentTypes.Length - 1];
                Array.Copy(argumentTypes, 0, @params, 0, argumentTypes.Length - 1);
            }
            else {
                @params = argumentTypes;
            }

            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);
            actualParameters = @params.Skip(1).ToArray();
            aspectArgsType = actualParameters.ToAspectArgument(argumentWeavingSettings.IsFunction);

            actualParameters.ForEach(1, (parameter, i) => {
                var property = argumentWeavingSettings.ArgumentType.GetProperty("Arg{0}".Fmt(i));

                ilGenerator.EmitLoadArg(2);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });
        }
    }
}
