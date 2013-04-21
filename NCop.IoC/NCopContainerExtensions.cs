using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.IoC
{
    internal static class NCopContainerExtensions
    {
        internal static bool TryGetEntryWhenNotNull(this NCopContainer container, ServiceKey key, out ServiceEntry entry) {
            entry = null;
            return !container.IsNull() && container.TryGetEntry(key, out entry);
        }
    }
}
