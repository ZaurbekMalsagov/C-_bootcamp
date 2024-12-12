namespace S21_ex04
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значения узлов списка через запятую:");
            string input = Console.ReadLine();

            try
            {
                ListNode head = BuildList(input);
                Console.WriteLine("Исходный список:");
                PrintList(head);

                ReorderList(head);

                Console.WriteLine("Измененный список:");
                PrintList(head);
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't parse a number. Please, try again.");
            }
        }

        // Построение односвязного списка из строки
        static ListNode BuildList(string input)
        {
            var values = input.Split(',');

            ListNode dummy = new ListNode(); // Временный узел для удобства построения
            ListNode current = dummy;

            foreach (var value in values)
            {
                if (int.TryParse(value.Trim(), out int val))
                {
                    current.next = new ListNode(val);
                    current = current.next;
                }
                else
                {
                    throw new FormatException("Invalid number in input.");
                }
            }

            return dummy.next; // Возвращаем голову списка
        }

        // Вывод списка в консоль
        static void PrintList(ListNode head)
        {
            var current = head;
            var result = new List<int>();

            while (current != null)
            {
                result.Add(current.val);
                current = current.next;
            }

            Console.WriteLine(string.Join(", ", result));
        }

        // Изменение порядка узлов списка
        static void ReorderList(ListNode head)
        {
            if (head == null || head.next == null)
                return;

            // Используем стек для хранения узлов
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode current = head;
            int length = 0;

            // Пройдемся по списку, чтобы узнать его длину и заполнить стек
            while (current != null)
            {
                stack.Push(current);
                current = current.next;
                length++;
            }

            current = head;
            for (int i = 0; i < length / 2; i++)
            {
                // Извлекаем узел из стека
                ListNode tail = stack.Pop();

                // Перенастраиваем ссылки
                ListNode next = current.next; // Сохраняем следующий узел
                current.next = tail;          // Переставляем текущий узел на tail
                tail.next = next;             // Переставляем tail на следующий узел

                // Переходим к следующему узлу
                current = next;
            }

            // Завершаем список
            current.next = null;
        }
    }
}
