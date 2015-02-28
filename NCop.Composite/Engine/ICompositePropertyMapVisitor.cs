
namespace NCop.Composite.Engine
{
    public interface ICompositePropertyMapVisitor
    {
        ICompositeMethodWeaverBuilderFactory Visit(GetCompositePropertyMap propertyMap);
        ICompositeMethodWeaverBuilderFactory Visit(SetCompositePropertyMap propertyMap);
    }
}
