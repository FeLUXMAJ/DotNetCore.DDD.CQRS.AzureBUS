using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MessageService.Domain;
using MessageService.Domain.Commands;
using MessageService.Domain.Model;

namespace MessageWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IBus _bus;

        public ValuesController(IBus bus)
        {
            _bus = bus;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _bus.SendCommandAsync(
                    new RegisterSingleActivityCommand(
                        "1234",
                        "Teste",
                        new Peaple("234", "Nome de teste", "andre@casertano.com.br"),
                        new Peaple("234", "Nome de teste", "andre@casertano.com.br"),
                        new Company("432", "CrunchFlow")
                        )
                );

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
