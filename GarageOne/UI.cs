namespace GarageOne;

public class UI : IUI
{
    private IHandler garageHandler;

    public UI(IHandler garageHandler)
    {
        this.garageHandler = garageHandler;
    }

    public void Menu()
    {
        bool start = true;
        while (start)
        {
            PrintMenu();
            string command = ReadString("Menu option");
            switch (command)
            {
                case "1":
                    ListVehicles();
                    break;
                case "2":
                    ListVehicleTypes();
                    break;
                case "3":
                    AddVehicle();
                    break;
                case "4":
                    RemoveVehicle();
                    break;
                case "5":
                    Search();
                    break;
                case "6":
                    NewGarage();
                    break;
                case "7":
                    SaveGarage();
                    break;
                case "8":
                    LoadGarage();
                    break;
                case "0":
                    start = false;
                    break;
            }
        }
    }

    private void LoadGarage()
    {
        bool success = garageHandler.LoadGarage();
        if (success)
        {
            Console.WriteLine("Successfully saved garage!");
        }
        else
        {
            Console.WriteLine("Failed to save garage!");
        }
    }

    private void SaveGarage()
    {
        bool success = garageHandler.SaveGarage();
        if (success) {
            Console.WriteLine("Successfully saved garage!");
        } else {
            Console.WriteLine("Failed to save garage!");
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("\nChoose Option");
        Console.WriteLine("1. List Vehicles");
        Console.WriteLine("2. List VehicleTypes");
        Console.WriteLine("3. Add Vehicle");
        Console.WriteLine("4. Remove Vehicle");
        Console.WriteLine("5. Search Vehicle");
        Console.WriteLine("6. New Garage");
        Console.WriteLine("7. Save Garage");
        Console.WriteLine("8. Load Garage");
        Console.WriteLine("0. Exit program");
    }

    private void NewGarage()
    {
        Console.WriteLine("How many parking spaces should garage have?");
        try
        {
            string input = Console.ReadLine() ?? "";
            int nrOfSpaces = int.Parse(input);
            bool success = garageHandler.NewGarage(nrOfSpaces);
            if (success) {
                Console.WriteLine($"Created a new garage with {nrOfSpaces} parking spaces.");
            }
            else
            {
                Console.WriteLine("Failed to create new garage.");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Wrong input, please try again");
        }
    }

    private void RemoveVehicle()
    {
        Console.WriteLine("Which vehicle do you want to remove?");
        string regNr = ReadString("Registration number");
        bool success = garageHandler.RemoveVehicle(regNr);
        if (success)
        {
            Console.WriteLine($"Removed the vehicle with registration number {regNr}.");
        }
        else
        {
            Console.WriteLine($"Failed to remove a vehicle with registration number {regNr}.");
        }
    }

    private void AddVehicle()
    {
        Console.WriteLine("What type of Vehicle do you want to add?");
        Console.WriteLine(" 1. Airplane  2. Boat  3. Bus  4. Car  5. Motorcycle");
        string command = ReadString("Vehicle type");
        Vehicle newVehicle;
        switch (command)
        {
            case "1":
                newVehicle = NewAirplane();
                break;
            case "2":
                newVehicle = NewBoat();
                break;
            case "3":
                newVehicle = NewBus();
                break;
            case "4":
                newVehicle = NewCar();
                break;
            case "5":
                newVehicle = NewMotorcycle();
                break;
            default:
                Console.WriteLine("No type chosen, returning to menu");
                return;
        }

        bool success = garageHandler.AddVehicle(newVehicle);
        if (success)
        {
            Console.WriteLine($"Added vehicle: {newVehicle}");
        }
        else
        {
            Console.WriteLine($"Failed to add vehicle ({newVehicle})");
        }
    }

    private Vehicle NewAirplane()
    {
        string regNr = ReadString("Registration number");
        string color = ReadString("Color");
        int nrOfWheels = ReadInt("Number of wheels");
        int nrOfEngines = ReadInt("Number of engines");
        return new Airplane(regNr, color, nrOfWheels, nrOfEngines);
    }

    private Vehicle NewBoat()
    {
        string regNr = ReadString("Registration number");
        string color = ReadString("Color");
        int nrOfWheels = ReadInt("Number of wheels");
        double length = ReadDouble("Length in meters");
        return new Boat(regNr, color, nrOfWheels, length);
    }

    private Vehicle NewBus()
    {
        string regNr = ReadString("Registration number");
        string color = ReadString("Color");
        int nrOfWheels = ReadInt("Number of wheels");
        int nrOfPassengers = ReadInt("Number of passengers");
        return new Bus(regNr, color, nrOfWheels, nrOfPassengers);
    }

    private Vehicle NewCar()
    {
        string regNr = ReadString("Registration number");
        string color = ReadString("Color");
        int nrOfWheels = ReadInt("Number of wheels");
        bool isElectric = ReadBool("Is the car electric (yes/no)?");
        return new Car(regNr, color, nrOfWheels, isElectric);
    }

    private Vehicle NewMotorcycle()
    {
        string regNr = ReadString("Registration number");
        string color = ReadString("Color");
        int nrOfWheels = ReadInt("Number of wheels");
        double vol = ReadInt("Cylinder volume in cc");
        return new Motorcycle(regNr, color, nrOfWheels, vol);
    }

    private bool ReadBool(string prompt)
    {
        Console.Write($"{prompt}: ");
        try
        {
            string input = Console.ReadLine() ?? "";
            bool result = input.ToLower() == "yes";
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Invalid input '{e}'");
        }

        return false;
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            try
            {
                string input = Console.ReadLine() ?? "";
                int number = int.Parse(input);
                return number;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid number, try again!");
            }
        }
    }

    private double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            try
            {
                string input = Console.ReadLine() ?? "";
                double number = double.Parse(input);
                return number;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid number '{e}', try again!");
            }
        }
    }

    private static string ReadString(string prompt)
    {
        Console.Write($"{prompt}: ");
        try
        {
            return Console.ReadLine() ?? "";
        }
        catch (Exception e)
        {
            Console.WriteLine($"Invalid input '{e}'");
        }

        return "";
    }

    private void ListVehicleTypes()
    {
        garageHandler.ListVehicleTypes();
    }

    private void ListVehicles()
    {
        garageHandler.ListVehicles();
    }

    private void Search()
    {
        string regNr = ReadString("Registration number (empty for any)");
        string color = ReadString("Color (empty for any)");
        int nrOfWheels = ReadInt("Number of wheels (-1 for any)");
        var searchResults = garageHandler.Search(regNr, color, nrOfWheels);

        foreach (Vehicle v in searchResults)
        {
            Console.WriteLine(v);
        }
    }
}