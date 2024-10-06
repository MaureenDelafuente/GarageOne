using System.Text.Json;

namespace GarageOne;

public class GarageHandler : IHandler
{
    private const int DefaultCapacity = 10;
    private Garage<Vehicle> garage = new Garage<Vehicle>(DefaultCapacity);

    public bool NewGarage(int numberOfSpaces)
    {
        garage = new Garage<Vehicle>(numberOfSpaces);
        return true;
    }

    public void Initialize()
    {
        garage.AddVehicle(new Airplane("MGZ777", "white", 12, 4));
        garage.AddVehicle(new Boat("JSD62", "Orange", 2, 2));
        garage.AddVehicle(new Bus("ASWAA-A025", "Red", 6, 60));
        garage.AddVehicle(new Car("WWQD89", "Pink", 5, true));
        garage.AddVehicle(new Motorcycle("282DS", "Silver", 2, 800));
        garage.AddVehicle(new Motorcycle("2321QW", "Gold", 2, 1200));
    }

    public void ListVehicles()
    {
        foreach (Vehicle vehicle in garage)
        {
            Console.WriteLine(vehicle);
        }
    }

    public void ListVehicleTypes()
    {
        var vehicleTypes = garage.GroupBy(v => v.GetType()).Select(t => new {Type = t.Key, Count = t.Count()});
        foreach (var vehicleType in vehicleTypes)
        {
            Console.WriteLine(vehicleType);
        }
    }

    public bool AddVehicle(Vehicle newVehicle)
    {
        bool success = garage.AddVehicle(newVehicle);
        return success;
    }

    public bool RemoveVehicle(string regNr)
    {
        for (var i = 0; i < garage.Vehicles.Length; i++)
        {
            if (garage.Vehicles[i]?.RegistrationNr == regNr.ToUpper())
            {
                garage.Vehicles[i] = null;
                return true; // found and removed vehicle
            }
        }
        return false; // nothing was removed
    }

    public IEnumerable<Vehicle> Search(string regNr, string color, int nrOfWheels)
    {
        // This is complicated for me, so I try to comment exactly every step to understand it
        return garage.Where(v =>
        {
            string vehicleColor = v.Color.ToUpper(); //Red -> RED
            string colorToSearch = color.ToUpper(); // red -> RED
            string vehicleRegNr = v.RegistrationNr.ToUpper();
            string regNrToSearch = regNr.ToUpper();
            //bool ColorIsMatch = vehicleColor == colorToSearch;  // has to match fully
            //bool RegNrIsMatch = vehicleRegNr == regNrToSearch;  // has to match fully
            //bool nrOfWheelsIsMatch = v.NrOfWheels == nrOfWheels;// has to match exactly
            bool ColorIsMatch = vehicleColor.Contains(colorToSearch); // matches if you search for a part or blank
            bool RegNrIsMatch = vehicleRegNr.Contains(regNrToSearch); // matches if you search for a part or blank
            bool nrOfWheelsIsMatch = (v.NrOfWheels == nrOfWheels) || nrOfWheels == -1; // matches exactly or everything if you search -1

            bool vehicleIsMatch = RegNrIsMatch && ColorIsMatch && nrOfWheelsIsMatch; // combine all search filters
            return vehicleIsMatch; // if it was a match, return true so this vehicle is added to what garage.Where returns
        });
    }

    public bool SaveGarage()
    {
        try
        {
            var garageData = new GarageData() //prepare data to save
            {
                Capacity = garage.Vehicles.Length,
                Vehicles = garage.ToList()
            };

            var options = new JsonSerializerOptions {WriteIndented = true};
            string jsonData = JsonSerializer.Serialize(garageData, options);
            File.WriteAllText("garage.json", jsonData);
            return true; // saved successfully
        }
        catch (Exception e)
        {
            return false; //could not save
        }

    }

    public bool LoadGarage()
    {
        throw new NotImplementedException();
    }
}