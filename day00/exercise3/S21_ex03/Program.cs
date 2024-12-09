namespace S21_ex03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] deck;

            while (true)
            {
                Console.WriteLine("Введите числа в массиве deck, разделенные запятыми:");
                string input = Console.ReadLine();

                try
                {
                    deck = ParseDeck(input);
                    if (deck.Distinct().Count() != deck.Length)
                    {
                        Console.WriteLine("Couldn't parse a number. Numbers must be unique. Please, try again.");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Couldn't parse a number. Please, try again.");
                }
            }

            int[] result = RevealDeckInOrder(deck);
            Console.WriteLine("Результат:");
            Console.WriteLine(string.Join(",", result));
        }

        static int[] ParseDeck(string input)
        {
            return input
                .Split(',')
                .Select(s => int.Parse(s.Trim()))
                .ToArray();
        }

        static int[] RevealDeckInOrder(int[] deck)
        {
            // Сортируем массив в порядке возрастания
            Array.Sort(deck);

            // Используем очередь для моделирования процесса
            Queue<int> queue = new Queue<int>();
            foreach (int i in Enumerable.Range(0, deck.Length))
            {
                queue.Enqueue(i);
            }

            // Результатный массив
            int[] result = new int[deck.Length];

            // Раскрытие карт
            foreach (int card in deck)
            {
                // Берем индекс для текущей карты
                int index = queue.Dequeue();
                result[index] = card;

                // Если остались карты, перемещаем следующий индекс в конец очереди
                if (queue.Count > 0)
                {
                    queue.Enqueue(queue.Dequeue());
                }
            }

            return result;
        }
    }
}
