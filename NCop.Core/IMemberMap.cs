using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core
{
	public interface IMemberMap<out TMember>
		 where TMember : MemberInfo
	{
		Type ContractType { get; }
		Type ImplementationType { get; }
		TMember ContractMember { get; }
		TMember ImplementationMember { get; }
	}
}
