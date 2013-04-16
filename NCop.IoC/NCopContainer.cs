using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void Register<TService>(string name = null) {
            Register(typeof(TService), name);
        }

        public void Register(Type type, string name = null) {
            var ctor = type.GetConstructor(Type.EmptyTypes);
            var paramater = Expression.Parameter(typeof(INCopContainer), "container");
            var lambda = Expression.Lambda(
                            Expression.New(ctor),
                                paramater);

            services.Add(type, lambda.Compile());
        }

        public void Register<TService>(Func<INCopContainer, TService> factory, string name = null) {
            services.Add(typeof(TService), factory);
        }

        public void Register<TService, TArg1>(Func<INCopContainer, TArg1, TService> factory, string name = null) {
            services.Add(typeof(TService), factory);
        }

        public TService Resolve<TService>(string name = null) {
            var factory = (Func<INCopContainer, TService>)services[typeof(TService)];

            return factory(this);
        }

        public TService Resolve<TArg1, TService>(TArg1 arg1, string name = null) {
            var factory = (Func<INCopContainer, TArg1, TService>)services[typeof(TService)];

            return factory(this, arg1);
        }
    }
}