using majumi.CarService.ClientsAppService.Model;
using System.Text.Json;

namespace majumi.CarService.ClientsAppService.Rest;

public class ClientRESTClient
{
    private const string ClientDataServiceURL = "http://localhost:5001/";
    private const string CarDataServiceURL = null;
    private const string VisitDataServiceURL = null;

    public ClientRESTClient()
    {
        if (ClientDataServiceURL == null || CarDataServiceURL == null || VisitDataServiceURL == null)
            throw new NotImplementedException();
        // Leave empty constructor after implementation
    }

    public async Task<Client> ClientLogIn(int id)
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
    public async Task<Car> GetCar(int id)
    {
        throw new NotImplementedException();
    }
    public async Task<Visit> GetVisit(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Visit[]> GetVisitsAt(int month, int day)
    {
        throw new NotImplementedException();
    }
}




