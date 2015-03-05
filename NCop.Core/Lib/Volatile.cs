
namespace NCop.Core.Lib
{
#if NET_4_0

    internal static class Volatile
    {
        internal static bool Read(ref bool location) {
            bool flag = location;
            Thread.MemoryBarrier();
            return flag;
        }

        internal static void Write(ref bool location, bool value) {
            Thread.MemoryBarrier();
            location = value;
        }
    }

#endif
}
