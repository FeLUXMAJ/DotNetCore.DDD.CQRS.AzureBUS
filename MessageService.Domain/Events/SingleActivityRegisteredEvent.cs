using MessageService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain.Events
{
    /// <summary>
    /// Envet data to single activity registered
    /// </summary>
    /// <seealso cref="MessageService.Domain.Events.ActivityEvent" />
    public class SingleActivityRegisteredEvent : ActivityEvent
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; }
        /// <summary>
        /// Gets the create by.
        /// </summary>
        /// <value>
        /// The create by.
        /// </value>
        public Peaple CreateBy { get; }
        /// <summary>
        /// Gets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        public Peaple ModifiedBy { get; }
        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public Company Company { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleActivityRegisteredEvent"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="createdBy">The created by.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="company">The company.</param>
        public SingleActivityRegisteredEvent(ActivityId id, string message, Peaple createdBy, Peaple modifiedBy, Company company)
            :base(id)
        {
            this.Message = message;
            this.CreateBy = createdBy;
            this.ModifiedBy = modifiedBy;
            this.Company = company;
        }
    }
}
