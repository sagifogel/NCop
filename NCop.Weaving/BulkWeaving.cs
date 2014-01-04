using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Weaving
{
    public class BulkWeaving
    {
        private bool lockTaken = false;
        private static object syncLock = new object();
        private readonly IEnumerable<ITypeWeaver> weavers = null;

        public BulkWeaving(IEnumerable<ITypeWeaver> weavers) {
            this.weavers = weavers;
        }

        public void Weave() {
             try {
                Monitor.Enter(syncLock, ref lockTaken);

                weavers.ForEach(weaver => {
                    weaver.Weave();
                });

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
