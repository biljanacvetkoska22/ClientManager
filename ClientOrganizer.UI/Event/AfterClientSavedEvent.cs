using Prism.Events;

namespace ClientOrganizer.UI.Event
{
    public class AfterClientSavedEvent : PubSubEvent<AfterClientSavedEventArgs>
    {

    }

    public class AfterClientSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
