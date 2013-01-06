using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Extensions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingOnMethodBoundaryAspectExpression : AbstractAspectExpression
    {
        internal BindingOnMethodBoundaryAspectExpression(IAspectExpression expression, IAspectDefinition aspectDefinition)
            : base(expression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings ) {
            var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            var nestedWeaver = expression.Reduce(clonedSettings); 
            
            return new BindingOnMethodBoundaryAspectWeaver(nestedWeaver, aspectDefinition, aspectWeavingSettings);
        }
    }
}
