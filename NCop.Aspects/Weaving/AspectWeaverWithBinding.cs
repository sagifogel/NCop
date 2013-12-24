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
		private readonly bool topAspect = false;
		private readonly FieldInfo weavedType = null;
		private readonly IAspectWeavingSettings settings = null;
		private readonly IAspectDefinition aspectDefinition = null;

		internal AspectWeaverWithBinding(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeavingSettings settings, bool topAspect = false) {
			BindingSettings bindingSettings = null;

			this.settings = settings;
			this.topAspect = topAspect;
			this.aspectDefinition = aspectDefinition;
			bindingSettings = aspectDefinition.ToBindingSettings(settings.WeavingSettings.MethodInfoImpl.DeclaringType);

			if (expression.Is<AspectDecoratorExpression>()) {
				var methodDecoratorBindingWeaver = new MethodDecoratorBindingWeaver(bindingSettings, settings, expression.Reduce(settings));

				weavedType = methodDecoratorBindingWeaver.Weave();
			}
			else {
				IMethodBindingWeaver bindingWeaver = null;
				var aspectType = aspectDefinition.Aspect.AspectType;
				var aspectWeaver = expression.Reduce(settings);
				var typeReflector = aspectWeaver as ITypeReflector;

				bindingSettings.BindingsDependency = typeReflector.WeavedType;
				bindingWeaver = new OnMethodInterceptionBindingWeaver(aspectType, bindingSettings, settings, aspectWeaver);
				weavedType = bindingWeaver.Weave();
			}
		}

		public IAspectWeaver Reduce(IAspectWeavingSettings settings) {
			return new MethodInterceptionAspectWeaver(aspectDefinition, settings, weavedType);
		}
	}
}
