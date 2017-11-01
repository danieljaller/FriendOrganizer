﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : INavigationViewModel
    {
        private readonly IFriendLookupDataService _friendLookupService;

        public NavigationViewModel(IFriendLookupDataService friendLookupService)
        {
            _friendLookupService = friendLookupService;
            Friends = new ObservableCollection<LookupItem>();
        }

        public ObservableCollection<LookupItem> Friends { get; set; }

        public async Task LoadAsync()
        {
            var lookup = await _friendLookupService.GetFriendLookupAsync();

            foreach (var lookupItem in lookup)
            {
                Friends.Add(lookupItem);
            }
        }
    }
}
