using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Framework;
using NCop.Aspects.LifetimeStrategies;
using NCop.Core.Aspects;

namespace NCop.Aspects.Engine
{
    public abstract class AspectAttribute : Attribute, IAspect
    {

    }
}
