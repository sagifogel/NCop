using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public interface ILocalBuilderRepository
    {
        LocalBuilder Get(Type type);
        void Add(LocalBuilder localBuilder);
        void Add(Type type, LocalBuilder localBuilder);
        LocalBuilder Declare(Func<LocalBuilder> localBuilderFactory);
        LocalBuilder GetOrDeclare(Type type, Func<LocalBuilder> localBuilderFactory);
    }
}
