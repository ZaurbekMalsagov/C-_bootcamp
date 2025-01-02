using D2_s21.Abstract;
using D2_s21.Abstract.Interfaces;
using System.Globalization;

namespace D2_s21
{
    internal class Program
    {
        private static List<string> transportTypes;
        static void Main(string[] args)
        {
            transportTypes = new List<string> { "plane", "car", "airship", "bike" };
            List<Vehicle> transports = ParseInput();
            transports.OrderByDescending(t => t.GetYear()).ToList().ForEach(t => Console.WriteLine(t.Intelligence()));
            //transports.ForEach(t => Console.WriteLine(t.Intelligence()));

        }

        private static List<Vehicle> ParseInput()
        {
            Console.WriteLine("Введите количество транспортных средств:");
            int transportCount = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int count) ? count : 0;
            var result = new List<Vehicle>();
            if (transportCount > 0)
            {
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
                    var speed = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int spd) ? 
                        (spd > 100 ? spd * 1.07 : spd) : -1;
                    if (speed < 0)
                    {
                        Console.WriteLine("Incorrect input. Speed < 0");
                        continue;
                    }
                    var year = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int yr) ? yr : -1;
                    if (year < 0 || year > DateTime.Today.Year)
                    {
                        Console.WriteLine($"Incorrect input. year < 0 or year > {DateTime.Today.Year}");
                        continue;
                    }
                    switch (vehicleType)
                    {
                        case "plane":
                            vehicle = new Plane(type, speed, year);
                            result.Add(vehicle);
                            break;
                        case "car":
                            vehicle = new Car(type, speed, year);
                            result.Add(vehicle);
                            break;
                        case "airship":
                            vehicle = new Airship(type, speed, year);
                            result.Add(vehicle);
                            break;
                        case "bike":
                            vehicle = new Bike(type, speed, year);
                            result.Add(vehicle);
                            break;

                    }

                }
            }
            return result;
        }
        
    }
}
