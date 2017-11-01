using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public INavigationViewModel NavigationViewModel { get; }
        public IFriendDetailsViewModel FriendDetailsViewModel { get; }

        public MainViewModel(INavigationViewModel navigationViewModel, IFriendDetailsViewModel friendDetailsViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendDetailsViewModel = friendDetailsViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

    }
}