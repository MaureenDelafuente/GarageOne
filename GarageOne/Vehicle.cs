namespace GarageOne;

public class Vehicle : IVehicle
{
    public string RegistrationNr { get; protected set; }
    public string Color { get; protected set; }
    public int NrOfWheels { get; protected set; }

    public Vehicle(string registrationNr, string color, int nrOfWheels)
    {
        RegistrationNr = registrationNr.ToUpper();
        Color = color;
        NrOfWheels = nrOfWheels;
    }

    public override string ToString()
    {
        return $"{GetType().Name,10}, registration number:{RegistrationNr,10}, color:{Color,10}, wheels:{NrOfWheels,3}";
    }
}



