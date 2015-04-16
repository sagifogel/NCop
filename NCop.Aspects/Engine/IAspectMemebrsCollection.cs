using System.Collections.Generic;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IAspectMemebrsCollection : IReadOnlyCollection<IAspectMembers<MemberInfo>>, IAspectPropertyMapCollection, IAspectMethodMapCollection, IAspectEventMapCollection
    {
    }
}
