using majumi.CarService.ClientAppService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace majumi.CarService.ClientAppService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/")]
        [Route("/index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/getVisits")]
        public IActionResult GetVisits()
        {
            // Deserialize JSON Object
            
            string tempJSON = "{ \"stations\":[{\"name\":\"aname\",\"free\":false},{\"name\":\"anothername\",\"free\":true}]}";

            // Pass it to CSHTML
            return View(viewName: null, (string) Request.Query["id"]);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}