using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch02.LifecycleDI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ch02.LifecycleDI.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class HomeController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<HomeController> _logger;
        private readonly GuidService _guidService;

        public HomeController(
            ILogger<HomeController> logger
            , GuidService guidService)  // AddTransient : GuidService 생성자 호출
        {
            _logger = logger;
            _guidService = guidService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var guid = _guidService.GetGuid();

            var logMessage = $"Controller: The GUID from GuidService is {guid}";

            _logger.LogInformation(logMessage);

            var messages = new List<string>
            {
                HttpContext.Items["MiddlewareGuid"].ToString(),
                logMessage
            };

            return Ok(messages);
        }
    }
}
