using MessageService.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain
{
    /// <summary>
    /// Bus interface
    /// </summary>
    public interface IBus
    {
        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theCommand">The command.</param>
        void SendCommand<T>(T theCommand) where T : Command;
        /// <summary>
        /// Sends the command asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theCommand">The command.</param>
        /// <returns></returns>
        Task SendCommandAsync<T>(T theCommand) where T : Command;
        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent">The event.</param>
        void RaiseEvent<T>(T theEvent) where T : Event;
        /// <summary>
        /// Raises the event asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent">The event.</param>
        /// <returns></returns>
        Task RaiseEventAsync<T>(T theEvent) where T : Event;
        /// <summary>
        /// Registers the handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RegisterHandler<T>();
    }
}
