using Prism.Events;

namespace FriendOrganizer.UI.Event
{
    public class OpenDetailsViewEvent : PubSubEvent<OpenDetailViewEventArgs>
    {
    }

    public class OpenDetailViewEventArgs
    {
        public int? Id { get; set; }
        public string ViewModelName { get; set; }
    }
}
