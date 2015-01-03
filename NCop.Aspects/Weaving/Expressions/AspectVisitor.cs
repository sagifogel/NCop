using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Extensions;
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
            return aspectDefinition => {
                var _topAspectInScopeDefinition = topAspectInScopeDefinition;
                Func<IAspectExpression, IAspectExpression> ctor = null;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new TopOnMethodBoundaryAspectExpression(expression, aspectDefinition);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        if (lastAspect.IsTopBinding) {
                            lastAspect.IsTopBinding = false;

                            ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                                return new TopBindingOnMethodBoundaryAspectExpression(expression, aspectDefinition);
                            });
                        }
                        else {
                            ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                                return new BindingOnMethodBoundaryAspectExpression(expression, aspectDefinition, _topAspectInScopeDefinition);
                            });
                        }
                    }
                    else {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new NestedOnMethodBoundaryAspectExpression(expression, aspectDefinition);
                        });
                    }
                }

                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(MethodInterceptionAspectAttribute aspect) {
            return aspectDefinition => {
                var _topAspectInScopeDefinition = topAspectInScopeDefinition;
                Func<IAspectExpression, IAspectExpression> ctor = null;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new TopMethodInterceptionAspectExpression(expression, aspectDefinition);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        if (lastAspect.IsTopBinding) {
                            lastAspect.IsTopBinding = false;

                            ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                                return new TopBindingMethodInterceptionAspectExpression(expression, aspectDefinition);
                            });
                        }
                        else {
                            ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                                return new BindingMethodInterceptionAspectExpression(expression, aspectDefinition, _topAspectInScopeDefinition);
                            });
                        }
                    }
                    else {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
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

        public IAspectExpressionBuilder VisitLast(IAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings) {
            Func<IAspectExpression, IAspectExpression> expressionFactory = null;

            if (lastAspect.IsInBinding) {
                if (topAspectInScopeDefinition.AspectType == AspectType.MethodInterceptionAspect) {
                    expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(ex => {
                        return new BindingMethodAspectDecoratorExpression(aspectDefinition, argumentsWeavingSettings);
                    });
                }
                else if (topAspectInScopeDefinition.IsPropertyAspectDefinition()) {
                    expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(ex => {
                        return new BindingPropertyAspectDecoratorExpression(aspectDefinition);
                    });
                }
                else {
                    expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(ex => {
                        return new MethodInvokerAspectExpression(aspectDefinition, argumentsWeavingSettings, topAspectInScopeDefinition);
                    });
                }
            }
            else {
                expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(ex => {
                    return new NestedMethodInvokerAspectExpression(argumentsWeavingSettings, topAspectInScopeDefinition);
                });
            }

            return new AspectNodeExpressionBuilder(expressionFactory);
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(GetPropertyInterceptionAspectAttribute aspect) {
            return aspectDefinition => {
                lastAspect = new Aspect();
                Func<IAspectExpression, IAspectExpression> ctor = null;

                ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                    return new TopExpressionGetPropertyInterceptionAspect(expression, aspectDefinition as IPropertyAspectDefinition);
                });

                lastAspect.IsInBinding = true;
                lastAspect.IsTopBinding = true;
                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(SetPropertyInterceptionAspectAttribute aspect) {
            return aspectDefinition => {
                lastAspect = new Aspect();
                Func<IAspectExpression, IAspectExpression> ctor = null;

                ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                    return new TopExpressionSetPropertyInterceptionAspect(expression, aspectDefinition as IPropertyAspectDefinition);
                });


                lastAspect.IsInBinding = true;
                lastAspect.IsTopBinding = true;
                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }
    }
}
