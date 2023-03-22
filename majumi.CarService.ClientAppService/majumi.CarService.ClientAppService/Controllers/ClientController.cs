using majumi.CarService.ClientAppService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace majumi.CarService.ClientAppService.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/Login")]
        public IActionResult Login()
        {
            return View(viewName: null);
        }

        [HttpGet]
        [Route("/GetVisits")]
        public IActionResult GetVisits()
        {
            string json = System.IO.File.ReadAllText("mechanics.json");
            return View(viewName: null, json);
        }

        [HttpGet]
        [Route("/GetAvailableDates")]
        public IActionResult GetAvailableDates()
        {
            return View(viewName: null, (string?)Request.Query["date"]);
        }

        [HttpGet]
        [Route("/MakeAnAppointment")]
        public IActionResult MakeAnAppointment()
        {
            return View(viewName: null, (string?)Request.Query["date"]);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}