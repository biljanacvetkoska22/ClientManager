using ClientOrganizer.Model;
using ClientOrganizer.UI.Data;
using ClientOrganizer.UI.Data.Repositories;
using ClientOrganizer.UI.Event;
using ClientOrganizer.UI.View.Services;
using ClientOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientOrganizer.UI.ViewModel
{
    public class ClientDetailViewModel : ViewModelBase, IClientDetailViewModel
    {
        private IClientRepository _clientRepository;
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;
        private ClientWrapper _client;
        private bool _hasChanges;

        public ClientDetailViewModel(IClientRepository clientRepository,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _clientRepository = clientRepository;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDetelteExecute);
        }
       
        public async Task LoadAsync(int? partyId)
        {
            var client = partyId.HasValue ? 
                await _clientRepository.GetByIdAsync(partyId.Value)
                : CreateNewClient();
            Client = new ClientWrapper(client);

            Client.PropertyChanged += (s, e) =>
            {
                if(!HasChanges) // so that we don't call it every time 
                {
                    HasChanges = _clientRepository.HasChanges();
                }
                if (e.PropertyName == nameof(Client.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            if(Client.Id == 0)
            {
                //Full name required trigger
                Client.FullName = "";
            }
        }

        public ClientWrapper Client
        {
            get { return _client; }
            private set
            {
                _client = value;
                OnPropertyChanged();
            }
        }

       

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if(_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }                
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        private bool OnSaveCanExecute()
        {
            // check if valid
            return Client != null && !Client.HasErrors && HasChanges;
        }

        private async void OnSaveExecute()
        {
            await _clientRepository.SaveAsync();
            HasChanges = _clientRepository.HasChanges();
            _eventAggregator.GetEvent<AfterClientSavedEvent>().Publish(
                new AfterClientSavedEventArgs
                {
                    Id = Client.PartyId,
                    DisplayMember = Client.FullName
                });
        }

        private async void OnDetelteExecute()
        {
            var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete the" +
                $" client {Client.FullName} ? ", "Question");
            if(result == MessageDialogResult.OK)
            {
                _clientRepository.Remove(Client.Model);
                await _clientRepository.SaveAsync();
                _eventAggregator.GetEvent<AfterClientDeletedEvent>().Publish(Client.Id);
            }            
        }

        private Client CreateNewClient()
        {
            var client = new Client();
            _clientRepository.Add(client);
            return client;
        }
    }
}
