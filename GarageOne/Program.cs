namespace GarageOne
{
    internal class Program
    {
        private static IHandler garageHandler = new GarageHandler();
        private static IUI ui = new UI(garageHandler);

        static void Main(string[] args)
        {
            garageHandler.Initialize();
            ui.Menu();

        }
    }
}
