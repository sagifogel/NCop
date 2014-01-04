using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Core;

namespace NCop.Aspects.Weaving.Expressions
{
    public class AspectVisitor : IAspectDefinitionVisitor
    {
        private struct Aspect
        {
            public bool Top { get; set; }
            public bool IsInterception { get; set; }
        }

        private Aspect lastAspect = new Aspect() { Top = true };

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(OnMethodBoundaryAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                Func<IAspectExpression, IAspectExpression> ctor = null;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new TopOnMethodBoundaryAspectExpression(expression, aspectDefinition);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInterception) {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new BindingOnMethodBoundaryAspectExpression(expression, aspectDefinition);
                        });
                    }
                    else {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new NestedOnMethodBoundaryAspectExpression(expression, aspectDefinition);
                        });
                    }
                }

                lastAspect.IsInterception = false;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(MethodInterceptionAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                Func<IAspectExpression, IAspectExpression> ctor = null;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new TopMethodInterceptionAspectExpression(expression, aspectDefinition);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInterception) {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new BindingMethodInterceptionAspectExpression(expression, aspectDefinition);
                        });
                    }
                    else {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new NestedMethodInterceptionAspectExpression(expression, aspectDefinition);
                        });
                    }
                }

                lastAspect.IsInterception = true;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public IAspectExpression GetDecorationAspectExpression(IArgumentsWeavingSettings argumentsWeavingSettings) {
            if (lastAspect.IsInterception) {
                return new BindingAspectDecoratorExpression(argumentsWeavingSettings);
            }

            return new NestedAspectDecoratorExpression(argumentsWeavingSettings);
        }
    }
}
