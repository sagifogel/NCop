using System;

namespace NCop.Core
{
    public interface IUpgradeableLocker : ILockIndicator, IDisposable
    {
        IDowngradeableLocker UpgradeToWriterLock();
    }
}