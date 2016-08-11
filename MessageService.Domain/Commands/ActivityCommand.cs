using MessageService.Domain.Model;
using System;

namespace MessageService.Domain.Commands
{
    /// <summary>
    /// Abstract base to Activity
    /// </summary>
    /// <seealso cref="MessageService.Domain.Command" />
    [Serializable]
    public abstract class ActivityCommand : Command
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public ActivityId Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityCommand"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected ActivityCommand(ActivityId id)
        {
            this.Id = id;
        }
    }
}
