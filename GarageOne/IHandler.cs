namespace GarageOne;

public interface IHandler
{
    public bool NewGarage(int numberOfSpaces);
    public void Initialize();
    public void ListVehicles();
    public void ListVehicleTypes();

    public bool AddVehicle(Vehicle newVehicle);
    public bool RemoveVehicle(string regNr);
    public IEnumerable<Vehicle> Search(string regNr, string color, int nrOfWheels);

    public bool SaveGarage();
    public bool LoadGarage();
}