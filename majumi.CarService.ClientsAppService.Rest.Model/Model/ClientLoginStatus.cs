using majumi.CarService.ClientsAppService.Model;

namespace majumi.CarService.ClientsAppService.Rest.Model.Model;

public class ClientLoginStatus
{
    public bool IsSuccesfull { get; set; }
    public Client? Client { get; set; }

    public ClientLoginStatus() { }
    public ClientLoginStatus(bool isSuccesfull, Client? client)
    {
        IsSuccesfull = isSuccesfull;
        Client = client;
    }
}