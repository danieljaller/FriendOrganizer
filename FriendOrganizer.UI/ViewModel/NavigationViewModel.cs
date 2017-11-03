using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.Event;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private readonly IFriendLookupDataService _friendLookupService;
        private readonly IEventAggregator _eventAggregator;

        public NavigationViewModel(IFriendLookupDataService friendLookupService, IEventAggregator eventAggregator)
        {
            _friendLookupService = friendLookupService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
            Friends = new ObservableCollection<NavigationItemViewModel>();

        }

        private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
        {
            var lookupItem = Friends.SingleOrDefault(l => l.Id == obj.Id);
            if (lookupItem == null)
                Friends.Add(new NavigationItemViewModel(obj.DisplayMember, obj.Id, _eventAggregator));

            else
                lookupItem.DisplayMember = obj.DisplayMember;
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; set; }

        public async Task LoadAsync()
        {
            var lookup = await _friendLookupService.GetFriendLookupAsync();

            foreach (var lookupItem in lookup)
            {
                Friends.Add(new NavigationItemViewModel(lookupItem.DisplayMember, lookupItem.Id, _eventAggregator));
            }
        }
    }
}
