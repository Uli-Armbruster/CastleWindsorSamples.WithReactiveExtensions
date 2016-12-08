using System;
using System.Reactive.Concurrency;
using System.Threading;
using System.Windows.Forms;

using IoCAndReactiveExtensions.Start.Contracts;

namespace IoCAndReactiveExtensions.Start
{
    public partial class Daemon1Listener : Form
    {
        private readonly IMessageBroker _messageBroker;
        private IDisposable _subscription;

        public Daemon1Listener()
        {
            InitializeComponent();
        }

        public Daemon1Listener(IMessageBroker messageBroker) : this()
        {
            _messageBroker = messageBroker;
        }

        private void Daemon1Listener_Shown(object sender, EventArgs e)
        {
            _subscription = _messageBroker
                .Register<DaemonEvent>(
                                       HandleMessage,
                                       new SynchronizationContextScheduler(SynchronizationContext.Current)
                                      );

            _messageBroker.Send(new SystemEvent { Message = $"{Name} subscribed to Daemon events" });
        }

        private void HandleMessage(DaemonEvent @event)
        {
            if (!@event.Message.Contains("Daemon1"))
            {
                return;
            }

            listBox1.Items.Add(@event.Message);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void Daemon1Listener_FormClosed(object sender, FormClosedEventArgs e)
        {
            _subscription?.Dispose();
            _messageBroker.Send(new SystemEvent { Message = $"{Name} disposed its subscriptions" });
        }
    }
}
