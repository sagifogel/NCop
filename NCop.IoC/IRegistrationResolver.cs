using NCop.IoC.Fluent;
using System;

namespace NCop.IoC
{
    public interface IRegistrationResolver
    {
        IRegistration Resolve(Type concreteType);
    }
}
