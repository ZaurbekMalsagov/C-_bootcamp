using System.Globalization;
using System.Text;

namespace S21_ex08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введи число студентов:");
            int studentsCount = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int count) ? count : 0;
            if (studentsCount > 0)
            {
                List<Student> students = new List<Student>();
                for (int i = 0; i < studentsCount; i++)
                {
                    var input = Console.ReadLine()?.Split(' ');
                    if (input.Contains("") || !input.Any() || input.Count() < 2)
                    {
                        Console.WriteLine("Couldn't parse a words. Please, try again");
                        continue;
                    }
                    var value = int.TryParse(input[1], NumberStyles.Any, CultureInfo.InvariantCulture, out int number) ? number : 0;
                    if (value > 0)
                        students.Add(new Student(input[0], value));
                    else Console.WriteLine("Incorrect input. price <= 0");
                }
                int findGroup = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int numberGroup) ? numberGroup : 0;
                if (findGroup > 0 || students.Count > 0)
                {
                    var studentNames = students.Where(x => x.Group == findGroup).Select(x => x.Name);
                    StringBuilder result = new StringBuilder();
                    foreach (var student in studentNames) 
                        result.Append(student);
                    Console.WriteLine(result.Length != 0? result.ToString(): "There are no students from such a group");
                }
            }
            else
            {
                Console.WriteLine("Так и зачем пришел, если студентов нет. Иди домой");
            }
        }
    }
}
