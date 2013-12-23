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
            BindingSettings bindingSettings = null;

            this.settings = settings;
            this.aspectDefinition = aspectDefinition;
            this.topAspect = topAspect;
            bindingSettings = aspectDefinition.ToBindingSettings(settings.WeavingSettings.MethodInfoImpl.DeclaringType);

            if (expression.Is<AspectDecoratorExpression>()) {
                var methodDecoratorBindingWeaver = new MethodDecoratorBindingWeaver(bindingSettings, settings, expression.Reduce(settings));

                aspectWeaver = expression.Reduce(settings);
                weavedType = methodDecoratorBindingWeaver.Weave();
            }
            else {
                var aspectType = aspectDefinition.Aspect.AspectType;
                var bindingWeaver = new OnMethodInterceptionBindingWeaver(aspectType, bindingSettings, settings, expression.Reduce(settings));
                
                weavedType = bindingWeaver.Weave();
            }
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings settings, bool topAspect = false) {
            return new MethodInterceptionAspectWeaver(aspectDefinition, settings, weavedType, this.topAspect);
        }
    }
}
