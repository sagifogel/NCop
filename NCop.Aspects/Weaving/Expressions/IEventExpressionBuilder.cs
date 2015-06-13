
namespace NCop.Aspects.Weaving.Expressions
{
    public interface IEventExpressionBuilder : IBindingTypeReflectorBuilder
    {
        void SetAddExpression(IAspectExpression addAspectExpression);
        void SetRemoveExpression(IAspectExpression removeAspectExpression);
        void SetInvokeExpression(IAspectExpression invokeAspectExpression);
    }
}
