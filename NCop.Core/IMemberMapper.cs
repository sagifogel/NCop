using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core;

namespace NCop.Core
{
	public interface IMemberMapper<TMember> : IReadOnlyCollection<IMemberMap<MemberInfo>>
	{
	}
}
