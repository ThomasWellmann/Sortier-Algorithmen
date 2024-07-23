namespace Sortier_Algorithmen
{
    internal class Lobby : Screen
    {
        public override Screen Start()
        {
            ResizeWindow();
            ClearConsole();
            Console.CursorVisible = false;
            PrintText($"Welcome to the Algorithm-Sorting-System!\n");
            GetWishedStartList();
            return new Algorithm();
        }

        void GetWishedStartList()
        {
            PrintText("To get started, first select a list of numbers:\n");
            PrintText("(1) Get random");
            PrintText("(2) Set own");
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

        Screen GetRandomStartList()
        {
            PrintText("(1) Choose the size of your random list (3 - 10 | you can add more later):");
            while (true)
            {
                var input = ReadLine();
                input = Check0Value(input) ? "0" : input;
                if (int.TryParse(input, out int listSize) && listSize >= 0 && listSize <= 10) //Max size = 10
                {
                    if (listSize < 3) //Min size = 3
                    {
                        PrintText($"\n   You chose {listSize},wich is too low, so it got changed to 3:");
                        listSize = 3;
                    }
                    else PrintText($"\n   You now have a list with {listSize} numbers:");

                    for (int i = 0; i < listSize; i++)
                        mainList.Add(rnd.Next(0, 100));
                    PrintList(mainList);
                    break;
                }
                ClearLine(input.Length);
            }
            return null;
        }

        List<int> GetInputStartList()
        {
            var inputList = new List<int>();
            int intsAdded = 0;
            PrintText($"(2) Press \"Enter\" to open the typing field.");
            PrintText($"Once you have at least 3 numbers, press \"ESC\" to finish this process.");
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
                            inputList.Add(toAdd);
                            PrintText($"You added {toAdd} to the list:");
                            PrintList(inputList);
                            PrintText($"Press \"Enter\" to add your next number.");
                            break;
                        }
                        ClearLine(input.Length);
                    }
                    intsAdded++;
                    if (intsAdded < 10) continue; //Max StartList size = 10
                    else break;
                }
                else if (key.Key == ConsoleKey.Escape) //Exit
                {
                    if (intsAdded < 3) continue; //Min StartList size = 3 
                    else break;
                }
            }
            return inputList;
        }

        bool Check0Value(string _input) //Returns value 0 if lineInput is empty
        {
            if (_input == "")
            {
                PrintText("0", -1);
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
