using System.Drawing;

namespace GarageOne;

public class Boat : Vehicle
{
    public double Length { get; protected set; }

    public Boat(string registrationNr, string color, int nrOfWheels, double length) : base(registrationNr, color, nrOfWheels)
    {
        Length = length;
    }
}