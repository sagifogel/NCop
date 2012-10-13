using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace NCop.Aspects.Engine
{
    public class AspectDefinition
    {
        private readonly Advices _advices = new Advices();
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

        public IEnumerable<IPointcut> GetPointcuts(string name) {
            IList<IPointcut> pointcuts;

            _pointcuts.TryGetValue(name, out pointcuts);

            return pointcuts;
        }

        public void AddAdvise(IAdvice advice) {
            _advices.Add(advice);
        }

        public IEnumerable<IAdvice> Advices {
            get { return _advices; }
        }
    }
}
