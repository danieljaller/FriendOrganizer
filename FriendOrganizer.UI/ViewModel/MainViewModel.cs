using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.View.Services;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private readonly IMessageDialogService _messageDialogService;
        private Func<IFriendDetailsViewModel> _friendDetailsViewModelCreator;
        private IFriendDetailsViewModel _friendDetailsViewModel;
        public INavigationViewModel NavigationViewModel { get; }

        public MainViewModel(INavigationViewModel navigationViewModel, Func<IFriendDetailsViewModel> friendDetailsViewModelCreator, 
            IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
        {
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;
            _friendDetailsViewModelCreator = friendDetailsViewModelCreator;
            _eventAggregator.GetEvent<OpenFriendDetailsViewEvent>().Subscribe(OnOpenFriendDetailsView);
            NavigationViewModel = navigationViewModel;

            CreateNewFriendCommand = new DelegateCommand(OnCreateNewFriendExecute);
        }

        private void OnCreateNewFriendExecute()
        {
            OnOpenFriendDetailsView(null);
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public ICommand CreateNewFriendCommand { get; }

        public IFriendDetailsViewModel FriendDetailsViewModel
        {
            get { return _friendDetailsViewModel; }
            private set
            {
                _friendDetailsViewModel = value; 
                OnPropertyChanged();
            }
        }

        private async void OnOpenFriendDetailsView(int? friendId)
        {
            if (FriendDetailsViewModel != null && FriendDetailsViewModel.HasChanges)
            {
                var result = _messageDialogService.ShowOkCancelDialog("You've made changes. Navigate away?", "Question");

                if (result == MessageDialogResult.Cancel)
                    return;
            }
            FriendDetailsViewModel = _friendDetailsViewModelCreator();
            await FriendDetailsViewModel.LoadAsync(friendId);
        }

    }
}