namespace GarageOne;

public class Motorcycle : Vehicle
{
    public double CylinderVol { get; protected set; }

    public Motorcycle(string registrationNr, string color, int nrOfWheels, double cylinderVol) : base(registrationNr, color, nrOfWheels)
    {
        CylinderVol = cylinderVol;
    }
}