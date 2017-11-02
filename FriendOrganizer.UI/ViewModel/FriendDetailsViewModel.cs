using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailsViewModel : ViewModelBase, IFriendDetailsViewModel
    {
        private readonly IFriendDataService _dataService;
        private readonly IEventAggregator _eventAggregator;
        private FriendWrapper _friend;

        public FriendDetailsViewModel(IFriendDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenFriendDetailsViewEvent>().Subscribe(OnOpenFriendDetailsView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public async Task LoadAsync(int friendId)
        {
            var friend = await _dataService.GetByIdAsync(friendId);

            Friend = new FriendWrapper(friend);
        }


        public FriendWrapper Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private async void OnSaveExecute()
        {
            await _dataService.SaveAsync(Friend.Model);

            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(new AfterFriendSavedEventArgs()
            {
                Id = Friend.Id,
                DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
            });
        }

        private async void OnOpenFriendDetailsView(int friendId)
        {
            await LoadAsync(friendId);
        }
    }
}
