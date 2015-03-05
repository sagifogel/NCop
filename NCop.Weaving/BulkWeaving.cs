using NCop.Core.Extensions;
using System.Collections.Generic;
using System.Threading;

namespace NCop.Weaving
{
    public class BulkWeaving : ITypeWeaver
    {
        private bool lockTaken = false;
        private readonly static object syncLock = new object();
        private readonly IEnumerable<ITypeWeaver> weavers = null;

        public BulkWeaving(IEnumerable<ITypeWeaver> weavers) {
            this.weavers = weavers;
        }

        public void Weave() {
            try {
                Monitor.Enter(syncLock, ref lockTaken);
                weavers.ForEach(weaver => weaver.Weave());
                NCopModuleBuilder.Flush();
            }
            finally {
                if (lockTaken) {
                    Monitor.Exit(syncLock);
                }
            }
        }
    }
}
