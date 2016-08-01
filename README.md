
NCop
===================
What is **NCop**?

**NCop** is a framework that implements Composite/Aspect Oriented Programming that encapsulates the concepts of [Mixins](https://github.com/sagifogel/NCop/blob/master/README.md#mixins), [Aspects](https://github.com/sagifogel/NCop/blob/master/README.md#aspects) and [Dependency Injection](https://github.com/sagifogel/NCop/blob/master/README.md#dependency-injection), using the standard .NET.<br/>
The main purpose of composites is separation of concerns. You  achieve it by defining different roles within different entities and combine all of them using **NCop** (much like multiple inheritance).

### Installing

```
Install-Package NCop
```

Please visit the [Wiki](https://github.com/sagifogel/NCop/wiki) page for explanations and demos.
------------

<a name="mixins"></a>
### Mixins

A mixin is an interface with implemented methods.<br/>
Mixins exists in .NET in the form of object oriented interfaces implementation.

```csharp
public interface IDeveloper
{
    void Code();
}
```

```csharp
public class CSharpDeveloperMixin : IDeveloper
{
    public void Code() {
        Console.WriteLine("C# coding");
    }
}
```

### Composites

Composites are the artifacts of **NCop** processing. A composite is a combination of Mixins and Aspects.<br/>
In order to create a composite type you need to annotate one of the interfaces with a `CompositeAttribute`<br/>
and also to tell **NCop** to match between interface and implementation by annotating the composite type with a `MixinsAttribute`.

```csharp
[TransientComposite]
[Mixins(typeof(CSharpDeveloperMixin))]
public interface IDeveloper
{
    void Code();
}
```

<a name="aspects"></a>
### Aspects

Aspects aims to increase modularity by allowing the separation of cross-cutting concerns.<br/>
In order to create an aspect you should first create an aspect class that will hold your desired join points.

```csharp
public class StopwatchActionInterceptionAspect : ActionInterceptionAspect
{
    private readonly Stopwatch stopwatch = null;

    public StopwatchActionInterceptionAspect() {
        stopwatch = new Stopwatch();
    }

    public override void OnInvoke(ActionInterceptionArgs args) {
        stopwatch.Restart();
        args.Proceed();
        stopwatch.Stop();
        Console.WriteLine("Elapsed Ticks: {0}", stopwatch.ElapsedTicks);
    }
}
```


The second thing that you will need to do is to annotate the method which you want to apply the aspect on.<br/>

```csharp
[TransientComposite]
[Mixins(typeof(CSharpDeveloperMixin))]
public interface IDeveloper
{
    [MethodInterceptionAspect(typeof(StopwatchActionInterceptionAspect))]
    void Code();
}
```

<a name="dependency-injection"></a>
### Dependency Injection

**NCop** IoC is based on <a href="http://funq.codeplex.com/" target="_blank">Funq</a> - which was adopted because of its excellent performance and memory characteristics.<br/>
In order to resolve an artifact of **NCop** you need to create a composite IoC Container, <br/>
and call the `Resolve` function. <br/>

```csharp
static void Main(string[] args) {
    IDeveloper developer = null;
    var container = new CompositeContainer();

    container.Configure();
    developer = container.Resolve<IDeveloper>();
    developer.Code();
}
```

