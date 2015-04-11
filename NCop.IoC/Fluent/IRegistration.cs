using System;
using System.ComponentModel;

namespace NCop.IoC.Fluent
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRegistration
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        Owner Owner { get; }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        string Name { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Delegate Func { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Type FactoryType { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Type ServiceType { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Lifetime Lifetime { get; }
    }
}
