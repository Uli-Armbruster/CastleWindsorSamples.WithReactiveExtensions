using Castle.Windsor;

namespace IoCAndReactiveExtensions.Start
{
    internal class Bootstrapper
    {
        public static IWindsorContainer Execute()
        {
            var container = new WindsorContainer();
            container.Install(new Installer());
            return container;
        }
    }
}
