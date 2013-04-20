using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NCop.IoC.Fluent
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRegistration
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        string Name { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Delegate Func { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Type FactoryType { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Type ServiceType { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        ReuseScope Scope { get; }
    }
}
