using NCop.Aspects.Engine;
using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Engine
{
    public interface ICompositeMemberCollection : IReadOnlyCollection<IAspectMembers<MemberInfo>>, ICompositePropertyMapCollection, ICompositeMethodMapCollection
    {
    }
}
