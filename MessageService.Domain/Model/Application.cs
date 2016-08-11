using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain.Model
{
    public class Application
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Application(string id, string Name)
        {
            this.Id = id;
            this.Name = Name;
        }
    }
}
