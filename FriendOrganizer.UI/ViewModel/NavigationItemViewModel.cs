using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private IEventAggregator _eventAggregator;

        public NavigationItemViewModel(string displayMember, int id, IEventAggregator eventAggregator)
        {
            _displayMember = displayMember;
            _eventAggregator = eventAggregator;
            Id = id;
            OpenFriendDetailViewCommand = new DelegateCommand(OnOpenFriendDetailView);

        }

        public ICommand OpenFriendDetailViewCommand { get; set; }

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        private void OnOpenFriendDetailView()
        {
            _eventAggregator.GetEvent<OpenFriendDetailsViewEvent>()
                .Publish(Id);
        }
    }
}
