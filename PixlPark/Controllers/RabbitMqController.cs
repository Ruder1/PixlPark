using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PixlPark.Models;
using PixlPark.RabbitMq;

namespace PixlPark.Controllers
{
    [Route("Home/[controller]")]
    [ApiController]
    public class RabbitMqController : Controller
    {
        private readonly IRabbitMqService _mqService;

        public RabbitMqController(IRabbitMqService mqService)
        {
            _mqService = mqService;
        }

        public IActionResult RabbitMq()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage()
        {
            var mail = new MailViewModel
            {
                Email = Request.Form["email"],
                Message = Request.Form["message"]
            };
            _mqService.SendMessage(mail);

            return Ok("Сообщение отправлено в очередь");
        }

        
    }
}
