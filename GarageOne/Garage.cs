using System.Collections;

namespace GarageOne;

public class GarageData
{
    public int Capacity { get; set; }
    public List<Vehicle> Vehicles { get; set; }
}
public class Garage<T> : IEnumerable<T> where T : Vehicle
{
    private Vehicle?[] vehicles;

    public Vehicle?[] Vehicles
    {
        get => vehicles;
    }

    public Garage(int capacity)
    {
        vehicles = new Vehicle[capacity];
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T vehicle in vehicles)
        {
            if (vehicle != null)
            {
                yield return vehicle;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        foreach (Vehicle vehicle in vehicles)
        {
            if (vehicle != null)
            {
                yield return vehicle;
            }
        }
    }

    public bool AddVehicle(Vehicle vehicle)
    {
        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] == null)
            {
                vehicles[i] = vehicle;
                return true; // added successfully
            }
        }

        Console.WriteLine("There is not more space in the garage");
        return false; // could not add
    }
}