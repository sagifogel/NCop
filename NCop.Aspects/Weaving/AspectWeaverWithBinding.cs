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
        private readonly IAspectWeaver aspectWeaver = null;
        private readonly IAspectWeavingSettings settings = null;
        private readonly IAspectDefinition aspectDefinition = null;

        internal AspectWeaverWithBinding(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeavingSettings settings, bool topAspect = false) {
            this.settings = settings;
            this.aspectDefinition = aspectDefinition;
            this.topAspect = topAspect;

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

        public IAspectWeaver Reduce(IAspectWeavingSettings settings, bool topAspect = false) {
            return new MethodInterceptionAspectWeaver(aspectDefinition, settings, weavedType, this.topAspect);
        }
    }
}
