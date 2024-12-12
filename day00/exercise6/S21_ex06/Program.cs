namespace S21_ex06
{

    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите массив parent, разделенный запятыми:");
                    string parentInput = Console.ReadLine();
                    int[] parent = ParseParentArray(parentInput);

                    Console.WriteLine("Введите строку s, соответствующую узлам:");
                    string s = Console.ReadLine();

                    if (s.Length != parent.Length)
                    {
                        Console.WriteLine("Couldn't parse a words. Please, try again.");
                        continue;
                    }

                    (int maxLength, List<int> path) = FindLongestPath(parent, s);

                    Console.WriteLine($"Самая длинная длина пути: {maxLength}");
                    Console.WriteLine($"Путь: {string.Join(", ", path)}");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't parse a words. Please, try again.");
                }
            }
        }

        static int[] ParseParentArray(string input)
        {
            try
            {
                return input.Split(',')
                            .Select(x => int.Parse(x.Trim()))
                            .ToArray();
            }
            catch
            {
                throw new FormatException("Invalid parent array");
            }
        }

        static List<int>[] BuildTree(int[] parent)
        {
            int n = parent.Length;
            List<int>[] tree = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                tree[i] = new List<int>();
            }

            for (int i = 1; i < n; i++)
            {
                tree[parent[i]].Add(i);
            }

            return tree;
        }

        static (int maxLength, List<int> path) FindLongestPath(int[] parent, string s)
        {
            List<int>[] tree = BuildTree(parent);
            int maxLength = 0;
            List<int> longestPath = new List<int>();

            // Выполняем DFS для каждого узла
            for (int i = 0; i < parent.Length; i++)
            {
                int currentLength = 0;
                List<int> currentPath = new List<int>();

                Dfs(tree, s, i, ref currentLength, ref currentPath);

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    longestPath = currentPath;
                }
            }

            return (maxLength, longestPath);
        }

        static void Dfs(List<int>[] tree, string s, int node, ref int maxLength, ref List<int> longestPath)
        {
            int max1 = 0, max2 = 0;
            List<int> localPath1 = new List<int>();
            List<int> localPath2 = new List<int>();

            foreach (int child in tree[node])
            {
                if (s[child] != s[node])
                {
                    int childLength = 0;
                    List<int> childPath = new List<int>();

                    Dfs(tree, s, child, ref childLength, ref childPath);

                    if (childLength > max1)
                    {
                        max2 = max1;
                        localPath2 = new List<int>(localPath1);

                        max1 = childLength;
                        localPath1 = new List<int>(childPath);
                    }
                    else if (childLength > max2)
                    {
                        max2 = childLength;
                        localPath2 = new List<int>(childPath);
                    }
                }
            }

            // Формируем текущий путь
            int currentLength = 1 + max1;
            localPath1.Add(node); // Узел добавляется в конец пути для правильного порядка

            if (1 + max1 + max2 > maxLength)
            {
                maxLength = 1 + max1 + max2;
                longestPath = new List<int>(localPath1.Concat(localPath2));
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                longestPath = new List<int>(localPath1);
            }
        }
    }
}