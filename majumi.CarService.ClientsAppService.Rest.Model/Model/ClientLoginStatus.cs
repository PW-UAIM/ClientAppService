namespace majumi.CarService.ClientsAppService.Rest.Model.Model;

public class ClientLoginStatus
{
    public bool IsLoggedIn { get; set; }
    public int? ClientID { get; set; }

    public ClientLoginStatus(bool isLoggedIn, int? clientID)
    {
        IsLoggedIn = isLoggedIn;
        ClientID = clientID;
    }

    public ClientLoginStatus()
    {
    }
}