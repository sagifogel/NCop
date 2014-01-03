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
        private enum AspectType
        {
            None,
            OnMethodBoundaryAspect,
            TopMethodBoundaryAspect,
            MethodInterceptionAspect,
            TopMethodInterceptionAspect
        }

        private AspectType lastAspectType;

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(OnMethodBoundaryAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                Func<IAspectExpression, IAspectExpression> ctor = null;

                if (lastAspectType == AspectType.None) {
                    lastAspectType = AspectType.TopMethodBoundaryAspect;

                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new TopOnMethodBoundaryAspectExpression(expression, aspectDefinition);
                    });
                }
                else {

                    ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                        return new OnMethodBoundaryAspectExpression(expression, aspectDefinition);
                    });
                }

                return new AspectNodeExpressionBuilder(ctor);
            };
        }

        public Func<IAspectDefinition, IAspectExpressionBuilder> Visit(MethodInterceptionAspectAttribute aspect) {
            return (IAspectDefinition aspectDefinition) => {
                Func<IAspectExpression, IAspectExpression> ctor = null;

                switch (lastAspectType) {
                    case AspectType.None:
                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new TopMethodInterceptionAspectExpression(expression, aspectDefinition);
                        });

                        lastAspectType = AspectType.TopMethodInterceptionAspect;
                        break;

                    case AspectType.OnMethodBoundaryAspect:
                    case AspectType.TopMethodBoundaryAspect:
                    case AspectType.MethodInterceptionAspect:
                    case AspectType.TopMethodInterceptionAspect:

                        ctor = Functional.Curry<IAspectExpression, IAspectExpression>(expression => {
                            return new MethodInterceptionAspectExpression(expression, aspectDefinition);
                        });

                        lastAspectType = AspectType.OnMethodBoundaryAspect;
                        break;
                }

                return new AspectNodeExpressionBuilder(ctor);
            };
        }
    }
}
