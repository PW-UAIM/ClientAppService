using majumi.CarService.ClientsAppService.Model;
using majumi.CarService.ClientsAppService.Rest.Model.Model;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace majumi.CarService.ClientsAppService.Rest;

public class ClientRESTClient
{
    private const string ClientDataServiceURL = "http://localhost:5001/";
    private const string CarDataServiceURL = "http://localhost:5000/";
    private const string VisitDataServiceURL = "http://localhost:5003/";

    public ClientRESTClient()
    {
        if (ClientDataServiceURL == null || CarDataServiceURL == null || VisitDataServiceURL == null)
            throw new NotImplementedException();
        // Leave empty constructor after implementation
    }

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

            try
            {
                client = JsonSerializer.Deserialize<Client>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ClientLoginStatus(false, null);
            }
        }

        return new ClientLoginStatus(true, client);
    }

    public async Task<Car[]> GetClientCars(int id)
    {
        Car[] car;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var result = await httpClient.GetAsync($"car/all/client/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                car = JsonSerializer.Deserialize<Car[]>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        return car;
    }

    public async Task<Visit[]> GetClientVisits(int id)
    {
        Visit[] visit;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(VisitDataServiceURL);
            var result = await httpClient.GetAsync($"visit/all/client/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                visit = JsonSerializer.Deserialize<Visit[]>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        return visit;
    }

    public async Task<Car> GetCar(int id)
    {
        Car car;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(CarDataServiceURL);
            var result = await httpClient.GetAsync($"car/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                car = JsonSerializer.Deserialize<Car>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Car();
            }
        }
        return car;
    }

    public async Task<Visit> GetVisit(int id)
    {
        Visit visit;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(VisitDataServiceURL);
            var result = await httpClient.GetAsync($"visit/{id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                visit = JsonSerializer.Deserialize<Visit>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Visit();
            }
        }
        return visit;
    }

    /*public async Task<Client> ClientLogIn(int id)
    {
        Client client;

        using (var httpclient = new HttpClient())
        {
            httpclient.BaseAddress = new Uri(ClientDataServiceURL);

            var result = await httpclient.GetAsync($"client/{id}");

            string resultContent = await result.Content.ReadAsStringAsync();

            try
            {
                client = JsonSerializer.Deserialize<Client>(resultContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        return client;
    }


    public async Task<Visit[]> GetVisitsAt(int month, int day)
    {
        throw new NotImplementedException();
    }
    */
}




