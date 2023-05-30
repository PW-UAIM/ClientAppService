namespace ZsutPw.Patterns.Application.Model;

using majumi.CarService.ClientsAppService.Rest.Model.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

public class FakeNetworkClient
{
    private static readonly CarData[] cars = new CarData[] { new CarData() { CarID = 1, Make = "Ford", Model = "Focus", Year = 2002, Mileage = 10000, EngineSize = "1.1", VIN = "123123", LicensePlate = "WPL12345", ClientID = 1 } };

    public CarData[] GetCarsByClientID(int clientID)
    {
        return cars.Where(car => car.ClientID == clientID).ToArray();
    }
}
