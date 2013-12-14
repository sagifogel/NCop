using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AspectsWeaver : IAspcetWeaver
    {
        private IAspcetWeaver weaver = null;
        private readonly IAspectExpression expression = null;
        private readonly IAspectWeavingSettings settings = null;
        private readonly AspectsAttributeWeaver aspectAttributeWeaver = null;

        public AspectsWeaver(IAspectExpression expression, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            this.expression = expression;
            aspectAttributeWeaver = new AspectsAttributeWeaver(aspectDefinitions);
            this.settings = new AspectWeavingSettings(aspectWeavingSettings.WeavingSettings, aspectWeavingSettings.ArgumentsWeaver, aspectAttributeWeaver);
        }

        public ILGenerator Weave(ILGenerator ilGenerator) {
            aspectAttributeWeaver.Weave();
            weaver = expression.Reduce(settings);

            return weaver.Weave(ilGenerator);
        }
    }
}
