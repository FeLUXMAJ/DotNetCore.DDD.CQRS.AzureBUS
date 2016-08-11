using MessageService.Domain;
using MessageService.Domain.CommandHandlers;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageWebApi.Midleware
{
    /// <summary>
    /// Midleware utilizado para registros dos Commands Handler.
    /// </summary>
    public class RegisterHandlerMidleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterHandlerMidleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public RegisterHandlerMidleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="bus">The bus.</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, IBus bus)
        {
            // Registra os handlers
            bus.RegisterHandler<RegisterSingleActivityHandler>();
            bus.RegisterHandler<UpdateActionUrlActivityHandler>();

            await _next(context);
        }
    }
}
