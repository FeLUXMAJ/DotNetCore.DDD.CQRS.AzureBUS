using MessageService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.DependencyInjection;

namespace MessageService.Infra.Bus
{
    /// <summary>
    /// Implement single memory BUS
    /// </summary>
    /// <seealso cref="MessageService.Domain.IBus" />
    public class Bus : IBus
    {
        private readonly IDictionary<Type, object> _handlers = new Dictionary<Type, object>();
        private readonly IServiceProvider _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bus"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public Bus(IServiceProvider service)
        {
            _service = service;
        }

        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theCommand">The command.</param>
        public void SendCommand<T>(T theCommand) where T : Command
        {
            Send<T>(theCommand);
        }

        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent">The event.</param>
        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Send<T>(theEvent);
        }

        /// <summary>
        /// Sends the command asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theCommand">The command.</param>
        /// <returns></returns>
        public async Task SendCommandAsync<T>(T theCommand) where T : Command
        {
            Send<T>(theCommand);
        }

        /// <summary>
        /// Raises the event asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent">The event.</param>
        /// <returns></returns>
        public async Task RaiseEventAsync<T>(T theEvent) where T : Event
        {
            Send<T>(theEvent);
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">The message.</param>
        private void Send<T>(T message) where T : Message
        {
            var constructedType = typeof(IMessageHandler<>)
                .MakeGenericType(typeof(T));

            var handlersToNotify = _handlers
                                    .Keys
                                    .Where(h => constructedType.IsAssignableFrom(h));

            foreach (var handler in handlersToNotify)
            {
                var instance = _service.GetService(handler);
                var method = constructedType.GetMethod("Handle", new[] { typeof(T) });
                method.Invoke(instance, new object[] { message });
            }
        }

        /// <summary>
        /// Registers the handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RegisterHandler<T>()
        {
            _handlers.Add(typeof(T), null);
        }
    }
}
