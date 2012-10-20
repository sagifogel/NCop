namespace NCop.Core
{
    public interface ILocker : ILockIndicator
    {
        ILockerFinalizer AcquireReadLock();
        IDowngradeableLocker AcquireWriterLock();
        IUpgradeableLocker AcquireUpgradeableReadLock();
    }
}