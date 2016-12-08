using Castle.Windsor;

namespace IoCAndReactiveExtensions.Start
{
    internal class Bootstrapper
    {
        public IWindsorContainer Execute()
        {
            var container = new WindsorContainer();
            container.Install(new Installer());
            return container;
        }
    }
}
