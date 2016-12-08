using System;
using System.Reactive.Concurrency;
using System.Threading;
using System.Windows.Forms;

using IoCAndReactiveExtensions.Start.Contracts;

namespace IoCAndReactiveExtensions.Start
{
    public partial class Daemon2Listener : Form
    {
        private readonly IMessageBroker _messageBroker;
        private IDisposable _subscription;

        public Daemon2Listener()
        {
            InitializeComponent();
        }

        public Daemon2Listener(IMessageBroker messageBroker) : this()
        {
            _messageBroker = messageBroker;
        }

        private void Daemon2Listener_Shown(object sender, EventArgs e)
        {
            _subscription = _messageBroker
                .Register<DaemonEvent>(
                                       HandleMessage,
                                       new SynchronizationContextScheduler(SynchronizationContext.Current)
                                      );

            _messageBroker.Send(new SystemEvent { Message = $"{Name} subscribed to Daemon events" });
        }

        private void Daemon2Listener_FormClosed(object sender, FormClosedEventArgs e)
        {
            _subscription?.Dispose();
            _messageBroker.Send(new SystemEvent { Message = $"{Name} disposed its subscriptions" });
        }

        private void HandleMessage(DaemonEvent @event)
        {
            if (!@event.Message.Contains("Daemon2"))
            {
                return;
            }

            listBox1.Items.Add(@event.Message);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
    }
}
