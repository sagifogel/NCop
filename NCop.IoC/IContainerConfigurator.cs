using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public interface IContainerConfigurator<TContainer> where TContainer : INCopContainer
    {
        TContainer Configure(Action<IFluentRegistry> registrationAction = null);
    }
}
