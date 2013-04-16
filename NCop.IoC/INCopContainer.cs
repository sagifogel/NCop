using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public interface INCopContainer
    {
        INCopContainer ParentContainer { get; }
        TService Resolve<TService>(string name = null);
        TService Resolve<TArg1, TService>(TArg1 arg1, string name = null);
        void Register<TService>(Func<INCopContainer, TService> factory, string name = null);
        void Register<TService, TArg1>(Func<INCopContainer, TArg1, TService> factory, string name = null);
    }
}
