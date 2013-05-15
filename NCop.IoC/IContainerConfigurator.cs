using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public interface IContainerConfigurator
    {
        void Configure(Action<IFluentRegistry> registrationAction = null);
    }
}
