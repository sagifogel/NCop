using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using System.Reflection;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class AspectWeaverWithBinding : IAspectExpression
	{
		private readonly FieldInfo weavedType = null;
		private readonly IAspectDefinition aspectDefinition = null;
		private readonly IAspectWeavingSettings settings = null;
		private readonly ILocalBuilderRepository localBuilderRepository = null;

		internal AspectWeaverWithBinding(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeavingSettings settings) {
			BindingSettings bindingSettings = null;

			this.settings = settings;
			this.aspectDefinition = aspectDefinition;
			bindingSettings = aspectDefinition.ToBindingSettings(settings.WeavingSettings.MethodInfoImpl.DeclaringType);
		
			if (expression.Is<AspectDecoratorExpression>()) {
				var methodDecoratorBindingWeaver = new MethodDecoratorBindingWeaver(bindingSettings, settings, expression.Reduce(settings));

				weavedType = methodDecoratorBindingWeaver.Weave();
			}
			else {
				IAspectWeaver aspectWeaver = null;
				ITypeReflector typeReflector = null;
				IMethodBindingWeaver bindingWeaver = null;
				var aspectType = aspectDefinition.Aspect.AspectType;
				localBuilderRepository = new LocalBuilderRepository();
				AspectWeavingSettings clonedSettings = settings.Clone();

				clonedSettings.LocalBuilderRepository = localBuilderRepository;
				aspectWeaver = expression.Reduce(clonedSettings);
				typeReflector = aspectWeaver as ITypeReflector;
				bindingSettings.BindingsDependency = typeReflector.WeavedType;
				bindingSettings.LocalBuilderRepository = localBuilderRepository;
				bindingWeaver = new OnMethodInterceptionBindingWeaver(aspectType, bindingSettings, clonedSettings, aspectWeaver);
				weavedType = bindingWeaver.Weave();
			}
		}

		public IAspectWeaver Reduce(IAspectWeavingSettings settings) {
			return new MethodInterceptionAspectWeaver(aspectDefinition, settings, weavedType);
		}
	}
}
