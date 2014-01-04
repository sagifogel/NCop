using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public interface INCopContainer : IDisposable
    {
        void Configure();
        TService Resolve<TService>();
        TService TryResolve<TService>();
        TService Resolve<TService>(string name = null);
        TService TryResolve<TService>(string name = null);        
    }
}
