namespace S21_ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath;
            string[] lines;
            string[] textLines = null;
            string targetWord = null;
            int frequency = 0;

            Console.WriteLine("Введите путь до файла:");

            filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath);

                if (ValidateInput(lines, out int lineCount))
                {
                    textLines = new string[lineCount];
                    Array.Copy(lines, 1, textLines, 0, lineCount);
                    targetWord = lines[^1].Trim();

                    frequency = CountWordFrequency(textLines, targetWord);

                    Console.WriteLine("Считанные строки:");
                    foreach (var line in textLines)
                    {
                        Console.WriteLine(line);
                    }

                    Console.WriteLine($"Слово для подсчета: {targetWord}");
                    Console.WriteLine($"Частотность слова: {frequency}");

                    File.WriteAllText("result.txt", $"Слово \"{targetWord}\" встречается {frequency} раз(а).");
                }

               
            }
            else
            {
                Console.WriteLine("Input error. File isn't exist.");
                
            }

            
        }

        static bool ValidateInput(string[] lines, out int lineCount)
        {
            lineCount = 0;
            bool isValid = true;

            if (lines.Length < 2)
            {
                Console.WriteLine("Input error. Insufficient number of elements.");
                isValid = false;
            }
            else if (!int.TryParse(lines[0], out lineCount) || lineCount <= 0)
            {
                Console.WriteLine("Input error. Size <= 0.");
                isValid = false;
            }
            else if (lines.Length - 2 < lineCount)
            {
                Console.WriteLine("Input error. Insufficient number of elements.");
                isValid = false;
            }

            return isValid;
        }

        static int CountWordFrequency(string[] lines, string word)
        {
            int count = 0;

            foreach (var line in lines)
            {
                string[] words = line.Split(new[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var w in words)
                {
                    if (string.Equals(w, word, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
