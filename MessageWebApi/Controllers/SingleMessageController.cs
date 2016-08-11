using MessageService.Domain;
using MessageService.Domain.Commands;
using MessageService.Domain.Model;
using MessageService.Domain.Repositories;
using MessageWebApi.ViewModel;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageWebApi.Controllers
{
    [Route("api/message/[controller]")]
    public class SingleMessageController : Controller
    {
        private readonly IBus _bus;
        private readonly IActivityRepository _repository;

        public SingleMessageController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet("{id}")]
        public Activity Get(string id)
        {
            return _repository.Load(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SingleActivityViewModel singleActivity)
        {
            await _bus.SendCommandAsync(new RegisterSingleActivityCommand(
                    singleActivity.ActivityId,
                    singleActivity.Message,
                    new Peaple(singleActivity.SenderId, singleActivity.SenderName, singleActivity.SenderEmail),
                    new Peaple(singleActivity.ReceiverId, singleActivity.ReceiverName, singleActivity.ReceiverEmail),
                    new Company(singleActivity.CompanyId, singleActivity.CompanyName)
                ));

            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] SingleActivityViewModel singleActivity)
        {
            if (string.IsNullOrWhiteSpace(id))
                return HttpNotFound();

            singleActivity.ActivityId = id;

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return HttpNotFound();

            return Ok();
        }
    }
}
