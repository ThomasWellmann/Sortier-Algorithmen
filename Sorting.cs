using System.Security.Cryptography;

namespace Sortier_Algorithmen
{
    internal class Sorting : Screen
    {
        SortingAlgorithm algorithm = new SortingAlgorithm(mainList);

        public override Screen Start()
        {
            ClearConsole();
            Print("Your List:");
            PrintList(mainList);
            GetTextSpacements();

            GetWishedSortingAlgorithm();

            Print("Press ", "Space-Bar", " to try another sorting method or ", "ESC", " restart the program.");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Spacebar) return new Sorting();
                else if (key.Key == ConsoleKey.Escape) return new Lobby();
            }
        }

        void GetWishedSortingAlgorithm()
        {
            Print("You can now sort your list in 3 different ways:");
            Print("(", "1", ") Increasing");
            Print("(", "2", ") Decreasing");
            Print("(", "3", ") Zig-Zag\n\n");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    Print("Your list got sorted and the numbers on it are increasing:");
                    PrintList(algorithm.Increasing());
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Print("Your list got sorted and the numbers on it are decreasing:");
                    PrintList(algorithm.Decreasing());
                    break;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    Print("Your list got sorted and the numbers on it are zig-zagging:");
                    PrintList(algorithm.ZigZag());
                    break;
                }
            }
        }
    }
}
