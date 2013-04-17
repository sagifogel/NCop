using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.IoC
{
    public class NCopContainer : INCopContainer
    {
        private Dictionary<Identifier, object> services = new Dictionary<Identifier, object>();

        public INCopContainer ParentContainer {
            get {
                return null;
            }
        }

        public void Register<TService>(string name = null) {
            Register(typeof(TService), name);
        }

        public void Register(Type type, string name = null) {
            Contract.RequiersNotInterface(type, () => Resources.TypeIsInterface.Format(type));

            var ctor = type.GetConstructor(Type.EmptyTypes);
            var paramater = Expression.Parameter(typeof(INCopContainer), "container");
            var lambda = Expression.Lambda(
                            Expression.New(ctor),
                                paramater);

            RegisterImpl(type, lambda.Compile());
        }

        public void Register<TService>(Func<INCopContainer, TService> factory, string name = null) {
            RegisterImpl(typeof(TService), factory);
        }

        public void Register<TService, TArg1>(Func<INCopContainer, TArg1, TService> factory, string name = null) {
            RegisterImpl(typeof(Func<INCopContainer, TArg1, TService>), factory, name);
        }

        public void RegisterImpl(Type factoryType, object factory, string name = null) {
            var identifier = new Identifier(factoryType, name);

            services.Add(identifier, factory);
        }

        public TService Resolve<TService>(string name = null) {
            var identifier = new Identifier(typeof(TService), name);
            var factory = (Func<INCopContainer, TService>)services[identifier];

            return factory(this);
        }

        public TService Resolve<TArg1, TService>(TArg1 arg1, string name = null) {
            var identifier = new Identifier(typeof(TService), name);
            var factory = (Func<INCopContainer, TArg1, TService>)services[identifier];

            return factory(this, arg1);
        }
    }
}