using System.Globalization;
using System;

namespace S21_ex02
{
    internal class Program
    {

        static void Main(string[] args)
        {
            double[,] matrix;

            while (true)
            {
                Console.WriteLine("Введите путь к файлу с расширенной матрицей:");
                string filePath = Console.ReadLine();

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Input error. File isn't exist");
                    continue;
                }

                try
                {
                    matrix = ReadMatrixFromFile(filePath);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Couldn't parse a number. Please, try again.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return;
                }
            }

            double[] solution;
            if (SolveGaussian(matrix, out solution))
            {
                Console.WriteLine("Решение:");
                for (int i = 0; i < solution.Length; i++)
                {
                    Console.WriteLine($"x{i + 1} = {solution[i]}");
                }
            }
            else
            {
                Console.WriteLine("The system of linear algebraic equations has no solutions.");
            }
        }

        static double[,] ReadMatrixFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            int rows = lines.Length;
            int cols = lines[0].Split(' ').Length;

            double[,] matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var elements = lines[i].Split(' ');

                if (elements.Length != cols)
                    throw new FormatException("Invalid matrix format");

                for (int j = 0; j < cols; j++)
                {
                    if (!double.TryParse(elements[j], out matrix[i, j]))
                        throw new FormatException("Invalid number format");
                }
            }

            return matrix;
        }

        static bool SolveGaussian(double[,] matrix, out double[] solution)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            bool result = true;
            solution = null;
            if (m != n + 1)
            {
                result = false;
            }
            if (result != false)
            {
                // Прямой ход метода Гаусса
                for (int i = 0; i < n; i++)
                {
                    // Поиск ведущего элемента в текущем столбце
                    int maxRow = i;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (Math.Abs(matrix[k, i]) > Math.Abs(matrix[maxRow, i]))
                        {
                            maxRow = k;
                        }
                    }

                    // Перестановка строк
                    for (int k = i; k < m; k++)
                    {
                        double tmp = matrix[maxRow, k];
                        matrix[maxRow, k] = matrix[i, k];
                        matrix[i, k] = tmp;
                    }

                    // Если элемент на главной диагонали равен 0, то решения нет
                    if (Math.Abs(matrix[i, i]) < 1e-10)
                    {
                        solution = null;
                        return false;
                    }

                    // Приведение строки к нужному виду
                    for (int k = i + 1; k < n; k++)
                    {
                        double factor = matrix[k, i] / matrix[i, i];
                        for (int j = i; j < m; j++)
                        {
                            matrix[k, j] -= factor * matrix[i, j];
                        }
                    }
                }

                // Обратный ход для получения решения
                solution = new double[n];
                for (int i = n - 1; i >= 0; i--)
                {
                    solution[i] = matrix[i, n] / matrix[i, i];
                    for (int k = i - 1; k >= 0; k--)
                    {
                        matrix[k, n] -= matrix[k, i] * solution[i];
                    }
                }
            }

            return result;
        }
    }
}

