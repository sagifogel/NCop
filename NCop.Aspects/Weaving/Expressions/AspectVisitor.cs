using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Extensions;
using NCop.Aspects.Framework;
using NCop.Core;
using System;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectVisitor : IAspectDefinitionVisitor
    {
        private struct Aspect
        {
            public bool Top { get; set; }
            public bool IsInBinding { get; set; }
            public bool IsTopBinding { get; set; }
        }

        private Aspect lastAspect = new Aspect { Top = true };
        private IAspectDefinition topAspectInScopeDefinition = null;

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(OnMethodBoundaryAspectAttribute aspect) {
            return aspectDefinition => {
                Func<IAspectExpression, IAspectExpression> ctor = null;
                var _topAspectInScopeDefinition = topAspectInScopeDefinition;
                var methodAspectDefinition = aspectDefinition as IMethodAspectDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new TopOnMethodBoundaryAspectExpression(expression, methodAspectDefinition);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        if (lastAspect.IsTopBinding) {
                            lastAspect.IsTopBinding = false;

                            ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                                return new TopBindingOnMethodBoundaryAspectExpression(expression, methodAspectDefinition);
                            });
                        }
                        else {
                            ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                                return new BindingOnMethodBoundaryAspectExpression(expression, methodAspectDefinition, _topAspectInScopeDefinition);
                            });
                        }
                    }
                    else {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new NestedOnMethodBoundaryAspectExpression(expression, methodAspectDefinition);
                        });
                    }
                }

                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(MethodInterceptionAspectAttribute aspect) {
            return aspectDefinition => {
                Func<IAspectExpression, IAspectExpression> ctor = null;
                var _topAspectInScopeDefinition = (IMethodAspectDefinition)topAspectInScopeDefinition;
                var methodAspectDefinition = aspectDefinition as IMethodAspectDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new TopMethodInterceptionAspectExpression(expression, methodAspectDefinition);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        if (lastAspect.IsTopBinding) {
                            lastAspect.IsTopBinding = false;

                            ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                                return new TopBindingMethodInterceptionAspectExpression(expression, methodAspectDefinition);
                            });
                        }
                        else {
                            ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                                return new BindingMethodInterceptionAspectExpression(expression, methodAspectDefinition, _topAspectInScopeDefinition);
                            });
                        }
                    }
                    else {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new NestedMethodInterceptionAspectExpression(expression, methodAspectDefinition, _topAspectInScopeDefinition);
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
            var methodAspectDefinition = aspectDefinition as IMethodAspectDefinition;

            if (lastAspect.IsInBinding) {
                if (topAspectInScopeDefinition.AspectType == AspectType.MethodInterceptionAspect) {
                    expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new BindingMethodAspectDecoratorExpression(methodAspectDefinition, argumentsWeavingSettings);
                    });
                }
                else if (topAspectInScopeDefinition.IsPropertyAspectDefinition()) {
                    var propertyAspectDefinition = (IPropertyAspectDefinition)topAspectInScopeDefinition;

                    expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        if (topAspectInScopeDefinition.IsGetPropertyAspectDefinition()) {
                            return new BindingGetPropertyAspectDecoratorExpression(propertyAspectDefinition);
                        }

                        return new BindingSetPropertyAspectDecoratorExpression(propertyAspectDefinition);
                    });
                }
                else if (topAspectInScopeDefinition.IsEventAspectDefinition()) {
                    var eventAspectDefinition = (IEventAspectDefinition)topAspectInScopeDefinition;

                    if (topAspectInScopeDefinition.AspectType == AspectType.AddEventInterceptionAspect) {
                        expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new BindingAddEventAspectDecoratorExpression(eventAspectDefinition);
                        });
                    }
                    else if (topAspectInScopeDefinition.AspectType == AspectType.RemoveEventInterceptionAspect) {
                        expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new BindingRemoveEventAspectDecoratorExpression(eventAspectDefinition);
                        });
                    }
                    else {
                        expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new BindingRaiseEventAspectDecoratorExpression(eventAspectDefinition);
                        });
                    }
                }
                else {
                    expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new MethodInvokerAspectExpression(methodAspectDefinition, argumentsWeavingSettings, (IMethodAspectDefinition)topAspectInScopeDefinition);
                    });
                }
            }
            else {
                expressionFactory = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                    return new NestedMethodInvokerAspectExpression(argumentsWeavingSettings, (IMethodAspectDefinition)topAspectInScopeDefinition);
                });
            }

            return new AspectNodeExpressionBuilder(expressionFactory);
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(GetPropertyInterceptionAspect aspect) {
            return aspectDefinition => {
                Func<IAspectExpression, IAspectExpression> ctor = null;
                var propertyAspectDefinition = aspectDefinition as IPropertyAspectDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new TopGetPropertyInterceptionAspectExpression(expression, propertyAspectDefinition);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new BindingGetPropertyInterceptionAspectExpression(expression, propertyAspectDefinition);
                        });
                    }
                }

                lastAspect.IsInBinding = true;
                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(SetPropertyInterceptionAspect aspect) {
            return aspectDefinition => {
                Func<IAspectExpression, IAspectExpression> ctor = null;
                var propertyAspectDefinition = aspectDefinition as IPropertyAspectDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new TopSetPropertyInterceptionAspectExpression(expression, propertyAspectDefinition);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new BindingSetPropertyInterceptionAspectExpression(expression, propertyAspectDefinition);
                        });
                    }
                }

                lastAspect.IsInBinding = true;
                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(GetPropertyFragmentInterceptionAspect aspect) {
            return aspectDefinition => {
                Func<IAspectExpression, IAspectExpression> ctor = null;
                var propertyAspectDefinition = (IFullPropertyAspectDefinition)aspectDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        var propertyBuilder = propertyAspectDefinition.PropertyBuilder;

                        propertyBuilder.SetGetExpression(expression);

                        return new TopGetPropertyFragmentInterceptionAspectExpression(expression, propertyAspectDefinition, propertyBuilder);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            var propertyBuilder = propertyAspectDefinition.PropertyBuilder;

                            propertyBuilder.SetGetExpression(expression);

                            return new BindingGetPropertyFragmentInterceptionAspectExpression(expression, propertyAspectDefinition, propertyBuilder);
                        });
                    }
                }

                lastAspect.IsInBinding = true;
                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(SetPropertyFragmentInterceptionAspect aspect) {
            return aspectDefinition => {
                Func<IAspectExpression, IAspectExpression> ctor = null;
                var propertyAspectDefinition = (IFullPropertyAspectDefinition)aspectDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        var propertyBuilder = propertyAspectDefinition.PropertyBuilder;

                        propertyBuilder.SetSetExpression(expression);

                        return new TopSetPropertyFragmentInterceptionAspectExpression(expression, propertyAspectDefinition, propertyBuilder);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            var propertyBuilder = propertyAspectDefinition.PropertyBuilder;

                            propertyBuilder.SetSetExpression(expression);

                            return new BindingSetPropertyFragmentInterceptionAspectExpression(expression, propertyAspectDefinition, propertyBuilder);
                        });
                    }
                }

                lastAspect.IsInBinding = true;
                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(AddEventFragmentInterceptionAspect aspect) {
            return aspectDefinition => {
                Func<IAspectExpression, IAspectExpression> ctor = null;
                var eventAspectDefinition = (IFullEventAspectDefinition)aspectDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        var eventBuilder = eventAspectDefinition.EventBuilder;

                        eventBuilder.SetAddExpression(expression);

                        return new TopAddEventFragmentInterceptionAspectExpression(expression, eventAspectDefinition, eventBuilder);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            var eventBuilder = eventAspectDefinition.EventBuilder;

                            eventBuilder.SetAddExpression(expression);

                            return new BindingAddEventFragmentInterceptionAspectExpression(expression, eventAspectDefinition, eventBuilder);
                        });
                    }
                }

                lastAspect.IsInBinding = true;
                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(RemoveEventFragmentInterceptionAspect aspect) {
            return aspectDefinition => {
                Func<IAspectExpression, IAspectExpression> ctor = null;
                var eventAspectDefinition = (IFullEventAspectDefinition)aspectDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        var eventBuilder = eventAspectDefinition.EventBuilder;

                        eventBuilder.SetRemoveExpression(expression);

                        return new TopRemoveEventFragmentInterceptionAspectExpression(expression, eventAspectDefinition, eventBuilder);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            var eventBuilder = eventAspectDefinition.EventBuilder;

                            eventBuilder.SetRemoveExpression(expression);

                            return new BindingRemoveEventFragmentInterceptionAspectExpression(expression, eventAspectDefinition, eventBuilder);
                        });
                    }
                }

                lastAspect.IsInBinding = true;
                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(RaiseEventFragmentInterceptionAspect aspect) {
            return aspectDefinition => {
                Func<IAspectExpression, IAspectExpression> ctor = null;
                var eventAspectDefinition = (IFullEventAspectDefinition)aspectDefinition;

                if (lastAspect.Top) {
                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        var eventBuilder = eventAspectDefinition.EventBuilder;

                        eventBuilder.SetInvokeExpression(expression);

                        return new TopRaiseEventFragmentInterceptionAspectExpression(expression, eventAspectDefinition, eventBuilder);
                    });

                    lastAspect = new Aspect();
                }
                else {
                    if (lastAspect.IsInBinding) {
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            var eventBuilder = eventAspectDefinition.EventBuilder;

                            eventBuilder.SetInvokeExpression(expression);

                            return new BindingRaiseEventFragmentInterceptionAspectExpression(expression, eventAspectDefinition, eventBuilder);
                        });
                    }
                }

                lastAspect.IsInBinding = true;
                topAspectInScopeDefinition = aspectDefinition;

                return new AspectNodeExpressionBuilder(ctor);
            };
        }
    }
}
