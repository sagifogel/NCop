using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public interface INCopContainer
    {   
        //IContainer ParentContainer { get; }
        void Register<TService>(Func<INCopContainer, TService> factory, string name = null);
        TService Resolve<TService>(string name = null);
        //TService TryResolve<TService>(bool throwIf);
    }
}
