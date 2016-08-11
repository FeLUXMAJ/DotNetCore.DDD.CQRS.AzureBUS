using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageWebApi.ViewModel
{
    public class SingleActivityViewModel
    {
        public string ActivityId { get; set; } = Guid.NewGuid().ToString();

        public string Message { get; set; }

        public string SenderId { get; set; }

        public string SenderName { get; set; }

        public string SenderEmail { get; set; }

        public string ReceiverId { get; set; }
                      
        public string ReceiverName { get; set; }
                      
        public string ReceiverEmail { get; set; }

        public string CompanyId { get; set; }

        public string CompanyName { get; set; }
    }
}
