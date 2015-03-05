using System.Collections.Generic;
using System.Reflection;

namespace NCop.Core
{
	public interface IMemberMapper<TMember> : IReadOnlyCollection<IMemberMap<MemberInfo>>
	{
	}
}
