using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NCop.Core
{
#if NET_4_0

    public static class Volatile
    {
        public static bool Read(ref bool location) {
            bool flag = location;
            Thread.MemoryBarrier();
            return flag;
        }

        public static void Write(ref bool location, bool value) {
            Thread.MemoryBarrier();
            location = value;
        }
    }

#endif
}
