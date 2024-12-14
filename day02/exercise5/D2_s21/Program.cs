using D2_s21.Abstract;
using D2_s21.Abstract.Interfaces;
using System.Globalization;
using System.Reflection;

namespace D2_s21
{
    internal class Program
    {
        private static List<string> transportTypes;
        static void Main(string[] args)
        {
            transportTypes = new List<string> { "car", "bike" };
            List<Vehicle> transports = ParseInput();

            if (transports.Count < 2)
                Console.WriteLine("No one to compete with");
            else
            {
                transports.OrderBy(t => t.TimeRace()).ToList().
                            ForEach(t => Console.WriteLine($"{t.Intelligence()}, timeRace = {t.TimeRace()}"));
                var winner = transports.OrderBy(t => t.TimeRace()).First();
                Console.WriteLine($"Winner = {winner.GetTypeInfo()} {winner.GetVehicleType()} with speed {winner.GetSpeed()} m/s");
            }

        }

        private static List<Vehicle> ParseInput()
        {
            Console.WriteLine("Введите количество транспортных средств:");
            int transportCount = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int count) ? count : 0;
            var result = new List<Vehicle>();

            if (transportCount > 0)
            {
                var distance = double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double dr) ? dr : -1;
                if (distance <= 0)
                {
                    Console.WriteLine($"Incorrect input. Distance < 0");

                }
                for (int i = 0; i < transportCount; i++)
                {
                    Vehicle vehicle;
                    var vehicleType = Console.ReadLine().ToLower();
                    if (!(transportTypes.Contains(vehicleType)))
                    {
                        Console.WriteLine("Incorrect input. Unsupported vehicle type");
                        continue;
                    }
                    var type = Console.ReadLine();
                    if (string.IsNullOrEmpty(type))
                    {
                        Console.WriteLine("Incorrect input");
                        continue;
                    }
                    var speed = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int spd) ? spd: -1;
                    if (speed < 0)
                    {
                        Console.WriteLine("Incorrect input. Speed < 0");
                        continue;
                    }
                    
                    switch (vehicleType)
                    {

                        case "car":
                            vehicle = new Car(type, speed, distance);
                            result.Add(vehicle);
                            break;
                        case "bike":
                            vehicle = new Bike(type, speed, distance);
                            result.Add(vehicle);
                            break;

                    }

                }
            }
            return result;
        }


        
    }
}
