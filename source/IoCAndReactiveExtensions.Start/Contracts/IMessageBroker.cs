using System;
using System.Reactive.Concurrency;

namespace IoCAndReactiveExtensions.Start.Contracts
{
    public interface IMessageBroker
    {
        IObservable<object> Stream { get; }
        IDisposable Register<T>(Action<T> action);
        IDisposable Register<T>(Action<T> action, IScheduler scheduler);
        IDisposable Register<T>(Action<T> action, Func<T, bool> predicate);
        IDisposable Register<T>(Action<T> action, Func<T, bool> predicate, IScheduler scheduler);
        void Bridge<T>(Action<T> fromEvent);
        IDisposable Register<T1, T2>(Action<Tuple<T1, T2>> action);
        IDisposable Register<T1, T2>(Action<Tuple<T1, T2>> action, IScheduler scheduler);
        IDisposable Register<T1, T2, TResult>(Action<TResult> action, Func<T1, T2, TResult> selector);

        IDisposable Register<T1, T2, TResult>(Action<TResult> action,
                                                              Func<T1, T2, TResult> selector,
                                                              IScheduler scheduler);

        void Send<T>(T message);
    }
}