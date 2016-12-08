using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

using Castle.Core;

using IoCAndReactiveExtensions.Start.Contracts;

namespace IoCAndReactiveExtensions.Start.Daemons
{
    /// <summary>
    /// Dummy daemon that produces a message every 3 seconds
    /// </summary>
    internal class Daemon1 : IStartable
    {
        private readonly IMessageBroker _messageBroker;
        private IDisposable _subscription;
        private int _seconds;

        public Daemon1(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public void Start()
        {
            var observable = Observable.Interval(TimeSpan.FromSeconds(3), NewThreadScheduler.Default);

            _subscription = observable.Do(_ => SendTimeInformation()).Subscribe();
        }

        private void SendTimeInformation()
        {
            _seconds += 3;
            _messageBroker.Send(new DaemonEvent
                                {
                                    Message = $"Daemon1 says: {_seconds} seconds over"
                                });
        }

        public void Stop()
        {
            _subscription?.Dispose();
        }
    }
}
