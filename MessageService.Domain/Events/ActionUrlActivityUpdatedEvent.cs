using MessageService.Domain.Model;

namespace MessageService.Domain.Events
{
    public class ActionUrlActivityUpdatedEvent : ActivityEvent
    {
        public WebSite ActionUrl { get; }

        public ActionUrlActivityUpdatedEvent(ActivityId id, WebSite actionUrl)
            :base(id)
        {
            this.ActionUrl = actionUrl;
        }
    }
}
