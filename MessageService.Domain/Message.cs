using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain
{
    [Serializable]
    public abstract class Message
    {
        public string MessageType { get; private set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
