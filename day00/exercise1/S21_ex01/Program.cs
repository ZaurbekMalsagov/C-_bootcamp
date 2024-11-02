using System.Globalization;

namespace S21_ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool answer = false;
            while(answer == false)
            {
                Console.WriteLine("Введите координаты четырех вершин четырехугольника (x,y) через пробел: ");
                string input = Console.ReadLine();
                var points = ParsePoints(input);
                // -1.0 -1.0 1.0 4.0 3.0 0.0 1.0 -1.0
                // -4.0 -3.0 -2.0 6.0 5.0 3.0 7.0 -3.0

                if (points == null || points.Length != 4)
                {
                    Console.WriteLine("Couldn't parse a number. Please, try again.\n");
                } else
                {
                    Console.WriteLine($"Square  = {CalculateQuadrilateralArea(points[0], points[1], points[2], points[3])}");
                    answer = true;
                }
            }

        }

        private static (double X, double Y)[] ParsePoints(string input)
        {
            (double X, double Y)[] points = null;
            try
            {
                var parts = input.Split(' ');
                if (parts.Length == 8)
                {
                    points = new (double X, double Y)[4];
                    int point_count = 0;
                    for (int i = 0; i < parts.Length; i+=2)
                    {
                    
                        if (double.TryParse(parts[i], NumberStyles.Any, CultureInfo.InvariantCulture, out double x) && double.TryParse(parts[i + 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double y))
                        {
                            points[point_count++] = (x, y);
                            

                        } else
                        {
                            points = null;
                            break;
                        }
                    }
                }
    
            }
            catch (Exception ex)
            {
                points = null;
            }
            return points;
        }

        /// <summary>
        /// Находим расстояние между точками
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private static double Distance((double X, double Y) p1, (double X, double Y) p2) => Math.Sqrt((Math.Pow((p2.X - p1.X), 2)) + (Math.Pow((p2.Y - p1.Y), 2)));

        /// <summary>
        /// Считаем площадь треугольника
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        private static double CalculateTriangleArea((double X, double Y) p1, (double X, double Y) p2, (double X, double Y) p3)
        {
            double a = Distance(p1, p2);
            double b = Distance(p2, p3);
            double c = Distance(p3, p1);
            double p = (a+ b + c)/2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p-c));
        }

        /// <summary>
        /// Считаем площадь четырехугольника
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <returns></returns>
        private static double CalculateQuadrilateralArea((double X, double Y) p1, (double X, double Y) p2, (double X, double Y) p3, (double X, double Y) p4) => Math.Round(CalculateTriangleArea(p1, p2, p3) + CalculateTriangleArea(p1, p3, p4), 2);
    }
}
