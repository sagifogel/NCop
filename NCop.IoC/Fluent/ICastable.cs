using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC.Fluent
{
    internal interface ICastable : IFlentInterface
    {
        ILifetimeStrategy ToSelf();
        ILifetimeStrategy As<TService>();
    }
}
