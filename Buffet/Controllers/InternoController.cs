using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buffet.Controllers
{
    
    public class InternoController : Controller
    {
        private readonly ILogger<InternoController> _logger;

        public InternoController(ILogger<InternoController> logger)
        {
            _logger = logger;
        }
        
        
        [Authorize]
        
        public IActionResult Index()
        {
            return View();
        }
        
        
        public IActionResult Privacy()
        {
            return View();
        }
        
        
        public IActionResult Ajuda()
        {
            return View();
        }
        
        
        public IActionResult Secao()
        {
            return View();
        }
        
       
        public IActionResult Termo()
        {
            return View();
        }
        
        
        public IActionResult Painel()
        {
            return View();
        }
        
        
    }
}