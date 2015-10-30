
using NCop.Core.Extensions;
using NCop.IoC.Properties;
using System.Collections;
using System.Reflection;
using System.Web;

namespace NCop.IoC
{
    internal class HttpRequestLifetimeStrategy : AbstractLifetimeStrategy
    {
        private static readonly string itemsName = "NCop<{0}>".Fmt(Assembly.GetExecutingAssembly().GetName().Version);

        private HttpRequestLifetimeStrategy() { }

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

            return cache.GetOrAdd(context.Key, context.Factory);
        }

        private IDictionary EnsureHttpContextItems() {
            if (!HasContext()) {
                throw new LifetimeStragtegyException(Resources.HttpRequestLifetimeStrategyNotSupportedInContext);
            }

            return HttpContext.Current.Items;
        }

        internal static bool HasContext() {
            return HttpContext.Current.IsNotNull();
        }
    }
}
