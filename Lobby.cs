namespace Sortier_Algorithmen
{
    internal class Lobby : Screen
    {
        public override Screen Start()
        {
            GetStarted();

            Print("Press ", "Enter", " to continue or ", "ESC", " restart the program.");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Escape) return new Lobby();
                else if (key.Key == ConsoleKey.Enter) return new Sorting();
            }
        }

        void GetStarted()
        {
            mainList = new List<int>();
            ResizeWindow();
            SetDefaultColors();
            ClearConsole();
            Console.CursorVisible = false;

            Print($"Welcome to the Algorithm-Sorting-System!\n");
            GetWishedStartingList();
        }

        void GetWishedStartingList()
        {
            Print("To get started, first select a list of numbers:\n");
            Print("(", "1", ") Get random");
            Print("(", "2", ") Set own");
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
            Print("(1) Choose the size of your random list (3 - 75):");
            while (true)
            {
                var input = ReadLine();
                input = Check0Value(input) ? "0" : input;
                if (int.TryParse(input, out int listSize) && listSize >= 0)
                {
                    if (listSize < 3) //Min size = 3
                    {
                        Print($"\n   You chose {listSize}, wich is too low, so it got changed to 3:");
                        listSize = 3;
                    }
                    else if (listSize > 75) //Max size = 75
                    {
                        Print($"\n   You chose {listSize}, wich is too high, so it got changed to 75:");
                        listSize = 75;
                    }
                    else Print($"\n   You now have a list with {listSize} numbers:");

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
            Print($"(2) Press ", "Enter", " to open the typing field.");
            Print($"Once you have at least 3 numbers, press ", "ESC", " to finish this process.");
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
                            Print($"{intsAdded}: You added {toAdd} to the list:");
                            PrintList(mainList);
                            break;
                        }
                        ClearLine(input.Length);
                    }
                    if (intsAdded < 75) //Max StartList size = 75
                    {
                        Print($"Press ", "Enter", " to add your next number.");
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
                Print("0");
                return true;
            }
            else return false;
        }

    }
}
