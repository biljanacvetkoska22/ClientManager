using ClientOrganizer.Model;
using ClientOrganizer.UI.Data;
using ClientOrganizer.UI.Data.Lookups;
using ClientOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IClientLookupDataService _clientLookupService;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<NavigationItemViewModel> Clients { get; }

        public NavigationViewModel(IClientLookupDataService clientLookupService,
            IEventAggregator eventAggregator)
        {
            _clientLookupService = clientLookupService;
            _eventAggregator = eventAggregator;
            Clients = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterClientSavedEvent>().Subscribe(AfterClientSaved);
            _eventAggregator.GetEvent<AfterClientDeletedEvent>().Subscribe(AfterClientDeleted);
        }       

        public async Task LoadAsync()
        {
            var lookup = await _clientLookupService.GetClientLookupAsync();
            Clients.Clear();
            foreach (var item in lookup)
            {
                Clients.Add(new NavigationItemViewModel(item.Id, item.DisplayMember,
                    _eventAggregator));
            }
        }

        private void AfterClientDeleted(int partyId)
        {
            var client = Clients.SingleOrDefault(c => c.Id == partyId);
            if(client!=null)
            {
                Clients.Remove(client);
            }
        }

        private void AfterClientSaved(AfterClientSavedEventArgs obj)
        {
            var lookupItem = Clients.SingleOrDefault(l => l.Id == obj.Id); // returns null if it doesn't exist
            if (lookupItem == null)
            {
                Clients.Add(new NavigationItemViewModel(obj.Id, obj.DisplayMember,
                    _eventAggregator));
            }
            else
            {
                lookupItem.DisplayMember = obj.DisplayMember;
            }
        }
    }
}
