namespace majumi.CarService.ClientsAppService.Model;

public class Client
{
    public int? ClientID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? InsuranceCompany { get; set; }
    public string? PolicyNumber { get; set; }


    public Client() { }

    public Client(int clientID, string firstName, string lastName, string address, string phoneNumber, string email,
    string insuranceCompany, string policyNumber)
    {
        ClientID = clientID;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
        InsuranceCompany = insuranceCompany;
        PolicyNumber = policyNumber;
    }
}