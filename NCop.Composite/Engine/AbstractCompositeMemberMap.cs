using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core;
using NCop.Core.Extensions;

namespace NCop.Composite.Engine
{
	public abstract class AbstractCompositeMemberMap<TMember> : IMemberMap<TMember>
		where TMember : MemberInfo
	{
		private readonly ISet<TMember> members = new HashSet<TMember>();

		public AbstractCompositeMemberMap(Type contractType, Type implementationType, TMember contractMember, TMember implementationMember, TMember compositeMember) {
			ContractType = contractType;
			ContractMember = contractMember;
			CompositeMember = compositeMember;
			ImplementationType = implementationType;
			ImplementationMember = implementationMember;

			AddIfNotNull(() => contractMember);
			AddIfNotNull(() => compositeMember);
			AddIfNotNull(() => implementationMember);
		}

		private void AddIfNotNull(Func<TMember> memberFactory) {
			var memberInfo = memberFactory();

			if (memberInfo.IsNotNull()) {
				members.Add(memberInfo);
			}
		}
		
		public TMember Target {
			get {
				return ImplementationMember;
			}
		}

		public IEnumerable<TMember> Members {
			get {
				return members;
			}
		}

		public Type ContractType { get; private set; }
		public TMember ContractMember { get; private set; }
		public TMember CompositeMember { get; private set; }
		public Type ImplementationType { get; private set; }
		public TMember ImplementationMember { get; private set; }
	}
}
