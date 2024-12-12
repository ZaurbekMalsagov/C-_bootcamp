namespace S21_ex09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList<int>();

            // Пример Add
            Console.WriteLine("Действие Add:");
            myList.Add(37);
            myList.Add(45);
            myList.Add(78);
            myList.Add(99);
            Console.WriteLine("Начальный список: " + string.Join(", ", myList.ToArray()));
            myList.Add(119);
            Console.WriteLine("Измененный список: " + string.Join(", ", myList.ToArray()));

            // Пример Count
            Console.WriteLine("\nДействие Count:");
            Console.WriteLine("Список: " + string.Join(", ", myList.ToArray()));
            Console.WriteLine("Количество элементов в списке: " + myList.Count());

            // Пример Remove
            Console.WriteLine("\nДействие Remove:");
            myList.Remove(99);
            Console.WriteLine("Измененный список: " + string.Join(", ", myList.ToArray()));
        }
    }

    public class MyList<T>
    {
        private T[] _items; // Внутренний массив для хранения элементов
        private int _size;  // Текущее количество элементов

        public MyList()
        {
            _items = new T[4]; // Начальный размер массива
            _size = 0;
        }

        // Добавление элемента в список
        public void Add(T item)
        {
            if (_size == _items.Length) // Увеличиваем размер массива, если он заполнен
            {
                Resize();
            }
            _items[_size] = item; // Добавляем элемент
            _size++;
        }

        // Удаление элемента из списка
        public void Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1) return; // Если элемент не найден, ничего не делаем

            // Сдвигаем элементы влево, начиная с индекса удаления
            for (int i = index; i < _size - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _size--; // Уменьшаем размер
            _items[_size] = default; // Обнуляем последний элемент
        }

        // Возвращает количество элементов в списке
        public int Count() => _size;

        // Метод для получения всех элементов в виде массива
        public T[] ToArray()
        {
            T[] result = new T[_size];
            Array.Copy(_items, result, _size);
            return result;
        }

        // Метод для увеличения размера внутреннего массива
        private void Resize()
        {
            int newSize = _items.Length * 2;
            T[] newArray = new T[newSize];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }

        // Метод для нахождения индекса элемента
        private int IndexOf(T item)
        {
            int result = -1;
            for (int i = 0; i < _size; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], item))
                {
                    result= i;
                    break;
                }
            }
            return result; // Элемент не найден
        }
    }
}
