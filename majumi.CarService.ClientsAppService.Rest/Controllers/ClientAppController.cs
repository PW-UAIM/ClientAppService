using Microsoft.AspNetCore.Mvc;
using majumi.CarService.ClientsAppService.Model;
using majumi.CarService.ClientsAppService.Rest;
using majumi.CarService.ClientsAppService.Rest.Model.Model;

namespace majumi.CarService.ClientsAppService.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientAppController : ControllerBase
{
    private readonly ILogger<ClientAppController> _logger;

    private ClientRESTClient restClient;
    public ClientAppController(ILogger<ClientAppController> logger)
    {
        _logger = logger;
        restClient = new ClientRESTClient();
    }

    [HttpGet]
    [Route("/client/{id:int}/login")]
    public ClientLoginStatus ClientLogIn(int id)
    {
        return restClient.ClientLogIn(id).Result;
    }

    [HttpPost]
    [Route("/car/add")]
    public ActionResult AddCar(CarData data)
    {
        if (restClient.AddCar(data).Result)
            return Created("/car/add", data);
        return BadRequest();
    }

    [HttpPost]
    [Route("/visit/add")]
    public ActionResult AddVisit(VisitData data)
    {
        if (restClient.AddVisit(data).Result)
            return Created("/visit/add", data);
        return BadRequest();
    }

    [HttpGet]
    [Route("/car/all/{id:int}")]
    public Car[] GetClientCars(int id)
    {
        return restClient.GetClientCars(id).Result;
    }

    [HttpGet]
    [Route("/visit/all/{id:int}")]
    public Visit[] GetClientVisits(int id)
    {
        return restClient.GetClientVisits(id).Result;
    }

    [HttpGet]
    [Route("/car/{id:int}")]
    public Car GetCar(int id)
    {
        return restClient.GetCar(id).Result;
    }

    [HttpGet]
    [Route("/visit/{id:int}")]
    public Visit GetVisit(int id)
    {
        return restClient.GetVisit(id).Result;
    }

    /*
    [HttpGet]
    [Route("/clientLogIn/{id:int}")]
    public ClientLoginStatus ClientLogIn(int id)
    {
        var client = restClient.ClientLogIn(id);
        return new ClientLoginStatus(client != null, client.Result.ClientID);
    }

    [HttpGet]
    [Route("/getCar/{id:int}")]
    public Car GetCar(int id)
    {
        return restClient.GetCar(id).Result;
    }

    [HttpGet]
    [Route("/getVisit/{id:int}")]
    public Visit GetVisit(int id)
    {
        return restClient.GetVisit(id).Result;
    }

    [HttpGet]
    [Route("/getVisitsAt/{month:int}/{day:int}")]
    public Visit[] GetVisitsAt(int month, int day)
    {
        return restClient.GetVisitsAt(month, day).Result;
    }
    */

    [HttpGet]
    [Route("/runTests")]
    public string RunTests()
    {
        throw new NotImplementedException();
    }
};