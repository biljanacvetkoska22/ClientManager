using Autofac;
using ClientOrganizer.DataAccess;
using ClientOrganizer.UI.Data;
using ClientOrganizer.UI.Data.Lookups;
using ClientOrganizer.UI.Data.Repositories;
using ClientOrganizer.UI.View.Services;
using ClientOrganizer.UI.ViewModel;
using Prism.Events;

namespace ClientOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public Autofac.IContainer Bootstrap()
        {
            var builder = new ContainerBuilder(); // using Autofac as dependency injection

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<ClientOrganizerDbContext>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();

            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<ClientDetailViewModel>().As<IClientDetailViewModel>();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();// so that LookupDataService instance will be injected by Autofac for the interfaces that are implemented by the LookupDataService 
            builder.RegisterType<ClientRepository>().As<IClientRepository>();

            return builder.Build();
        }
    }
}
