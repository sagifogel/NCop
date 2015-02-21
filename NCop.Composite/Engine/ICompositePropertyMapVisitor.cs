
using NCop.Weaving;
namespace NCop.Composite.Engine
{
    public interface ICompositePropertyMapVisitor
    {
        IPropertyWeaverBuilder Visit(GetCompositePropertyMap propertyMap);
        IPropertyWeaverBuilder Visit(SetCompositePropertyMap propertyMap);
    }
}
