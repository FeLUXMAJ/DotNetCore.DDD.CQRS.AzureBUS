using MessageService.Domain.Commands;
using MessageService.Domain.Events;
using MessageService.Domain.Model;
using MessageService.Domain.Repositories;
using System;

namespace MessageService.Domain.CommandHandlers
{
    public class UpdateActionUrlActivityHandler : IMessageHandler<UpdateActionUrlActivityCommand>
    {
        private readonly IBus _bus;
        private readonly IActivityRepository _repository;

        public UpdateActionUrlActivityHandler(IBus bus, IActivityRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public void Handle(UpdateActionUrlActivityCommand message)
        {
            try
            {
                Activity activity = _repository.Load(message.Id);
                activity.AddUrl(message.ActionUrl);

                _repository.UpdateActionUrl(activity);

                _bus.RaiseEvent(
                    new ActionUrlActivityUpdatedEvent(message.Id, message.ActionUrl)
                    );
            }
            // TODO: Definir o Exception do Domínio.
            catch (Exception e)
            {
                // TODO: Definir o evento de excessão.
            }

        }
    }
}
