using NCop.IoC.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.IoC.Tests
{
    public interface IFoo { string Name { get; } }
    public interface IBar { }

    public class Foo : IFoo, IDisposable
    {
        public bool IsDisposed { get; set; }

        public Foo() { }

        public Foo(string name) {
            Name = name;
        }

        public string Name { get; private set; }

        public void Dispose() {
            IsDisposed = true;
        }
    }

    public class PropertyDependency
    {
        [Dependency]
        public IFoo Foo { get; set; }
    }

    public class CtorDependency
    {
        public CtorDependency(IFoo foo) {
            Foo = foo;
        }

        public IFoo Foo { get; private set; }
    }

    public class AmbigousConstructor
    {
        public AmbigousConstructor(IFoo foo) {
            Foo = foo;
        }

        public AmbigousConstructor()
            : this(new Foo()) {
        }

        public IFoo Foo { get; private set; }
    }

    public class AmbigousConstructorFixedWithDependencyAttribute
    {   
        [Dependency]
        public AmbigousConstructorFixedWithDependencyAttribute(IFoo foo) {
            Foo = foo;
        }

        public AmbigousConstructorFixedWithDependencyAttribute()
            : this(new Foo()) {
        }

        public IFoo Foo { get; private set; }
    }

    [DependencyAware]
    public class DependencyAwareClass
    {
        public IFoo Ignored { get; set; }

        [Dependency]
        public IFoo Injected { get; set; }
    }

    public class IgnoreDependencyClass
    {
        [IgnoreDependency]
        public IFoo Ignored { get; set; }

        public IFoo Injected { get; set; }
    }

    public class Bar : IBar
    {
        public IFoo ByCtor { get; set; }

        [Dependency]
        public IFoo ByProperty { get; set; }

        public Bar() {
        }

        [Dependency]
        public Bar(IFoo foo) {
            ByCtor = foo;
        }
    }
}