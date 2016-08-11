using MessageService.Domain.Model;

namespace MessageService.Domain.Events
{
    /// <summary>
    /// Abstract base to Activity event
    /// </summary>
    /// <seealso cref="MessageService.Domain.Event" />
    public abstract class ActivityEvent : Event
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public ActivityId Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityEvent"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected ActivityEvent(ActivityId id)
        {
            this.Id = id;
        }
    }
}
