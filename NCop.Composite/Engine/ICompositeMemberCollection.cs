using NCop.Aspects.Engine;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Composite.Engine
{
    internal interface ICompositeMemberCollection : IReadOnlyCollection<IAspectMembers<MemberInfo>>, ICompositePropertyMapCollection, ICompositeMethodMapCollection
    {
    }
}
