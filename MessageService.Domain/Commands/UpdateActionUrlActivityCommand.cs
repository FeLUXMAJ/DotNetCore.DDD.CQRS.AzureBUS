using MessageService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain.Commands
{
    public class UpdateActionUrlActivityCommand : ActivityCommand
    {
        public WebSite ActionUrl { get; }

        public UpdateActionUrlActivityCommand(ActivityId id, WebSite actionUrl)
            :base(id)
        {
            this.ActionUrl = actionUrl;
        }
    }
}
