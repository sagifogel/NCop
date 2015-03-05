using System;
using System.Reflection;

namespace NCop.Core
{
    public interface IMemberMap<out TMember> where TMember : MemberInfo
    {
        Type ContractType { get; }
        Type ImplementationType { get; }
        TMember ContractMember { get; }
        TMember ImplementationMember { get; }
    }
}
