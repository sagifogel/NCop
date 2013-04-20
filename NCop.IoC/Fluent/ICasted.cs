using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC.Fluent
{
    public interface ICasted : IFluentInterface, IDescriptable, ILifetimeStrategy
    {
    }
}
