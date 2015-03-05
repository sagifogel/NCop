
namespace NCop.Aspects.Weaving.Expressions
{
    public interface IPropertyExpressionBuilder : IBindingTypeReflectorBuilder
    {
        void SetSetExpression(IAspectExpression aspectExpression);
        void SetGetExpression(IAspectExpression aspectExpression);
    }
}
