using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using System;
using System.Web;

namespace NCop.Samples.CompositeLifetime.PerHttpRequest
{
    public static class CompositeRunner
    {
        public async static void Run() {
            IDeveloper developer = null;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(IDeveloper) }
            });

            container.Configure();
            SetHttpContext();
            developer = container.Resolve<IDeveloper>();
            Console.WriteLine("Instances within the same HttpContext are the same: {0}", developer == container.Resolve<IDeveloper>());
            SetHttpContext();
            Console.WriteLine("Instances within different HttpContext are not the same: {0}", developer != container.Resolve<IDeveloper>());
        }

        private static void SetHttpContext() {
            HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));
        }
    }
}
