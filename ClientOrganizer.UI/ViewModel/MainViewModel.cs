using ClientOrganizer.UI.Event;
using ClientOrganizer.UI.View.Services;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientOrganizer.UI.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {       

        public INavigationViewModel NavigationViewModel { get; }        
        public ICommand CreateNewClientCommand { get; }

        private IEventAggregator _eventAggregator;
        private IClientDetailViewModel _clientDetailViewModel;
        private Func<IClientDetailViewModel> _clientDetailViewModelCreator;
        private IMessageDialogService _messageDialogService;

        public MainViewModel(INavigationViewModel navigationViewModel,
            Func<IClientDetailViewModel> clientDetailViewModelCreator,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _eventAggregator = eventAggregator;
            _clientDetailViewModelCreator = clientDetailViewModelCreator;
            _messageDialogService = messageDialogService;

            _eventAggregator.GetEvent<OpenClientDetailViewEvent>()
                .Subscribe(OnOpenClientDetaiView);
            _eventAggregator.GetEvent<AfterClientDeletedEvent>().Subscribe(AfterClientDeleted);

            CreateNewClientCommand = new DelegateCommand(OnCreateNewClientExecute);

            NavigationViewModel = navigationViewModel;
        }

        public async Task LoadAsynch()
        {
            await NavigationViewModel.LoadAsync();
        }

        public IClientDetailViewModel ClientDetailViewModel
        {
            get { return _clientDetailViewModel; }
            private set
            {
                _clientDetailViewModel = value;
                OnPropertyChanged();
            }
        }

        private async void OnOpenClientDetaiView(int? partyId)
        {
            if(ClientDetailViewModel!=null && ClientDetailViewModel.HasChanges)
            {
                var result = _messageDialogService.ShowOkCancelDialog("You've made changes. Navigate away?", "Question");
                if(result == MessageDialogResult.Cancel)
                {
                    return;
                }
            }
            ClientDetailViewModel = _clientDetailViewModelCreator();
            await ClientDetailViewModel.LoadAsync(partyId);
        }

        private void OnCreateNewClientExecute()
        {
            OnOpenClientDetaiView(null);
        }

        private void AfterClientDeleted(int partyId)
        {
            ClientDetailViewModel = null;
        }

    }
}
