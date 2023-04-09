namespace majumi.CarService.ClientsAppService.Model;

public class Car
{
    public int? CarID { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public DateTime? Year { get; set; }
    public string? Color { get; set; }
    public int? Mileage { get; set; }
    public string? Transmission { get; set; }
    public string? FuelType { get; set; }
    public float? EngineSize { get; set; }
    public int? Horsepower { get; set; }
    public int? Torque { get; set; }
    public string? Drivetrain { get; set; }
    public int? SeatingCapacity { get; set; }
    public string? VehicleType { get; set; }
    public int? Price { get; set; }
    public string? Location { get; set; }


    public Car() { }
    public Car(int carID, string make, string model, DateTime year, string color, int mileage, string transmission,
    string fuelType, float engineSize, int horsepower, int torque, string drivetrain, int seatingCapacity, string vehicleType,
    int price, string location)
    {
        CarID = carID;
        Make = make;
        Model = model;
        Year = year;
        Color = color;
        Mileage = mileage;
        Transmission = transmission;
        FuelType = fuelType;
        EngineSize = engineSize;
        Horsepower = horsepower;
        Torque = torque;
        Drivetrain = drivetrain;
        SeatingCapacity = seatingCapacity;
        VehicleType = vehicleType;
        Price = price;
        Location = location;
    }
}