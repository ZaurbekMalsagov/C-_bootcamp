using System.Globalization;

namespace D2_s21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> transports = ParseInput();
            transports.ForEach(t => Console.WriteLine( t.Intelligence()) );

        }

        private static List<Vehicle> ParseInput()
        {
            Console.WriteLine("Введите количество транспортов:");
            int transportCount = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int count) ? count : 0;
            var result = new List<Vehicle>();
            if (transportCount > 0)
            {
                for (int i = 0; i < transportCount; i++)
                {
                    Vehicle vehicle;
                    var vehicleType = Console.ReadLine().ToLower();
                    if (!(vehicleType == "plane" || vehicleType == "car"))
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
                    var speed = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int spd) ? spd : -1;
                    if (speed < 0)
                    {
                        Console.WriteLine("Incorrect input. Speed < 0");
                        continue;
                    }
                    var tankVolume = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int vol) ? vol : -1;
                    if (tankVolume < 0)
                    {
                        Console.WriteLine("Incorrect input. tankVolume < 0");
                        continue;
                    }
                    var distance = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int s) ? s : -1;
                    if (distance <= 0)
                    {
                        Console.WriteLine("Incorrect input. distance < 0");
                        continue;
                    }
                    switch (vehicleType)
                    {
                        case "plane":
                            vehicle = new Plane(type, speed, tankVolume, distance);
                            result.Add(vehicle);
                            break;
                        case "car":
                            vehicle = new Car(type, speed, tankVolume, distance);
                            result.Add(vehicle);
                            break;
                    }
                    
                }

            }
            return result;
        }
    }
}
