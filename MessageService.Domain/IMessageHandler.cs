using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain
{
    public interface IMessageHandler<in T>
        where T : Message
    {
        void Handle(T message);
    }
}
