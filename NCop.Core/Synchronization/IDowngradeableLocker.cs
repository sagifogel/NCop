using System;

namespace NCop.Core
{
    public interface IDowngradeableLocker : ILockIndicator, IDisposable
    {
        IUpgradeableLocker DowngradeToReadLock();
    }
}