using majumi.CarService.ClientsAppService.Model;
using majumi.CarService.ClientsAppService.Rest.Model.Model;

namespace majumi.CarService.ClientsAppService.Rest.Model.Converters;

public static class DataConverter
{
    public static ClientData ConvertToClientData(this Client client)
    {
        return new ClientData
        {
            ClientID = client.ClientID,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Address = client.Address,
            PhoneNumber = client.PhoneNumber,
            Email = client.Email,
            InsuranceCompany = client.InsuranceCompany,
            PolicyNumber = client.PolicyNumber
        };
    }

    public static CarData ConvertToCarData(this Car car)
    {
        return new CarData
        {
            CarID = car.CarID,
            Make = car.Make,
            Model = car.Model,
            Year = car.Year,
            Mileage = car.Mileage,
            EngineSize = car.EngineSize,
            VIN = car.VIN,
            LicensePlate = car.LicensePlate,
            ClientID = car.ClientID
        };
    }

    public static Car ConvertToCar(this CarData car)
    {
        return new Car
        {
            CarID = car.CarID,
            Make = car.Make,
            Model = car.Model,
            Year = car.Year,
            Mileage = car.Mileage,
            EngineSize = car.EngineSize,
            VIN = car.VIN,
            LicensePlate = car.LicensePlate,
            ClientID = car.ClientID
        };
    }

    public static VisitData ConvertToVisitData(this Visit visit)
    {
        return new VisitData
        {
            VisitID = visit.VisitID,
            ClientID = visit.ClientID,
            ServiceType = visit.ServiceType,
            ServiceDate = visit.ServiceDate,
            ServiceCost = visit.ServiceCost,
            ServiceStatus = visit.ServiceStatus,
            Notes = visit.Notes,
            MechanicID = visit.MechanicID,
            CarID = visit.CarID
        };
    }

    public static Visit ConvertToVisit(this VisitData visit)
    {
        return new Visit
        {
            VisitID = visit.VisitID,
            ClientID = visit.ClientID,
            ServiceType = visit.ServiceType,
            ServiceDate = visit.ServiceDate,
            ServiceCost = visit.ServiceCost,
            ServiceStatus = visit.ServiceStatus,
            Notes = visit.Notes,
            MechanicID = visit.MechanicID,
            CarID = visit.CarID
        };
    }
}