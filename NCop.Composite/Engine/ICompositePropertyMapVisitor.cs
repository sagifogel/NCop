using NCop.Weaving;

namespace NCop.Composite.Engine
{
    public interface ICompositePropertyMapVisitor
    {       
        void Visit(GetCompositePropertyMap propertyMap);
        void Visit(SetCompositePropertyMap propertyMap);
    }
}
