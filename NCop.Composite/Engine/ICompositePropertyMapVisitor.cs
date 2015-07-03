
namespace NCop.Composite.Engine
{
    public interface ICompositePropertyMapVisitor
    {       
        void Visit(CompositeGetPropertyMap propertyMap);
        void Visit(CompositeSetPropertyMap propertyMap);
    }
}
