using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain.Model
{
    /// <summary>
    /// Peaple object model
    /// </summary>
    [Serializable]
    public class Peaple
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public PeapleId Id { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public Email Email { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Peaple"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        public Peaple(PeapleId id, string name, Email email)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }
    }
}
