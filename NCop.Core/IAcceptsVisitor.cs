
namespace NCop.Core
{
    public interface IAcceptsVisitor<in TVisitor, out TResult>
    {
        TResult Accept(TVisitor visitor);
    }
}
