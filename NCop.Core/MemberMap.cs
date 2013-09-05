using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core
{
	public class MemberMap<TMember> : IMemberMap<TMember>
		where TMember : MemberInfo
	{
		public MemberMap(Type contractType, Type implementationType, TMember contractMember, TMember implementationMember) {
			ContractType = contractType;
			ContractMember = contractMember;
			ImplementationType = implementationType;
			ImplementationMember = implementationMember;
		}

		public Type ContractType { get; private set; }
		public Type ImplementationType { get; private set; }
		public TMember ContractMember { get; private set; }
		public TMember ImplementationMember { get; private set; }
	}
}
