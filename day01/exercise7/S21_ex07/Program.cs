using System.Globalization;
using System.Linq;

namespace S21_ex07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество пар:");
            int coupleCount = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int count) ? count: 0;
            if (coupleCount > 0) {
                Dictionary<string, double> result = new Dictionary<string, double>();
                Console.WriteLine($"Введите {coupleCount} пар значений в формате (название, цена):");
                for (int i = 0; i < coupleCount; i++) {
                    var input = Console.ReadLine()?.Split(' ');
                    if (input.Contains("") || !input.Any() || input.Count() < 2)
                    {
                        Console.WriteLine("Couldn't parse a words. Please, try again");
                        continue;
                    }
                    var value = double.TryParse(input[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double number) ? number : 0;
                    if (value > 0 && !result.ContainsKey(input[0]))
                        result.Add(input[0], Math.Round(value, 3));
                    else Console.WriteLine("Incorrect input. price <= 0 or key already exists");
                }
                Console.WriteLine(result.Count>0 ? result?.Select(x => x.Value)?.Average(): "No data");
            }
            else
            {
                Console.WriteLine("Неккоректное значение");
            }
        }
    }
}
