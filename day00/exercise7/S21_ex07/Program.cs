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
                    var value = input.Any() && !input.Contains("") && double.TryParse(input[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double number) ? number : 0;
                    if (input.Any() && value > 0)
                        result.Add(input[0], Math.Round(value, 3));
                    else Console.WriteLine("Incorrect input. price <= 0");
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
