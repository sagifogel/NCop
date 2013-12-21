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
        private BindingSettings bindingSettings = null;
        private readonly IAspectWeaver nestedWeaver = null;
        private readonly IAspectWeavingSettings settings = null;
        private readonly IAspectDefinition aspectDefinition = null;

        internal AspectWeaverWithBinding(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeavingSettings settings) {
            this.settings = settings;
            this.aspectDefinition = aspectDefinition;
            bindingSettings = CreateSettings();

            if (expression.Is<AspectDecoratorExpression>()) {
                var methodDecoratorBindingWeaver = new MethodDecoratorBindingWeaver(bindingSettings, expression.Reduce(settings));
                weavedType = methodDecoratorBindingWeaver.Weave();
            }
            else {
                var withWeavedType = expression.Reduce(settings) as IWithFieldAspectWeaver;
                weavedType = withWeavedType.WeavedType;
            }
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings settings) {
            return new MethodInterceptionAspectWeaver(nestedWeaver, aspectDefinition, bindingSettings, weavedType);
        }

        private BindingSettings CreateSettings() {
            var aspectArgumentType = aspectDefinition.GetArgumentType();
            var genericArguments = settings.ArgumentsWeaver.ArgumentType.GetGenericArguments();

            var bindingSettings = new BindingSettings {
                ArgumentsWeaver = settings.ArgumentsWeaver,
                WeavingSettings = settings.WeavingSettings,
                AspectArgsMapper = settings.AspectArgsMapper
            };

            if (settings.ArgumentsWeaver.IsFunction) {
                bindingSettings.BindingType = aspectArgumentType.MakeGenericFunctionBinding(genericArguments);
            }
            else {
                bindingSettings.BindingType = aspectArgumentType.MakeGenericActionBinding(genericArguments);
            }

            return bindingSettings;
        }
    }
}
