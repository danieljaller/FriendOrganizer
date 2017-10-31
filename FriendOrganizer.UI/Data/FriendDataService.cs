using System.Collections.Generic;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAllFriends()
        {
            yield return new Friend(){FirstName = "Bosse", LastName = "Bildoktorn"};
            yield return new Friend(){FirstName = "Posse", LastName = "Pildoktorn"};
            yield return new Friend(){FirstName = "Mosse", LastName = "Mildoktorn"};
            yield return new Friend(){FirstName = "Sosse", LastName = "Sildoktorn"};
        }
    }
}
