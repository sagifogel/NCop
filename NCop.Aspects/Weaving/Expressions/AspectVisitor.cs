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
        private IAspectDefinition previousAspectDefinition = null;

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
                        var _previousAspectDefinition = previousAspectDefinition;
                        
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new NestedOnMethodBoundaryAspectExpression(expression, aspectDefinition, _previousAspectDefinition);
                        });
                    }
                }

                lastAspect.IsInterception = false;
                previousAspectDefinition = aspectDefinition;

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
                        var _previousAspectDefinition = previousAspectDefinition;

                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new NestedMethodInterceptionAspectExpression(expression, aspectDefinition, _previousAspectDefinition);
                        });
                    }
                }

                lastAspect.IsInterception = true;
                previousAspectDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public IAspectExpressionBuilder GetDecorationAspectExpression(IAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings) {
            Func<IAspectExpression, IAspectExpression> expressionFactory = null;

            if (lastAspect.IsInterception) {
                expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>((ex) => {
                    return new BindingAspectDecoratorExpression(aspectDefinition, argumentsWeavingSettings);
                });
            }
            else {
                expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>((ex) => {
                    return new NestedAspectDecoratorExpression(argumentsWeavingSettings);
                });
            }

            return new AspectNodeExpressionBuilder(expressionFactory);
        }
    }
}
