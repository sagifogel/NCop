using NCop.Core;
using System;

namespace NCop.IoC
{
    public interface INCopRegistry
    {
        void Register(TypeMap typeMap, ITypeMapCollection dependencies = null);
    }
}