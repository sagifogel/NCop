using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using NCop.Aspects.Pointcuts;
using NCop.Aspects.Engine;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public class AspectDefinition : IAdviceRepository, IAspectDefinition
    {
        private readonly IAspect _aspect = null;
        private static readonly object _syncLock = new object();
        private readonly PointcutStore _pointcuts = new PointcutStore();
        private readonly AdviceCollection _advices = new AdviceCollection();

        public AspectDefinition(IAspect aspect) {
            _aspect = aspect;
        }

        private void AddPointcut(string name, IPointcut pointcut) {
            lock (_syncLock) {
                _pointcuts.GetOrAdd(name, new List<IPointcut>(1))
                          .Add(pointcut);
            }
        }

        public void AddAdvice(IAdvice advice) {
            _advices.Add(advice);
        }

        public IPointcutCollection Pointcuts {
            get {
                var pointcuts = _pointcuts.Values.SelectMany(v => v.AsEnumerable());
                return new PointcutCollection(pointcuts);
            }
        }

        public IAspect Aspect {
            get {
                return _aspect;
            }
        }

        public IAdviceCollection Advices {
            get {
                return _advices;
            }
        }
    }
}
