using NCop.Aspects.Engine;
using NCop.Core;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public interface ICompositePropertyFragmentMap : IAspectMembers<PropertyInfo>, IMemberMap<PropertyInfo>, IHasAspectDefinitions, IAcceptsCompositePropertyMapVisitor
    {
    }
}
