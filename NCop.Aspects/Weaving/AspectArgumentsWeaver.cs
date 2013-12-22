using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgumentsWeaver : AbstractAspectArgumentsWeaver
    {
		internal AspectArgumentsWeaver(Type argsType, Type[] parameters, IAspectWeavingSettings aspectWeavingSettings, ILocalBuilderRepository localBuilderRepository)
			: base(argsType, parameters, aspectWeavingSettings, localBuilderRepository) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
            FieldInfo weavedNestedBinding = null;
            var declaredLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            var ctorInterceptionArgs = ArgumentType.GetConstructors().First();
			var aspectRepository = aspectWeavingSettings.AspectRepository;
			
			weavedNestedBinding = aspectRepository.GetAspectFieldByType(null); 
            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);
            ilGenerator.Emit(OpCodes.Ldsfld, weavedNestedBinding);
            ilGenerator.EmitLoadArg(2);

            parameters.Skip(1)
                      .ForEach(2, (parameter, i) => {
                          var property = ArgumentType.GetProperty("Arg{0}".Fmt(i));

                          ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                      });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(declaredLocalBuilder);

            return declaredLocalBuilder;
        }
    }
}
