using NCop.Core.Mixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Weaving
{
    public interface ITypeWeaverBuilder
    {
        ITypeWeaver Build();
        void AddMixinTypeMap(MixinMap mixinMap);
        void AddMethodWeaver(IMethodWeaver methodWeaver);
    }
}
