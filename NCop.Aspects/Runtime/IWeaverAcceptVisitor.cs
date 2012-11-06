using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Runtime
{
    public interface IWeaverAcceptVisitor : IWeaver, IAcceptsVisitor<IWeaver, WeaverVisitor, AspectsRuntimeSettings>
    {
    }
}
