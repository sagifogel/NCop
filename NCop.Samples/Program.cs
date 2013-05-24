using NCop.Aspects.Framework;
using NCop.Composite.Engine;
using NCop.Composite.Framework;
using NCop.Core;
using NCop.IoC;
using NCop.IoC.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCop.Samples
{
    class Program
    {
        static void Main(string[] args) {
            var container = new CompositeContainer();
            container.Configure();
            
            var composite = container.TryResolve<IPersonComposite>();
        }
    }

    [SingletonComposite]
    [Mixins(typeof(DrummerMixin), typeof(DeveloperMixin))]
    public interface IPersonComposite : IDeveloperMixin, IDrummer
    {
    }

    public interface IDrummer
    {
        void Play(string song);
        void Play2(int i);
    }

    public class DrummerMixin : IDrummer
    {
        public void Play(string song) {
            Console.WriteLine(song);
        }
        
        public void Play2(int i) {
            Console.WriteLine(i);
        }
    }

    public class DeveloperMixin : IDeveloperMixin
    {
        public int DoWork() {
            return 50;
        }
    }

    public interface IDeveloperMixin
    {
        int DoWork();
    }
}
