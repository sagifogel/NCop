using System.Reflection;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
    //internal class PropertyInterceptionAspectsDefinition : AbstractPropertyAspectDefinition
    //{
    //    private readonly PropertyInterceptionAspectAttribute aspect = null;

    //    public PropertyInterceptionAspectsDefinition(PropertyInterceptionAspectAttribute aspect, Type aspectDeclaringType, PropertyInfo property)
    //        : base(aspect, aspectDeclaringType, property) {
    //        this.aspect = aspect;
    //    }

    //    public override AspectType AspectType {
    //        get {
    //            return AspectType.SetPropertyInterceptionAspect;
    //        }
    //    }

    //    public override void BulidAdvices() {
    //        Aspect.AspectType
    //             .GetOverridenMethods()
    //             .ForEach(method => {
    //                 TryBulidAdvice<OnSetPropertyAdviceAttribute>(method, (advice, mi) => {
    //                     return new OnSetPropertyAdviceDefinition(advice, mi);
    //                 });
    //             });
    //    }

    //    public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
    //        return visitor.Visit(aspect).Invoke(this);
    //    }
    //}
}
