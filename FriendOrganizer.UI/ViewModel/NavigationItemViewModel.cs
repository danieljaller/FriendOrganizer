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
        private readonly string _detailViewModelName;
        private IEventAggregator _eventAggregator;

        public NavigationItemViewModel(string displayMember, int id, string detailViewModelName, IEventAggregator eventAggregator)
        {
            _displayMember = displayMember;
            _detailViewModelName = detailViewModelName;
            _eventAggregator = eventAggregator;
            Id = id;
            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExcecute);

        }

        public ICommand OpenDetailViewCommand { get; set; }

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

        private void OnOpenDetailViewExcecute()
        {
            _eventAggregator.GetEvent<OpenDetailsViewEvent>()
                .Publish(
                new OpenDetailViewEventArgs()
                {
                    Id = Id,
                    ViewModelName = _detailViewModelName
                });
        }
    }
}
