using NCop.Aspects.Engine;
using NCop.Core;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public interface ICompositeEventFragmentMap : IAspectMembers<EventInfo>, IAspectContainer, IMemberMap<EventInfo>, IAcceptsCompositeEventMapVisitor, ICompositeFragmentMap
    {
    }
}
