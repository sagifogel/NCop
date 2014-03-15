using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.IoC
{
    public interface IRegistrationResolver
    {
        IRegistration Resolve(Type concreteType);
    }
}
