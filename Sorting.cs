using System.Security.Cryptography;

namespace Sortier_Algorithmen
{
    internal class Sorting : Screen
    {
        SortingAlgorithm algorithm = new SortingAlgorithm(mainList);
        string sortedAs;

        public override Screen Start()
        {
            ClearConsole();
            Print($"Your List (size: {mainList.Count}):");
            PrintList(algorithm.list);
            GetTextSpacements();

            GetWishedSortingAlgorithm();

            Print("Press ", "Enter", " to continue or ", "ESC", " restart the program.");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Enter) return this;
                else if (key.Key == ConsoleKey.Escape) return new Lobby();
            }
        }

        void GetWishedSortingAlgorithm()
        {
            if (sortedAs == null)
            {
                Print("You can now sort your list in 3 different ways or just add another number:");
            }
            else
            {
                Print($"Your list is now {sortedAs}.");
                Print($"Your can change the list's sorting method or add another number as it is sorted.");
            }
            Print("(", "1", ") Increscent");
            Print("(", "2", ") Decrescent");
            Print("(", "3", ") Zig-Zag");
            Print("(", "4", ") Shuffle");
            Print("(", "5", ") Add new number (max list size: 75)\n\n");

            while (true)
            {
                var toAdd = -1;
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    sortedAs = "increscent";
                    algorithm.Increscent();
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    sortedAs = "decrescent";
                    algorithm.Decrescent();
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    sortedAs = "zig-zagging";
                    algorithm.ZigZag();
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    sortedAs = "shuffled";
                    algorithm.Shuffle();
                }
                else if (key.Key == ConsoleKey.D5)
                {
                    if (algorithm.list.Count < 75)
                    {
                        Print("Type below the number you wish to add.");
                        while (true)
                        {
                            var input = ReadLine();
                            if (int.TryParse(input, out toAdd) && toAdd > 0 && toAdd < 1000) //Min number 1 //Max number 999 
                            {
                                Console.WriteLine();
                                algorithm.Add(toAdd, sortedAs);
                                break;
                            }
                            ClearLine(input.Length);
                        }
                    }
                    else
                    {
                        Print("This action is not possible because your list is already too long.");
                        break;
                    }
                }
                else continue;
                Print((key.Key != ConsoleKey.D5) ? $"Your list got sorted and the numbers on it are {sortedAs}:" : $"{toAdd} got added and your list now look like this:");
                PrintList(algorithm.list);
                break;
            }
        }
    }
}
