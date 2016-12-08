using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

using Castle.Core;

using IoCAndReactiveExtensions.Start.Contracts;

using Minimod.RxMessageBroker;

namespace IoCAndReactiveExtensions.Start.Daemons
{
    internal class Daemon2 : IStartable
    {
        private readonly IMessageBroker _messageBroker;
        private IDisposable _subscription;

        public Daemon2(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public void Start()
        {
            var observable = Observable.Interval(TimeSpan.FromSeconds(5), NewThreadScheduler.Default);

            _subscription = observable.Subscribe(SendTimeInformation);
        }

        private void SendTimeInformation(long seconds)
        {
            _messageBroker.Send(new DaemonMessage
                                                {
                                                    Message = $"Daemon2 says: {seconds} seconds over"
                                                });
        }

        public void Stop()
        {
            _subscription?.Dispose();
        }
    }
}
