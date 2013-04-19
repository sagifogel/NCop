using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC.Fluent
{
    public interface ICastableRegistration<TCastable> : IFluenatRegistration
    {
        ICasted ToSelf();
        ICasted As<TService>() where TService : TCastable, new();
    }
}
