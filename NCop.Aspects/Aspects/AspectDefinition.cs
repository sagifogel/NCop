using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using NCop.Aspects.Pointcuts;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Aspects
{
    public class AspectDefinition : IAdviceRepository, IAspect
    {
        private readonly Advise _advise = new Advise();
        private static readonly object _syncLock = new object();
        private readonly PointcutStore _pointcuts = new PointcutStore();

        public AspectDefinition(Type type) {
            Type = type;
        }

        public Type Type { get; private set; }


        public string Name {
            get { return Type.FullName; }
        }

        private void AddPointcut(string name, IPointcut pointcut) {
            lock (_syncLock) {
                _pointcuts.GetOrAdd(name, new List<IPointcut>(1))
                          .Add(pointcut);
            }
        }

        public void AddAdvice(IAdvice advice) {
            _advise.Add(advice);
        }

        public IAdviceCollection Advise {
            get {
                return _advise;
            }
        }

        public IPointcutCollection Pointcuts {
            get {
                var pointcuts = _pointcuts.Values.SelectMany(v => v.AsEnumerable());
                return new PointcutCollection(pointcuts);
            }
        }
    }
}
