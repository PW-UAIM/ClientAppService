using majumi.CarService.ClientsAppService.Model;

namespace majumi.CarService.ClientsAppService.Rest.Model.Model;

public class ClientLoginStatus
{
    public bool IsSuccesfull { get; set; }
    public ClientData? Client { get; set; }

    public ClientLoginStatus() { }
    public ClientLoginStatus(bool isSuccesfull, ClientData? clientData)
    {
        IsSuccesfull = isSuccesfull;
        Client = clientData;
    }
}