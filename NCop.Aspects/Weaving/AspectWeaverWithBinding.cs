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
		private readonly IAspectWeaver aspectWeaver = null;
		private readonly IAspectWeavingSettings settings = null;
		private readonly IAspectDefinition aspectDefinition = null;

		internal AspectWeaverWithBinding(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeavingSettings settings) {
			this.settings = settings;
			this.aspectDefinition = aspectDefinition;

			if (expression.Is<AspectDecoratorExpression>()) {
				var bindingSettings = aspectDefinition.ToBindingSettings(settings.WeavingSettings.MethodInfoImpl.DeclaringType);
				var methodDecoratorBindingWeaver = new MethodDecoratorBindingWeaver(bindingSettings, settings, expression.Reduce(settings));

				aspectWeaver = expression.Reduce(settings);
				weavedType = methodDecoratorBindingWeaver.Weave();
			}
			else {
				IWithFieldAspectWeaver withWeavedType = null;

				aspectWeaver = expression.Reduce(settings);
				withWeavedType = aspectWeaver as IWithFieldAspectWeaver;
				weavedType = withWeavedType.WeavedType;
			}
		}

		public IAspectWeaver Reduce(IAspectWeavingSettings settings) {
			var topAspectWeaver = aspectWeaver.Is<TopAspectWeaver>();

			return new MethodInterceptionAspectWeaver(aspectDefinition, settings, weavedType, topAspectWeaver);
		}
	}
}
