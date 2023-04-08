using Microsoft.AspNetCore.Mvc;
using majumi.CarService.ClientsAppService.Model;
using majumi.CarService.ClientsAppService.Rest;
using majumi.CarService.ClientsAppService.Rest.Model.Model;

namespace majumi.CarService.ClientsAppService.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class MechanicAppController : ControllerBase
{
    private readonly ILogger<MechanicAppController> _logger;

    private MechanicRESTClient client;
    public MechanicAppController(ILogger<MechanicAppController> logger)
    {
        _logger = logger;
        client = new MechanicRESTClient();
    }

    [HttpGet]
    [Route("/mechanicLogIn/{id:int}")]
    public MechanicLoginStatus MechanicLogIn(int id)
    {
        var mechanic = client.MechanicLogIn(id);
        return new MechanicLoginStatus(mechanic != null, mechanic.Result.MechanicID);
    }

    [HttpGet]
    [Route("/getCar/{id:int}")]
    public Car GetCar(int id)
    {
        return client.GetCar(id).Result;
    }

    [HttpGet]
    [Route("/getVisit/{id:int}")]
    public Visit GetVisit(int id)
    {
        return client.GetVisit(id).Result;
    }

    [HttpGet]
    [Route("/getVisitsAt/{month:int}/{day:int}")]
    public Visit[] GetVisitsAt(int month, int day)
    {
        return client.GetVisitsAt(month, day).Result;
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests()
    {
        throw new NotImplementedException();
    }
};