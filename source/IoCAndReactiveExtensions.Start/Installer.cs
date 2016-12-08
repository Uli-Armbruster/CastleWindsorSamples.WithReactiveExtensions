using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Castle.Core;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using IoCAndReactiveExtensions.Start.Contracts;

using Minimod.RxMessageBroker;

namespace IoCAndReactiveExtensions.Start
{
    internal class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            AddStartableFacility(container);

            container.Register(Registrations().ToArray());

            //hack: register container itself
            container.Register(Component.For<IWindsorContainer>().Instance(container));
        }

        private static void AddStartableFacility(IWindsorContainer container)
        {
            if (container.Kernel.GetFacilities().Any(x => x is StartableFacility))
            {
                return;
            }

            var facility = new StartableFacility();
            facility.DeferredStart();
            container.AddFacility(facility);
        }

        private static IEnumerable<IRegistration> Registrations()
        {
            yield return Classes
                .FromThisAssembly()
                .IncludeNonPublicTypes()
                .BasedOn<IStartable>()
                .WithServiceAllInterfaces()
                .LifestyleSingleton();

            yield return Component
                .For<IMessageBroker>()
                .Instance(RxMessageBrokerMinimod.Default);

            yield return Classes
                .FromThisAssembly()
                .IncludeNonPublicTypes()
                .BasedOn<Form>()
                .WithServiceBase()
                .WithServiceSelf()
                .LifestyleTransient();
        }
    }
}
