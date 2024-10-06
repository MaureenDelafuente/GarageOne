namespace GarageOne;

public class Bus : Vehicle 
{
    public int NrOfPassengers { get; protected set; }

    public Bus(string registrationNr, string color, int nrOfWheels, int nrOfPassengers) : base(registrationNr, color, nrOfWheels)
    {
        NrOfPassengers = nrOfPassengers;
    }
   
}