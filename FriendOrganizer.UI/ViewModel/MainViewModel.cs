using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private Func<IFriendDetailsViewModel> _friendDetailsViewModelCreator;
        private IFriendDetailsViewModel _friendDetailsViewModel;
        public INavigationViewModel NavigationViewModel { get; }

        public MainViewModel(INavigationViewModel navigationViewModel, Func<IFriendDetailsViewModel> friendDetailsViewModelCreator, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _friendDetailsViewModelCreator = friendDetailsViewModelCreator;
            _eventAggregator.GetEvent<OpenFriendDetailsViewEvent>().Subscribe(OnOpenFriendDetailsView);
            NavigationViewModel = navigationViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public IFriendDetailsViewModel FriendDetailsViewModel
        {
            get { return _friendDetailsViewModel; }
            private set
            {
                _friendDetailsViewModel = value; 
                OnPropertyChanged();
            }
        }

        private async void OnOpenFriendDetailsView(int friendId)
        {
            if (FriendDetailsViewModel != null && FriendDetailsViewModel.HasChanges)
            {
                var result = MessageBox.Show("You've made changes. Navigate away?", "Question", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.Cancel)
                    return;
            }
            FriendDetailsViewModel = _friendDetailsViewModelCreator();
            await FriendDetailsViewModel.LoadAsync(friendId);
        }

    }
}