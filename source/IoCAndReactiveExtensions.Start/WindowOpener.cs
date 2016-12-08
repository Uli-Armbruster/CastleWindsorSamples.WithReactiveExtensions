using System;
using System.Windows.Forms;

using Castle.Core;
using Castle.Windsor;

using IoCAndReactiveExtensions.Start.Contracts;

namespace IoCAndReactiveExtensions.Start
{
    internal class WindowOpener : IStartable
    {
        private IDisposable _subscription;
        private readonly IMessageBroker _messageBroker;
        private readonly IWindsorContainer _container;

        public WindowOpener(IMessageBroker messageBroker, IWindsorContainer container)
        {
            _messageBroker = messageBroker;
            _container = container;
        }

        public void Start()
        {
            _subscription = _messageBroker.Register<IOpenWindow>(OpenWindow);
        }

        public void Stop()
        {
            _subscription?.Dispose();
        }

        private void OpenWindow(IOpenWindow openEvent)
        {
            var formNameInContainer = FormNameByConvention(openEvent);
            var formInstance = _container.Resolve<Form>(formNameInContainer);

            formInstance.Closed += ReleaseWindowFromContainer;
            formInstance.Show();

            _messageBroker.Send(new SystemEvent { Message = $"form \'{formInstance.Name}\' created" });
        }

        private static string FormNameByConvention(IOpenWindow openEvent)
        {
            return openEvent.GetType().FullName
                            .Replace(".Contracts", string.Empty)
                            .Replace("Open", string.Empty);
        }

        private void ReleaseWindowFromContainer(object sender, EventArgs args)
        {
            var form = sender as Form;

            if (form == null)
            {
                return;
            }

            var formName = form.Name;
            form.Closed -= ReleaseWindowFromContainer;

            _container.Release(sender);
            _messageBroker.Send(new SystemEvent { Message = $"form \'{formName}\' disposed" });
        }
    }
}
