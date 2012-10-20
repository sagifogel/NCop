using System.Threading;

namespace NCop.Core
{
    public class DowngradeableLocker : AbstractLocker, IDowngradeableLocker
    {
        public DowngradeableLocker(ReaderWriterLockSlim locker)
            : base(locker) {
            while (!LockAcquired && Locker.IsUpgradeableReadLockHeld) {
                LockAcquired = Locker.TryEnterWriteLock(0);
            }
        }

        public IUpgradeableLocker DowngradeToReadLock() {
            return new UpgradeableLocker(Locker);
        }
    }
}