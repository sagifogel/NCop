using System;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;

namespace NCop.Samples
{
    internal static class Aspects
    {
        public static TraceAspect traceAspect = null;
        public static TraceAspect2 traceAspect2 = null;
        public static TraceAspect2 traceAspect3 = null;

        static Aspects() {
            traceAspect = new TraceAspect();
            traceAspect2 = new TraceAspect2();
            traceAspect3 = new TraceAspect2();
        }
    }

    public sealed class MethodDecoratorFunctionBinding : IFunctionBinding<CSharpDeveloperMixin, string, bool>
    {
        public static MethodDecoratorFunctionBinding singleton = null;

        static MethodDecoratorFunctionBinding() {
            singleton = new MethodDecoratorFunctionBinding();
        }

        private MethodDecoratorFunctionBinding() {
        }

        public bool Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<string, bool> args) {
            return instance.Code(args.Arg1);
        }
    }

    public class WeavingTest
    {
        public static Type Weave() {
            var assemblyName = new AssemblyName("Stam");
            var da = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            string assemblyNameStr = "{0}.dll".Fmt("Stam");
            var dm = da.DefineDynamicModule(assemblyNameStr, false);
            /***/

            Type aspectAttributes = null;
            var typeAttrs = TypeAttributes.Sealed | TypeAttributes.Abstract;
            TypeBuilder typeBuilder = dm.DefineType("Aspects", typeAttrs, typeof(object));

            var fieldAttrs = FieldAttributes.Family | FieldAttributes.FamANDAssem | FieldAttributes.Static;
            var cctorAttrs = MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
            var cctor = typeBuilder.DefineConstructor(cctorAttrs, CallingConventions.Standard, Type.EmptyTypes);
            var cctorILGenerator = cctor.GetILGenerator();
            var fieldBuilder = typeBuilder.DefineField("Aspect_1", typeof(TraceAspect), fieldAttrs);
            var ctor = fieldBuilder.FieldType.GetConstructor(Type.EmptyTypes);

            cctorILGenerator.Emit(OpCodes.Newobj, ctor);
            cctorILGenerator.Emit(OpCodes.Stsfld, fieldBuilder);

            cctorILGenerator.Emit(OpCodes.Ret);
            aspectAttributes = typeBuilder.CreateType();
            var aspectField = aspectAttributes.GetFields(BindingFlags.Static | BindingFlags.Public)[0];

            /***/
            typeBuilder = dm.DefineType("Shimi", TypeAttributes.Public | TypeAttributes.Sealed, typeof(object), new Type[] { typeof(IFunctionBinding<CSharpDeveloperMixin, string, bool>) });

            fieldAttrs = FieldAttributes.Family | FieldAttributes.FamANDAssem | FieldAttributes.Static;
            var ctorAttrs = MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
            cctor = typeBuilder.DefineConstructor(ctorAttrs | MethodAttributes.Static, CallingConventions.Standard, Type.EmptyTypes);
            cctorILGenerator = cctor.GetILGenerator();
            var defaultCtor = typeBuilder.DefineConstructor(ctorAttrs, CallingConventions.Standard | CallingConventions.HasThis, Type.EmptyTypes);
            var bindingTypeCtor = typeof(object).GetConstructor(Type.EmptyTypes);
            var defaultCtorGenerator = defaultCtor.GetILGenerator();
            fieldBuilder = typeBuilder.DefineField("singleton", typeBuilder, fieldAttrs);

            defaultCtorGenerator.Emit(OpCodes.Ldarg_0);
            defaultCtorGenerator.Emit(OpCodes.Call, bindingTypeCtor);
            defaultCtorGenerator.Emit(OpCodes.Ret);

            cctorILGenerator.Emit(OpCodes.Newobj, defaultCtor);
            cctorILGenerator.Emit(OpCodes.Stsfld, fieldBuilder);
            cctorILGenerator.Emit(OpCodes.Ret);

            ILGenerator ilGenerator = null;
            MethodBuilder methodBuilder = null;
            MethodAttributes methodAttr = MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual;
            CallingConventions callingConventions = CallingConventions.Standard | CallingConventions.HasThis;

            methodBuilder = typeBuilder.DefineMethod("Invoke", methodAttr, callingConventions, typeof(bool), new Type[] { typeof(CSharpDeveloperMixin).MakeByRefType(), typeof(string) });
            ilGenerator = methodBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);
            ilGenerator.Emit(OpCodes.Ldarg_2);
            ilGenerator.Emit(OpCodes.Callvirt, typeof(CSharpDeveloperMixin).GetMethod("Code"));
            ilGenerator.Emit(OpCodes.Ret);

            Type _type = typeBuilder.CreateType();
            FieldInfo fi = _type.GetFields(BindingFlags.Static | BindingFlags.Public)[0];
            object weaved = fi.GetValue(fi);
            /**/

            typeBuilder = dm.DefineType("Person", TypeAttributes.Public | TypeAttributes.BeforeFieldInit, typeof(object), new Type[] { typeof(IPersonComposite), typeof(IDeveloper<ILanguage>) });
            var field = typeBuilder.DefineField("developer", typeof(CSharpDeveloperMixin), FieldAttributes.Private);

            ctorAttrs = MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
            defaultCtor = typeBuilder.DefineConstructor(ctorAttrs, callingConventions, Type.EmptyTypes);
            defaultCtorGenerator = defaultCtor.GetILGenerator();
            defaultCtorGenerator.Emit(OpCodes.Ldarg_0);
            defaultCtorGenerator.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            defaultCtorGenerator.Emit(OpCodes.Ldarg_0);
            defaultCtorGenerator.Emit(OpCodes.Newobj, typeof(CSharpDeveloperMixin).GetConstructors()[0]);
            defaultCtorGenerator.Emit(OpCodes.Stfld, field);
            defaultCtorGenerator.Emit(OpCodes.Ret);

            methodBuilder = typeBuilder.DefineMethod("Code", methodAttr, callingConventions, typeof(bool), new Type[] { typeof(string) });
            var ilGene = methodBuilder.GetILGenerator();
            var bindingLocalBuilder = ilGene.DeclareLocal(fi.FieldType);
            var argsBuilder = ilGene.DeclareLocal(typeof(FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, bool>));

            ilGene.Emit(OpCodes.Ldsfld, fi);
            ilGene.Emit(OpCodes.Stloc, bindingLocalBuilder);
            ilGene.Emit(OpCodes.Ldarg_0);
            ilGene.Emit(OpCodes.Ldfld, field);
            ilGene.Emit(OpCodes.Ldloc_0);
            ilGene.Emit(OpCodes.Ldarg_1);
            ilGene.Emit(OpCodes.Newobj, typeof(FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, bool>).GetConstructors()[0]);
            ilGene.Emit(OpCodes.Stloc_1);
            ilGene.Emit(OpCodes.Ldsfld, aspectField);
            ilGene.Emit(OpCodes.Ldloc_1);
            ilGene.Emit(OpCodes.Callvirt, typeof(TraceAspect).GetMethods()[0]);
            ilGene.Emit(OpCodes.Ret);

            return typeBuilder.CreateType();
        }
    }

    class Program
    {
        static void Main(string[] args) {
            new Person().Code("CSharp");
            var container = new CompositeContainer();
            container.Configure();

            var person = container.TryResolve<IPersonComposite>();
            person.Code("CSharp");
        }
    }

    #region Composites

    public class GenericCovariantDeveloper<T> : IDeveloper<T>
        where T : ILanguage, new()
    {
        private T langugae = new T();

        public bool Code(string code) {
            Console.WriteLine(code);

            return false;
        }
    }

    public class TraceAspect : FunctionInterceptionAspect<string, bool>
    {
        public override bool OnInvoke(FunctionInterceptionArgs<string, bool> args) {
            args.Arg1 = "JavaScript";
            return base.OnInvoke(args);
        }
    }

    [PerThreadAspect]
    public class TraceAspect2 : OnFunctionBoundaryAspect<string, bool>
    {
        public override void OnEntry(FunctionExecutionArgs<string, bool> args) {
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<string, bool> args) {
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<string, bool> args) {
            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<string, bool> args) {
            base.OnExit(args);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPersonComposite : IDeveloper<ILanguage>
    {
        //[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 2)]
        //[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 1)]
        //[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 3)]
        //[MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 2)]
        new bool Code(string code);
    }

    public class Person : IPersonComposite
    {
        private CSharpDeveloperMixin developer = null;

        public Person() {
            developer = new CSharpDeveloperMixin();
        }

        public bool Code(string code) {
            var binding = MethodDecoratorFunctionBinding.singleton;
            var args = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, bool>(developer, binding, code);
            return Aspects.traceAspect.OnInvoke(args);
        }
    }

    public class CSharpDeveloperMixin : AbstractDeveloper<CSharpLanguage5>
    {
        public override bool Code(string code) {
            return base.Code(code);
        }
    }

    public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
    {

    }

    public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
        where TLanguage : ILanguage, new()
    {
        public virtual bool Code(string code) {
            Console.WriteLine("I am coding in " + code);
            return false;
        }
    }

    public interface ILanguage
    {
        string Description { get; }
    }

    public class CSharpLanguage : ILanguage
    {
        public virtual string Description {
            get {
                return "C#";
            }
        }
    }

    public class JavaScriptLanguage : ILanguage
    {
        public string Description {
            get {
                return "JavaScript";
            }
        }
    }

    public class CSharpLanguage5 : CSharpLanguage
    {
        public override string Description {
            get {
                return "C# 5";
            }
        }
    }

    public interface IDeveloper<out TLanguage>
    {
        bool Code(string code);
    }

    public interface IDeveloper
    {
        void Code(string code);
    }

    #endregion Composites
}