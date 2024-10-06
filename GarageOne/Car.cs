namespace GarageOne;

public class Car : Vehicle
{
    public bool IsElectric { get; protected set; }

    public Car(string registrationNr, string color, int nrOfWheels, bool isElectric) : base(registrationNr, color, nrOfWheels)
    {
        IsElectric = isElectric;
    }
}