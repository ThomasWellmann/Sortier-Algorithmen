namespace Sortier_Algorithmen
{
    internal class Sorting : Screen
    {
        SortingAlgorithm algorithm;
        int deltaTime;
        string sorting;

        public Sorting(List<int> _list)
        {
            algorithm = new SortingAlgorithm(_list);
        }

        public override Screen Start()
        {
            ClearConsole();
            Print($"Your List (size: {algorithm.list.Count}):");
            PrintList(algorithm.list);
            GetTextSpacements();

            return GetWishedSortMethod();
        }

        Screen GetWishedSortMethod()
        {
            Print("Now choose with wich algorithm you want to sort your list:");
            Print("(", "1", ") // Sort");
            Print("(", "2", ") Bubble Sort");
            Print("(", "3", ") // Sort\n\n");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    sorting = "//";
                    algorithm.Sort(1);
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    sorting = "bubble-sorting";
                    algorithm.Sort(2);
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    sorting = "//";
                    algorithm.Sort(3);
                }
                else continue;
                break;
            }
            Print($"Your list used the {sorting} algorithm (time to sort: {deltaTime}ms):");
            PrintList(algorithm.list);

            Print("Press ", "Enter", " to continue or ", "ESC", " restart the program.");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Enter) return new Showing(algorithm);
                else if (key.Key == ConsoleKey.Escape) return new Lobby();
            }
        }
    }
}
