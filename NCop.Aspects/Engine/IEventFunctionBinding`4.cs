﻿using System;

namespace NCop.Aspects.Engine
{
    public interface IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TResult>
    {
        void AddHandler(ref TInstance instance, Func<TArg1, TArg2, TArg3, TArg4, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> args);
        void RemoveHandler(ref TInstance instance, Func<TArg1, TArg2, TArg3, TArg4, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> args);
        TResult InvokeHandler(ref TInstance instance, Func<TArg1, TArg2, TArg3, TArg4, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> args);
    }
}
