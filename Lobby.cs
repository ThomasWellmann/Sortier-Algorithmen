namespace Sortier_Algorithmen
{
    internal class Lobby : Screen
    {
        static List<int> mainList;
        public override Screen Start()
        {
            GetStarted();

            var key = ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                Lobby lobby = new Lobby();
                return lobby;
            }
            else
            {
                Algorithm algorithm = new Algorithm();
                return algorithm;
            }
        }

        void GetStarted()
        {
            mainList = new List<int>();
            ResizeWindow();
            SetDefaultColors();
            ClearConsole();
            Console.CursorVisible = false;

            PrintText($"Welcome to the Algorithm-Sorting-System!\n");
            GetWishedStartingList();

            PrintText("Press ", "ESC", " to restart or any other ", "Key", " to continue.");
        }

        void GetWishedStartingList()
        {
            PrintText("To get started, first select a list of numbers:\n");
            PrintText("(", "1", ") Get random");
            PrintText("(", "2", ") Set own");
            GetTextSpacements();

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    GetRandomStartList();
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    GetInputStartList();
                    break;
                }
            }
        }

        void GetRandomStartList()
        {
            PrintText("(1) Choose the size of your random list (3 - 10 | you can add more later):");
            while (true)
            {
                var input = ReadLine();
                input = Check0Value(input) ? "0" : input;
                if (int.TryParse(input, out int listSize) && listSize >= 0)
                {
                    if (listSize < 3) //Min size = 3
                    {
                        PrintText($"\n   You chose {listSize}, wich is too low, so it got changed to 3:");
                        listSize = 3;
                    }
                    else if (listSize > 100) //Max size = 10
                    {
                        PrintText($"\n   You chose {listSize}, wich is too high, so it got changed to 10:");
                        listSize = 10;
                    }
                    else PrintText($"\n   You now have a list with {listSize} numbers:");

                    for (int i = 0; i < listSize; i++)
                        mainList.Add(rnd.Next(1, 1000)); //Min number 1 //Max number 999 

                    PrintList(mainList);
                    break;
                }
                else ClearLine(input.Length);
            }
        }

        void GetInputStartList()
        {
            int intsAdded = 0;
            PrintText($"(2) Press ", "Enter", " to open the typing field.");
            PrintText($"Once you have at least 3 numbers, press ", "ESC", " to finish this process.");
            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Enter) //Add more
                {
                    while (true)
                    {
                        var input = ReadLine();
                        input = Check0Value(input) ? "0" : input;
                        if (int.TryParse(input, out int toAdd) && toAdd > 0 && toAdd < 1000) //Min number 1 //Max number 999 
                        {
                            intsAdded++;
                            mainList.Add(toAdd); 
                            PrintText($"{intsAdded}: You added {toAdd} to the list:");
                            PrintList(mainList);
                            break;
                        }
                        ClearLine(input.Length);
                    }
                    if (intsAdded < 10) //Max StartList size = 10
                    {
                        PrintText($"Press ", "Enter", " to add your next number."); 
                        continue;
                    }
                    else break;
                }
                else if (key.Key == ConsoleKey.Escape) //Exit
                {
                    if (intsAdded < 3) continue; //Min StartList size = 3 
                    else break;
                }
            }
        }

        public static List<int> GetList() { return mainList; }

        bool Check0Value(string _input) //Returns value 0 if lineInput is empty
        {
            if (_input == "")
            {
                TextMargin(-1);
                PrintText("0");
                return true;
            }
            else return false;
        }

        void ClearLine(int _tLength) //If lineInput is not valid, clears it
        {
            TextMargin(-1);
            for (int i = 0; i < _tLength; i++)
                Console.Write(' ');
        }
    }
}
