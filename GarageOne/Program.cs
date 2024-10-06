using System.ComponentModel.Design;

namespace GarageOne
{
    internal class Program
    {
        private static GarageHandler garageHandler = new GarageHandler();
        private static UI ui = new UI(garageHandler);

        static void Main(string[] args)
        {
            garageHandler.Initialize();
            ui.Menu();

        }
    }
}
