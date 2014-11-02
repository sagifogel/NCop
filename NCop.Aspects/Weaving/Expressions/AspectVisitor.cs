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
            public bool IsInBinding { get; set; }
            public bool IsTopBinding { get; set; }
        }

        private Aspect lastAspect = new Aspect() { Top = true };
        private IAspectDefinition topAspectInScopeDefinition = null;

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(OnMethodBoundaryAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                Func<IAspectMethodExpression, IAspectMethodExpression> ctor = null;

                var _topAspectInScopeDefinition = topAspectInScopeDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(expression => {
                        return new TopOnMethodBoundaryAspectExpression(expression, aspectDefinition);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        if (lastAspect.IsTopBinding) {
                            lastAspect.IsTopBinding = false;

                            ctor = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(expression => {
                                return new TopBindingOnMethodBoundaryAspectExpression(expression, aspectDefinition);
                            });
                        }
                        else {
                            ctor = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(expression => {
                                return new BindingOnMethodBoundaryAspectExpression(expression, aspectDefinition, _topAspectInScopeDefinition);
                            });
                        }
                    }
                    else {
                        ctor = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(expression => {
                            return new NestedOnMethodBoundaryAspectExpression(expression, aspectDefinition);
                        });
                    }
                }

                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(MethodInterceptionAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                Func<IAspectMethodExpression, IAspectMethodExpression> ctor = null;

                var _topAspectInScopeDefinition = topAspectInScopeDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(expression => {
                        return new TopMethodInterceptionAspectExpression(expression, aspectDefinition);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        if (lastAspect.IsTopBinding) {
                            lastAspect.IsTopBinding = false;

                            ctor = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(expression => {
                                return new TopBindingMethodInterceptionAspectExpression(expression, aspectDefinition);
                            });
                        }
                        else {
                            ctor = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(expression => {
                                return new BindingMethodInterceptionAspectExpression(expression, aspectDefinition, _topAspectInScopeDefinition);
                            });
                        }
                    }
                    else {
                        ctor = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(expression => {
                            return new NestedMethodInterceptionAspectExpression(expression, aspectDefinition, _topAspectInScopeDefinition);
                        });
                    }
                }

                lastAspect.IsInBinding = true;
                lastAspect.IsTopBinding = true;
                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public IAspectExpressionBuilder VisitInvocation(IAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings) {
            Func<IAspectMethodExpression, IAspectMethodExpression> expressionFactory = null;

            if (lastAspect.IsInBinding) {
                if (topAspectInScopeDefinition.AspectType == AspectType.MethodInterceptionAspect)
                    expressionFactory = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(ex => {
                        return new BindingAspectDecoratorExpression(aspectDefinition, argumentsWeavingSettings);
                    });
                else {
                    expressionFactory = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(ex => {
                        return new MethodInvokerAspectExpression(aspectDefinition, argumentsWeavingSettings, topAspectInScopeDefinition);
                    });
                }
            }
            else {
                expressionFactory = Functional.Curry<IAspectMethodExpression, IAspectMethodExpression>(ex => {
                    return new NestedMethodInvokerAspectExpression(argumentsWeavingSettings, topAspectInScopeDefinition);
                });
            }

            return new AspectNodeExpressionBuilder(expressionFactory);
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(PropertyInterceptionAspectAttribute aspect) {
            throw new NotImplementedException();
        }
    }
}
