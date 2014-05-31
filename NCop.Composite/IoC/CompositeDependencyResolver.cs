using NCop.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Composite.IoC
{
    public class CompositeDependencyResolver : INCopDependencyResolver
    {
        private INCopDependencyResolver resolver = null;

        public CompositeDependencyResolver(INCopDependencyResolver resolver) {
            this.resolver = resolver;
        }

        public void Configure() {
            resolver.Configure();
        }

        public TService Resolve<TService>() {
            return resolver.Resolve<TService>();
        }

        public TService TryResolve<TService>() {
            return resolver.TryResolve<TService>();
        }

        public TService ResolveNamed<TService>(string name) {
            return resolver.ResolveNamed<TService>(name);
        }

        public TService TryResolveNamed<TService>(string name) {
            return resolver.TryResolveNamed<TService>(name);
        }

        public void Dispose() {
            resolver.Dispose();
        }
    }
}
