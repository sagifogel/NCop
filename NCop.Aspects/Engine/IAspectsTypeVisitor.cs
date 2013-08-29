using NCop.Core.Extensions;
using NCop.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Engine
{
	public interface IAspectsTypeVisitor : IEnumerableProjectionTypeVisitor<Tuple<MemberInfo, IEnumerable<IAspect>>>
	{
	}
}
