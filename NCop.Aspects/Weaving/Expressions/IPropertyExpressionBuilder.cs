
namespace NCop.Aspects.Weaving.Expressions
{
    public interface IPropertyExpressionBuilder : IBindingTypeReflectorBuilder
    {
        void SetSetExpression(IAspectExpression setAspectExpression);
        void SetGetExpression(IAspectExpression getAspectExpression);
    }
}
