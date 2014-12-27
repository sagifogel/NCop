using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    public class AspectPropertyWeaver : AbstractMethodWeaver
    {
        public AspectPropertyWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectPropertyMethodWeavingSettings aspectWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            var aspectExpression = new AspectExpressionTreeBuilder(aspectDefinitions).Build();

            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = aspectExpression.Reduce(aspectWeavingSettings);
            MethodDefintionWeaver = new MethodSignatureWeaver(TypeDefinition);
        }
    }
}
