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
            transports.Where(t => t is IFlyable).ToList().ForEach(t => Console.WriteLine( t.Intelligence()) );
            transports.Where(t => t is IDrivable).ToList().ForEach(t => Console.WriteLine(t.Intelligence()));

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
                    //Vehicle vehicle;
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
                    var speed = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int spd) ? spd : -1;
                    if (speed < 0)
                    {
                        Console.WriteLine("Incorrect input. Speed < 0");
                        continue;
                    }
                    if (vehicleType == "plane" || vehicleType == "airship")
                    {
                        result.Add(CreateFlyableVehicle(vehicleType, type, speed));
                    }
                    else
                    {
                        result.Add(CreateDrivableVehicle(vehicleType, type, speed));

                    }


                }

            }
            return result;
        }

        private static Vehicle CreateFlyableVehicle(string vehicleType, string type, int speed)
        {
            Console.WriteLine("Введите максимальную высоту полета:");
            var maxFlightAltitude = float.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out float mxat) ? mxat : -1;
            Vehicle vehicle = null;
            if (maxFlightAltitude <= 0)
            {
                Console.WriteLine("Incorrect input. maxFlightAltitude < 0");

            }
            else
            {
                switch (vehicleType)
                {
                    case "plane":
                        vehicle = new Plane(type, speed, maxFlightAltitude);
                        break;
                    case "airship":
                        vehicle = new Airship(type, speed, maxFlightAltitude);
                        break;
                }
            }

             return vehicle;
        }

        private static Vehicle CreateDrivableVehicle(string vehicleType, string type, int speed)
        {
            Console.WriteLine("Введите количество колес:");
            var numberOfWheels = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int wheels) ? wheels : -1;
            Vehicle vehicle = null;
            if (numberOfWheels <= 0)
            {
                Console.WriteLine("Incorrect input. numberOfWheels <= 0");
                
            }
            else
            {
                switch (vehicleType)
                {
                    case "car":
                        vehicle = new Car(type, speed, numberOfWheels);
                        break;
                    case "bike":
                        vehicle = new Bike(type, speed, numberOfWheels);
                        break;
                }
            }

            return vehicle;
        }
    }
}
