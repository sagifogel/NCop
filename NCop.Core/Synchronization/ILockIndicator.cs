namespace NCop.Core
{
    public interface ILockIndicator
    {
        bool LockAcquired { get; }
    }
}