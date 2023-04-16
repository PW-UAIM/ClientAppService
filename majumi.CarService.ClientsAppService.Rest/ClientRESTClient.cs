using majumi.CarService.ClientsAppService.Model;
using majumi.CarService.ClientsAppService.Rest.Model.Converters;
using majumi.CarService.ClientsAppService.Rest.Model.Model;
using System.Text;
using System.Text.Json;

namespace majumi.CarService.ClientsAppService.Rest;

public class ClientRESTClient
{
    private const string ClientDataServiceURL = "https://localhost:5001/";
    private const string CarDataServiceURL = "https://localhost:5000/";
    private const string VisitDataServiceURL = "https://localhost:5003/";
    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        
    };

    public ClientRESTClient() { }

    public async Task<bool> AddCar(CarData data)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var json = JsonSerializer.Serialize(data);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync("car/add", body);
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
            var json = JsonSerializer.Serialize(data);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync("visit/add", body);
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
            var result = await httpClient.GetAsync($"client/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();
            if(!result.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                return new ClientLoginStatus(false, null);
            try
            {
                client = JsonSerializer.Deserialize<Client>(resultContent, options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ClientLoginStatus(false, null);
            }
        }
        ClientData clientData = DataConverter.ConvertToClientData(client);
        return new ClientLoginStatus(true, clientData);
    }

    public async Task<List<Car>> GetClientCars(int id)
    {
        var car = new List<Car>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var result = await httpClient.GetAsync($"car/all/client/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                List<CarData> carData = JsonSerializer.Deserialize<CarData[]>(resultContent, options).ToList();
                foreach (CarData c in carData)
                {
                    car.Add(DataConverter.ConvertToCar(c));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        return car;
    }

    public async Task<List<Visit>> GetClientVisits(int id)
    {
        var visit = new List<Visit>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(VisitDataServiceURL);
            var result = await httpClient.GetAsync($"visit/client/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                List<VisitData> visitData = JsonSerializer.Deserialize<VisitData[]>(resultContent, options).ToList();
                foreach (VisitData v in visitData)
                {
                    visit.Add(DataConverter.ConvertToVisit(v));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        return visit;
    }

    public async Task<Car?> GetCar(int id)
    {
        Car car;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var result = await httpClient.GetAsync($"car/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);
            try
            {
                CarData c = JsonSerializer.Deserialize<CarData>(resultContent, options);
                car = DataConverter.ConvertToCar(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        return car;
    }

    public async Task<Visit?> GetVisit(int id)
    {
        Visit visit;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(VisitDataServiceURL);
            var result = await httpClient.GetAsync($"visit/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                VisitData v = JsonSerializer.Deserialize<VisitData>(resultContent, options);
                visit = DataConverter.ConvertToVisit(v);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        return visit;
    }
}
