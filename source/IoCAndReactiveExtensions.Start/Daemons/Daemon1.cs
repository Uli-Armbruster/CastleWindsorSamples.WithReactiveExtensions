using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

using Castle.Core;

using IoCAndReactiveExtensions.Start.Contracts;

using Minimod.RxMessageBroker;

namespace IoCAndReactiveExtensions.Start.Daemons
{
    internal class Daemon1 : IStartable
    {
        private readonly IMessageBroker _messageBroker;
        private IDisposable _subscription;

        public Daemon1(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public void Start()
        {
            var observable = Observable.Interval(TimeSpan.FromSeconds(3), NewThreadScheduler.Default);

            _subscription = observable.Do(SendTimeInformation).Subscribe();
        }

        private void SendTimeInformation(long seconds)
        {
            _messageBroker.Send(new DaemonMessage
                                                {
                                                    Message = $"Daemon1 says: {seconds} seconds over"
                                                });
        }

        public void Stop()
        {
            _subscription?.Dispose();
        }
    }
}
