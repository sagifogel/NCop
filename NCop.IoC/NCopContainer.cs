using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public class NCopContainer : INCopContainer
    {
        private Dictionary<Type, object> services = new Dictionary<Type, object>();

        public INCopContainer ParentContainer {
            get {
                return null;
            }
        }

        public void Register<TService>(Func<TService> factory, string name = null) {
            services.Add(typeof(TService), factory);
        }

        public void Register<TService>(Func<INCopContainer, TService> factory, string name = null) {
            services.Add(typeof(TService), factory);
        }

        public void Register<TService, TArg1>(Func<INCopContainer, TArg1, TService> factory, string name = null) {
            services.Add(typeof(TService), factory);
        }

        public TService Resolve<TService>(string name = null) {
            var factory = (Func<TService>)services[typeof(TService)];

            return factory();
        }

        public TService Resolve<TService, TArg1>(TArg1 arg1, string name = null) {
            var factory = (Func<TService>)services[typeof(TService)];

            return factory();
        }
    }
}
