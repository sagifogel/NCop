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
            IPersonComposite composite = null;
            var container = new CompositeContainer();

            container.Configure();
            composite = container.TryResolve<IPersonComposite>();
            composite.Play("First", "Second", "Third");
        }
    }

    [TransientComposite]
    [Mixins(typeof(DrummerMixin), typeof(DeveloperMixin))]
    public interface IPersonComposite : IDeveloperMixin, IDrummer
    {
    }

    public interface IDrummer
    {
        void Play(params string[] songs);
    }

    public class DrummerMixin : IDrummer
    {
        public void Play(params string[] songs) {
            
            songs.ToList().ForEach(s => Console.WriteLine(s));
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
