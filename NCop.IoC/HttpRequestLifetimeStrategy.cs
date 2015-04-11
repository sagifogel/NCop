
using System;
using System.Reflection;
using System.Web;
using NCop.Core.Extensions;
using System.Collections;

namespace NCop.IoC
{
    internal class HttpRequestLifetimeStrategy : AbstractLifetimeStrategy
    {
        public static readonly string itemsName = "NCop<{0}>".Fmt(Assembly.GetExecutingAssembly().GetName().Version);

        private HttpRequestLifetimeStrategy() {
        }

        static HttpRequestLifetimeStrategy() {
            Instance = new HttpRequestLifetimeStrategy();
        }

        public static HttpRequestLifetimeStrategy Instance { get; private set; }

        public override TService Resolve<TService>(ResolveContext<TService> context) {
            ILifetimeCache cache = null;
            var items = EnsureHttpContextItems();

            if (!items.Contains(itemsName)) {
                lock (items.SyncRoot) {
                    if (!items.Contains(itemsName)) {
                        cache = new LifetimeCacheImpl();
                        items.Add(itemsName, cache);
                    }
                }
            }

            cache = cache ?? (ILifetimeCache)items[itemsName];

            return cache.GetOrAdd(context.Factory);
        }

        private IDictionary EnsureHttpContextItems() {
            if (!HasContext()) {
                throw new NotSupportedException();
            }

            return HttpContext.Current.Items;
        }

        internal static bool HasContext() {
            return HttpContext.Current.IsNotNull();
        }
    }
}
