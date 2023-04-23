using Microsoft.AspNetCore.Mvc;
using majumi.CarService.ClientsAppService.Model;
using majumi.CarService.ClientsAppService.Rest.Model.Model;
using majumi.CarService.ClientsAppService.Rest.Model.Converters;

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
    [Route("/login/{id:int}")]
    public async Task<ActionResult<ClientLoginStatus>> ClientLogIn(int id)
    {
        ClientLoginStatus clientLoginStatus = await restClient.ClientLogIn(id);
        if (clientLoginStatus.IsSuccesfull == false)
            return Unauthorized();

        return Ok(clientLoginStatus);
    }

    [HttpPost]
    [Route("/addCar")]
    public async Task<ActionResult<bool>> AddCar(CarData data)
    {
        if (await restClient.AddCar(data) == true)
            return Created($"/car/{data.CarID}", true);

        return BadRequest();
    }

    [HttpPost]
    [Route("/addVisit")]
    public async Task<ActionResult<bool>> AddVisit(VisitData data)
    {
        if (await restClient.AddVisit(data) == true)
            return Created($"/visit/{data.VisitID}", true);

        return BadRequest();
    }

    [HttpGet]
    [Route("/getAllCarsByClient/{id:int}")]
    public async Task<List<CarData>> GetClientCars(int id)
    {
        List<Car> cars = await restClient.GetClientCars(id);
        List<CarData> carData = new();
        foreach(Car car in cars)
        {
            carData.Add(DataConverter.ConvertToCarData(car));
        }
        return carData;
    }

    [HttpGet]
    [Route("/getAllVisitsByClient/{id:int}")]
    public async Task<List<VisitData>> GetClientVisits(int id)
    {
        List<Visit> visits = await restClient.GetClientVisits(id);
        List<VisitData> visitData = new();
        foreach (Visit visit in visits)
        {
            visitData.Add(DataConverter.ConvertToVisitData(visit));
        }
        return visitData;
    }

    [HttpGet]
    [Route("/getCar/{id:int}")]
    public async Task<CarData> GetCar(int id)
    {
        Car car = await restClient.GetCar(id);
        CarData carData = DataConverter.ConvertToCarData(car);

        return carData;
    }

    [HttpGet]
    [Route("/getVisit/{id:int}")]
    public async Task<VisitData> GetVisit(int id)
    {
        Visit visit = await restClient.GetVisit(id);
        VisitData visitData = DataConverter.ConvertToVisitData(visit);

        return visitData;
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests()
    {
        throw new NotImplementedException();
    }
};