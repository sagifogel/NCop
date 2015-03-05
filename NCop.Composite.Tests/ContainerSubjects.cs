using NCop.IoC.Framework;
using System;

namespace NCop.Composite.Tests
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
        public IFoo Foo { get; set; }
    }

    public class CtorDependency
    {
        public CtorDependency(IFoo foo) {
            Foo = foo;
        }

        public IFoo Foo { get; private set; }
    }

    public class AmbiguousConstructor
    {
        public AmbiguousConstructor(IFoo foo) {
            Foo = foo;
        }

        public AmbiguousConstructor()
            : this(new Foo()) {
        }

        public IFoo Foo { get; private set; }
    }

    public class AmbiguousConstructorFixedWithDependencyAttribute
    {
        [Dependency]
        public AmbiguousConstructorFixedWithDependencyAttribute(IFoo foo) {
            Foo = foo;
        }

        public AmbiguousConstructorFixedWithDependencyAttribute()
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
        [IgnoreDependency]
        public IFoo ByCtor { get; set; }

        public IFoo ByProperty { get; set; }

        public Bar() {
        }

        [Dependency]
        public Bar(IFoo foo) {
            ByCtor = foo;
        }
    }

    public class Baz
    {
    }

    public class Boo : IFoo
    {
        public Baz Baz { get; set; }

        public string Name {
            get {
                return string.Empty;
            }
        }
    }
}
