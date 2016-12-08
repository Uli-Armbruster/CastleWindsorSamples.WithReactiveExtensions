using System;
using System.Reactive.Concurrency;
using System.Threading;
using System.Windows.Forms;

using IoCAndReactiveExtensions.Start.Contracts;

namespace IoCAndReactiveExtensions.Start
{
    public partial class FormMain : Form
    {
        private readonly IMessageBroker _messageBroker;

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(IMessageBroker messageBroker) : this()
        {
            _messageBroker = messageBroker;
            ListenToDaemons();
        }

        private void ListenToDaemons()
        {
            _messageBroker
                .Register<DaemonMessage>(
                                         HandleMessage,
                                         new SynchronizationContextScheduler(SynchronizationContext.Current)
                                        );
        }

        private void HandleMessage(DaemonMessage message)
        {
            textBox1.Text += $"{message.Message}{Environment.NewLine}";
        }
    }
}
