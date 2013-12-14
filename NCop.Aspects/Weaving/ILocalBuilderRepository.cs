using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public interface ILocalBuilderRepository
    {
        LocalBuilder Get(Type type);
        void Add(LocalBuilder localBuilder);
        void Add(Type type, LocalBuilder localBuilder);
    }
}
