
namespace NCop.Aspects.Engine
{
    public interface IAcceptsVisitor<in TVisitor, out TResult>
    {
        TResult Accept(TVisitor visitor);
    }
}
