using System;
using System.Threading;

namespace NCop.Core
{
    public class ReadLock : AbstractLocker, IDisposable
    {
        public ReadLock(ReaderWriterLockSlim locker)
            : base(locker) {
            if (!IsLockHeld) {
                while (!LockAcquired) {
                    LockAcquired = Locker.TryEnterReadLock(0);
                }
            }
        }
    }
}