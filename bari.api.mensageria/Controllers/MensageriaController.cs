using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;
using Bari.Producer;
using Microsoft.Extensions.Configuration;
using Bari.Model;
using Bari.Consumer;

namespace bari.api.mensageria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensageriaController : ControllerBase
    {
        private ILogger<MensageriaController> _logger;
        private readonly IConfiguration _config;
        //private Serilog.ILogger _logger;

        public MensageriaController(ILogger<MensageriaController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpPost]
        [Route("send")]
        public IActionResult SendMessage(Message mensagem)
        {
            try
            {
                
                Producer producer = new Producer(_config.GetValue<string>("AppSettings:Queue"), _config.GetValue<string>("AppSettings:Host"));
                producer.Publish(mensagem);
                return Accepted(mensagem);
            }
            catch (Exception ex)
            {

                _logger.LogError("Erro ao tentar executar o envio " + ex);
                return new StatusCodeResult(500);
            }

        }

        [HttpGet]
        [Route("receive")]
        public IActionResult ReceiveMessage()
        {
            try
            {
                Consumer consumer = new Consumer(_config.GetValue<string>("AppSettings:Queue"), _config.GetValue<string>("AppSettings:Host"));
                consumer.Consume();
                return Accepted(consumer.listConsume);
            }
            catch (Exception ex)
            {

                _logger.LogError("Erro ao tentar executar o envio " + ex);
                return new StatusCodeResult(500);
            }

        }

    }
}
