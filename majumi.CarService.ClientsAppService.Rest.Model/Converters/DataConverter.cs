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
            Color = car.Color,
            Mileage = car.Mileage,
            Transmission = car.Transmission,
            FuelType = car.FuelType,
            EngineSize = car.EngineSize,
            Horsepower = car.Horsepower,
            Torque = car.Torque,
            Drivetrain = car.Drivetrain,
            SeatingCapacity = car.SeatingCapacity,
            VehicleType = car.VehicleType,
            Price = car.Price,
            Location = car.Location
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
            ServiceTime = visit.ServiceTime,
            ServiceLocation = visit.ServiceLocation,
            ServiceCost  = visit.ServiceCost,
            ServiceStatus = visit.ServiceStatus,
            Notes = visit.Notes,
            Rating = visit.Rating,
            MechanicID = visit.MechanicID,
            CarID = visit.CarID
        };
    }
}