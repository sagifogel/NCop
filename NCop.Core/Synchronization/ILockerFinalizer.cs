using System;

namespace NCop.Core
{
    public interface ILockerFinalizer : IDisposable, ILockIndicator
    {
        bool IsLockHeld { get; }
    }
}