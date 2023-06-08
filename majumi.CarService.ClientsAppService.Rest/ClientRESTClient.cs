using majumi.CarService.ClientsAppService.Model;
using majumi.CarService.ClientsAppService.Rest.Model.Converters;
using majumi.CarService.ClientsAppService.Rest.Model.Model;
using System.Text;
using System.Text.Json;

namespace majumi.CarService.ClientsAppService.Rest;

public class ClientRESTClient
{
    private string ClientDataServiceURL = "http://localhost:5001/";
    private string CarDataServiceURL = "http://localhost:5000/";
    private string VisitDataServiceURL = "http://localhost:5003/";

    private readonly JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
    };

    public ClientRESTClient() { 
        if(!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("CARSDATASERVICE_SERVICE_HOST"))) 
        {
            CarDataServiceURL = $"http://{Environment.GetEnvironmentVariable("CARSDATASERVICE_SERVICE_HOST")}:{int.Parse(Environment.GetEnvironmentVariable("CARSDATASERVICE_SERVICE_PORT"))}/";
            ClientDataServiceURL = $"http://{Environment.GetEnvironmentVariable("CLIENTSDATASERVICE_SERVICE_HOST")}:{int.Parse(Environment.GetEnvironmentVariable("CLIENTSDATASERVICE_SERVICE_PORT"))}/";
            VisitDataServiceURL = $"http://{Environment.GetEnvironmentVariable("VISITSDATASERVICE_SERVICE_HOST")}:{int.Parse(Environment.GetEnvironmentVariable("VISITSDATASERVICE_SERVICE_PORT"))}/";
        }   
        else if (System.Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
        {
            CarDataServiceURL = "http://carsdataservice:5000/";
            ClientDataServiceURL = "http://clientsdataservice:5001/";
            VisitDataServiceURL = "http://visitsdataservice:5003/";
        }
    }

    public async Task<bool> AddCar(CarData data)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var json = JsonSerializer.Serialize(data);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync("addCar", body);
            if (result.StatusCode.Equals(System.Net.HttpStatusCode.Created))
                return true;
        }
        return false;
    }

    public async Task<bool> AddVisit(VisitData data)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(VisitDataServiceURL);
            data.MechanicID = -1;
            data.ServiceCost = -1;
            data.ServiceStatus = "PENDING";
            var json = JsonSerializer.Serialize(data);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync("addVisit", body);
            if (result.StatusCode.Equals(System.Net.HttpStatusCode.Created))
                return true;
        }
        return false;
    }

    public async Task<ClientLoginStatus> ClientLogIn(int id)
    {
        Client? client;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(ClientDataServiceURL);
            var result = await httpClient.GetAsync($"getClient/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();
            if(!result.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                return new ClientLoginStatus(false, null);
            try
            {
                client = JsonSerializer.Deserialize<Client>(resultContent, options);
                ClientData clientData = DataConverter.ConvertToClientData(client);
                return new ClientLoginStatus(true, clientData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ClientLoginStatus(false, null);
            }
        }
    }

    public async Task<List<Car>> GetClientCars(int id)
    {
        var carResult = new List<Car>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var result = await httpClient.GetAsync($"getAllCarsByClient/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                List<CarData> carData = JsonSerializer.Deserialize<CarData[]>(resultContent, options).ToList();
                foreach (CarData car in carData)
                {
                    carResult.Add(DataConverter.ConvertToCar(car));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        return carResult;
    }

    public async Task<List<Visit>> GetClientVisits(int id)
    {
        var visitResult = new List<Visit>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(VisitDataServiceURL);
            var result = await httpClient.GetAsync($"getAllVisitsByClient/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                List<VisitData> visitData = JsonSerializer.Deserialize<VisitData[]>(resultContent, options).ToList();
                foreach (VisitData visit in visitData)
                {
                    visitResult.Add(DataConverter.ConvertToVisit(visit));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        return visitResult;
    }

    public async Task<Car?> GetCar(int id)
    {
        Car carResult;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var result = await httpClient.GetAsync($"getCar/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);
            try
            {
                CarData car = JsonSerializer.Deserialize<CarData>(resultContent, options);
                carResult = DataConverter.ConvertToCar(car);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        return carResult;
    }

    public async Task<Visit?> GetVisit(int id)
    {
        Visit visitResult;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(VisitDataServiceURL);
            var result = await httpClient.GetAsync($"getVisit/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                VisitData visit = JsonSerializer.Deserialize<VisitData>(resultContent, options);
                visitResult = DataConverter.ConvertToVisit(visit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        return visitResult;
    }
}
