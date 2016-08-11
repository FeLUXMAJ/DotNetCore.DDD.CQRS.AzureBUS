using MessageService.Domain.Commands;
using MessageService.Domain.Events;
using MessageService.Domain.Model;
using MessageService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain.CommandHandlers
{
    /// <summary>
    /// Single message handler
    /// </summary>
    /// <seealso cref="MessageService.Domain.IMessageHandler{MessageService.Domain.Commands.RegisterSingleActivityCommand}" />
    public class RegisterSingleActivityHandler : IMessageHandler<RegisterSingleActivityCommand>
    {
        private readonly IBus _bus;
        private readonly IActivityRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterSingleActivityHandler"/> class.
        /// </summary>
        /// <param name="bus">The bus.</param>
        /// <param name="repository">The repository.</param>
        public RegisterSingleActivityHandler(IBus bus, IActivityRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(RegisterSingleActivityCommand message)
        {
            try
            {
                // Cria o objeto de atividade
                var activity = new Activity(message.Id, message.Message, message.CreateBy, message.AssignedTo, message.Company);
                // Envia para o repositório.
                _repository.Create(activity);
                // Dispara um evento de criado.
                _bus.RaiseEvent(
                    new SingleActivityRegisteredEvent(message.Id, message.Message, message.CreateBy, message.AssignedTo, message.Company)
                    );
            }
            // TODO: Definir a excessão de domínio.
            catch (Exception e)
            {
                // TODO: Definir o evento e erro.
            }
            
        }
    }
}
