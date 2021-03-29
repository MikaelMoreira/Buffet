using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buffet.Controllers
{
    [Route(template:"/interno")]
    public class InternoController : Controller
    {
        private readonly ILogger<InternoController> _logger;

        public InternoController(ILogger<InternoController> logger)
        {
            _logger = logger;
        }
        
        [Route(template:"/index")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route(template:"/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        
        [Route(template:"/ajuda")]
        public IActionResult Ajuda()
        {
            return View();
        }
        
        [Route(template:"/secao")]
        public IActionResult Secao()
        {
            return View();
        }
        
        [Route(template:"/terno")]
        public IActionResult Termo()
        {
            return View();
        }
        
        [Route(template:"/painel")]
        public IActionResult Painel()
        {
            return View();
        }
        
        
    }
}