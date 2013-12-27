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
		private readonly FieldInfo bindingsDependency = null;

		internal AspectArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
			: base(argumentWeavingSettings, aspectWeavingSettings) {
			bindingsDependency = argumentWeavingSettings.BindingsDependency;
		}

		public override LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters) {
			var aspectRepository = aspectWeavingSettings.AspectRepository;
			var argsImplLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
			var ctorInterceptionArgs = ArgumentType.GetConstructors().First();
			var bindingLocalBuilder = LocalBuilderRepository.Get(bindingsDependency.FieldType);

			ilGenerator.Emit(OpCodes.Ldsfld, bindingsDependency);
			ilGenerator.EmitStoreLocal(bindingLocalBuilder);
			ilGenerator.EmitLoadArg(1);
			ilGenerator.Emit(OpCodes.Ldind_Ref);
			ilGenerator.EmitLoadLocal(bindingLocalBuilder);
			ilGenerator.EmitLoadArg(2);

			parameters.Skip(1)
					  .ForEach(1, (parameter, i) => {
						  var property = ArgumentType.GetProperty("Arg{0}".Fmt(i));

						  ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
					  });

			ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
			ilGenerator.EmitStoreLocal(argsImplLocalBuilder);

			return argsImplLocalBuilder;
		}
	}
}
