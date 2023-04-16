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
    [Route("/client/{id:int}/login")]
    public ActionResult<ClientLoginStatus> ClientLogIn(int id)
    {
        ClientLoginStatus clientLoginStatus = restClient.ClientLogIn(id).Result;
        if (clientLoginStatus.IsSuccesfull == false)
            return Unauthorized();

        return Ok(clientLoginStatus);
    }

    [HttpPost]
    [Route("/car/add")]
    public ActionResult<CarData> AddCar(CarData data)
    {
        if (restClient.AddCar(data).Result)
            return Created($"/car/{data.CarID}", data);

        return BadRequest();
    }

    [HttpPost]
    [Route("/visit/add")]
    public ActionResult<VisitData> AddVisit(VisitData data)
    {
        if (restClient.AddVisit(data).Result)
            return Created($"/visit/{data.VisitID}", data);

        return BadRequest();
    }

    [HttpGet]
    [Route("/car/all/{id:int}")]
    public List<CarData> GetClientCars(int id)
    {
        List<Car> cars = restClient.GetClientCars(id).Result;
        List<CarData> carData = new();
        foreach(Car c in cars)
        {
            carData.Add(DataConverter.ConvertToCarData(c));
        }
        return carData;
    }

    [HttpGet]
    [Route("/visit/all/{id:int}")]
    public List<VisitData> GetClientVisits(int id)
    {
        List<Visit> visits = restClient.GetClientVisits(id).Result;
        List<VisitData> visitData = new();
        foreach (Visit v in visits)
        {
            visitData.Add(DataConverter.ConvertToVisitData(v));
        }
        return visitData;
    }

    [HttpGet]
    [Route("/car/{id:int}")]
    public CarData GetCar(int id)
    {
        Car car = restClient.GetCar(id).Result;
        CarData carData = DataConverter.ConvertToCarData(car);

        return carData;
    }

    [HttpGet]
    [Route("/visit/{id:int}")]
    public VisitData GetVisit(int id)
    {
        Visit visit = restClient.GetVisit(id).Result;
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