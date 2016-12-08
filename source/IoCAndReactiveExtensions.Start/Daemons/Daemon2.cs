using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

using Castle.Core;

using IoCAndReactiveExtensions.Start.Contracts;

namespace IoCAndReactiveExtensions.Start.Daemons
{
    /// <summary>
    /// Dummy daemon that produces a message every 7 seconds
    /// </summary>
    internal class Daemon2 : IStartable
    {
        private readonly IMessageBroker _messageBroker;
        private IDisposable _subscription;
        private int _seconds;

        public Daemon2(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public void Start()
        {
            var observable = Observable.Interval(TimeSpan.FromSeconds(7), NewThreadScheduler.Default);

            _subscription = observable.Do(_ => SendTimeInformation()).Subscribe();
        }

        private void SendTimeInformation()
        {
            _seconds += 7;
            _messageBroker.Send(new DaemonEvent
                                {
                                    Message = $"Daemon2 says: {_seconds} seconds over"
                                });
        }

        public void Stop()
        {
            _subscription?.Dispose();
        }
    }
}
