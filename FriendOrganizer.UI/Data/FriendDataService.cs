using System.Collections.Generic;
using System.Linq;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAllFriends()
        {
            using (var context = new FriendOrganizerDbContext())
            {
                return context.Friends.AsNoTracking().ToList();
            }
        }
    }
}
