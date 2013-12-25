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
    internal class AspectWeaverWithBinding : IAspectExpression, ITypeReflector
    {
        private readonly IAspectDefinition aspectDefinition = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;

        internal AspectWeaverWithBinding(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings) {
            BindingSettings bindingSettings = null;

            this.aspectDefinition = aspectDefinition;
            this.aspectWeavingSettings = aspectWeavingSettings;
            bindingSettings = aspectDefinition.ToBindingSettings(aspectWeavingSettings.WeavingSettings.MethodInfoImpl.DeclaringType);
            bindingSettings.LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;

            if (expression.Is<AspectDecoratorExpression>()) {
                var methodDecoratorBindingWeaver = new MethodDecoratorBindingWeaver(bindingSettings, aspectWeavingSettings, expression.Reduce(aspectWeavingSettings));

                WeavedType = methodDecoratorBindingWeaver.Weave();
            }
            else {
                IAspectWeaver aspectWeaver = null;
                ITypeReflector typeReflector = null;
                IMethodBindingWeaver bindingWeaver = null;
                var aspectType = aspectDefinition.Aspect.AspectType;
                var localBuilderRepository = new LocalBuilderRepository();
                var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                    settings.LocalBuilderRepository = localBuilderRepository;
                });

                aspectWeaver = expression.Reduce(clonedSettings);
                typeReflector = aspectWeaver as ITypeReflector;
                bindingSettings.BindingsDependency = typeReflector.WeavedType;
                bindingSettings.LocalBuilderRepository = localBuilderRepository;
                bindingWeaver = new OnMethodInterceptionBindingWeaver(aspectType, bindingSettings, clonedSettings, aspectWeaver);
                WeavedType = bindingWeaver.Weave();
            }
        }

        public FieldInfo WeavedType { get; private set; }

        public IAspectWeaver Reduce(IAspectWeavingSettings settings) {
            return new MethodInterceptionAspectWeaver(aspectDefinition, settings, WeavedType);
        }
    }
}
