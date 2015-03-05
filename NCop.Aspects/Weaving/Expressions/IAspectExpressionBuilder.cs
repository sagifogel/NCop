
namespace NCop.Aspects.Weaving.Expressions
{
    public interface IAspectExpressionBuilder
    {
        IAspectExpression Build(IAspectExpression aspectExpression = null);
    }
}
