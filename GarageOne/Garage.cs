using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;

namespace GarageOne;

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

    public void AddVehicle(Vehicle vehicle)
    {
        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] == null)
            {
                vehicles[i] = vehicle;
                return;
            }
        }

        Console.WriteLine("There is not more space in the garage");
    }
}