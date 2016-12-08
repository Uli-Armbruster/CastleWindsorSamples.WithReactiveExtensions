using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;
using System.Windows.Forms;

using IoCAndReactiveExtensions.Start.Contracts;

namespace IoCAndReactiveExtensions.Start
{
    public partial class FormMain : Form
    {
        private readonly IMessageBroker _messageBroker;
        private IDisposable _subscription;

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(IMessageBroker messageBroker) : this()
        {
            _messageBroker = messageBroker;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            _subscription = new CompositeDisposable
            {
                _messageBroker.Register<DaemonEvent>(HandleDaemonEvent,
                                                     new SynchronizationContextScheduler(SynchronizationContext.Current)),

                _messageBroker.Register<SystemEvent>(HandleSystemEvent,
                                                     new SynchronizationContextScheduler(SynchronizationContext.Current))
            };

            _messageBroker.Send(new SystemEvent { Message = $"{Name} subscribed to all events" });
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _subscription?.Dispose();
        }

        private void HandleDaemonEvent(DaemonEvent @event)
        {
            listBox1.Items.Add(@event.Message);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void HandleSystemEvent(SystemEvent @event)
        {
            listBox2.Items.Add(@event.Message);
            listBox2.SelectedIndex = listBox2.Items.Count - 1;
        }

        private void ControlOpenWindow1_Click(object sender, EventArgs e)
        {
            _messageBroker.Send(new OpenDaemon1Listener());
        }

        private void ControlOpenWindow2_Click(object sender, EventArgs e)
        {
            _messageBroker.Send(new OpenDaemon2Listener());
        }
    }
}
