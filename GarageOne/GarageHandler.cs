namespace GarageOne;

public class GarageHandler : IHandler
{
    private const int DefaultCapacity = 10;
    private Garage<Vehicle> garage = new Garage<Vehicle>(DefaultCapacity);

    public void NewGarage(int numberOfSpaces)
    {
        garage = new Garage<Vehicle>(numberOfSpaces);
    }

    internal void Initialize()
    {
        garage.AddVehicle(new Airplane("MGZ777", "white", 12, 4));
        garage.AddVehicle(new Boat("JSD62", "Orange", 2, 2));
        garage.AddVehicle(new Bus("ASWAA-A025", "Red", 6, 60));
        garage.AddVehicle(new Car("WWQD89", "Pink", 5, true));
        garage.AddVehicle(new Motorcycle("282DS", "Silver", 2, 800));
        garage.AddVehicle(new Motorcycle("2321QW", "Gold", 2, 1200));
    }

    internal void ListVehicles()
    {
        foreach (Vehicle vehicle in garage)
        {
            Console.WriteLine(vehicle);
        }
    }

    internal void ListVehicleTypes()
    {
        var vehicleTypes = garage.GroupBy(v => v.GetType()).Select(t => new { Type = t.Key, Count = t.Count() });
        foreach (var vehicleType in vehicleTypes)
        {
            Console.WriteLine(vehicleType);
        }
    }

    public void AddVehicle(Vehicle newVehicle)
    {
        garage.AddVehicle(newVehicle);
    }

    public void RemoveVehicle(string regNr)
    {
        for (var i = 0; i < garage.Vehicles.Length; i++)
        {
            if (garage.Vehicles[i]?.RegistrationNr == regNr.ToUpper())
            {
                garage.Vehicles[i] = null;
            }
        }
    }
}