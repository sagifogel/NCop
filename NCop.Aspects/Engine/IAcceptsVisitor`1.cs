
namespace NCop.Aspects.Engine
{
    public interface IAcceptsVisitor<in TVisitor>
    {
        void Accept(TVisitor visitor);
    }
}
