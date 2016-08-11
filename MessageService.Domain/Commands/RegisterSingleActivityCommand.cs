using MessageService.Domain.Model;
using System;

namespace MessageService.Domain.Commands
{
    /// <summary>
    /// Register the single activity
    /// </summary>
    /// <seealso cref="MessageService.Domain.Commands.ActivityCommand" />
    [Serializable]
    public class RegisterSingleActivityCommand : ActivityCommand
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
        /// Gets the assigned to.
        /// </summary>
        /// <value>
        /// The assigned to.
        /// </value>
        public Peaple AssignedTo { get; }
        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public Company Company { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterSingleActivityCommand"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="createdBy">The created by.</param>
        /// <param name="assignedTo">The assigned to.</param>
        /// <param name="company">The company.</param>
        public RegisterSingleActivityCommand(ActivityId id, string message, Peaple createdBy, Peaple assignedTo, Company company)
            :base(id)
        {
            this.Message = message;
            this.CreateBy = createdBy;
            this.AssignedTo = assignedTo;
            this.Company = company;
        }
    }
}
