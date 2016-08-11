using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain.Model
{
    [Serializable]
    public class Company
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public Company(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }
    }
}
