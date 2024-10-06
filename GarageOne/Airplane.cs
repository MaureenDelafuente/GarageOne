namespace GarageOne;

public class Airplane : Vehicle
{
    public int NrOfEngines { get; protected set;}

    public Airplane(string registrationNr, string color, int nrOfWheels, int nrOfEngines) : base(registrationNr, color, nrOfWheels)
    {
        NrOfEngines = nrOfEngines;
    }
}