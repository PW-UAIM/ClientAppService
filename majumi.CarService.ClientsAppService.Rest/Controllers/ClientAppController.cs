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

    [HttpGet]
    [Route("/runTests")]
    public string RunTests()
    {
        throw new NotImplementedException();
    }
};