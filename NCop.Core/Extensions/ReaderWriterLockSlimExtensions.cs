using System;
using System.Threading;

namespace NCop.Core.Extensions
{
    public static class ReaderWriterLockSlimExtensions
    {
        public static T Read<T>(this ReaderWriterLockSlim locker, Func<T> func) {
            locker.EnterReadLock();

            try {
                return func();
            }
            finally {
                locker.ExitReadLock();
            }
        }

        public static void Write(this ReaderWriterLockSlim locker, Action action) {
            locker.EnterWriteLock();

            try {
                action();
            }
            finally {
                locker.ExitWriteLock();
            }
        }

        public static bool CouldWrite(this ReaderWriterLockSlim locker, Func<bool> func) {
            locker.EnterWriteLock();

            try {
                return func();
            }
            finally {
                locker.ExitWriteLock();
            }
        }

        public static void UpgradeableRead(this ReaderWriterLockSlim locker, Action action) {
            try {
                locker.EnterUpgradeableReadLock();
                action();
            }
            finally {
                locker.ExitUpgradeableReadLock();
            }
        }
    }
}
