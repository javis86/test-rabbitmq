using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using publisher.api.Infrastructure.Messaging;

namespace publisher.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EvolucionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EvolucionController> _logger;
        private readonly INuevaEvolucionSender _evolucionSender;

        public EvolucionController(ILogger<EvolucionController> logger, INuevaEvolucionSender evolucionSender)
        {
            _logger = logger;
            _evolucionSender = evolucionSender;
        }

        [HttpPost]
        public EvolucionMessage SendNew()
        {
            var rng = new Random();

            var mensaje = new EvolucionMessage()
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };

            _evolucionSender.SendCustomer(mensaje);

            return mensaje;
        }
    }
}
