namespace Sortier_Algorithmen
{
    internal class Algorithm : Screen
    {
        List<int> mainList;

        public override Screen Start()
        {
            mainList = Lobby.GetList();

            ClearConsole();
            Print("Your List:");
            PrintList(mainList);
            GetTextSpacements();

            GetWishedSortingAlgorithm();

            Loop();

            return new Lobby();
        }

        void GetWishedSortingAlgorithm()
        {
            Print("You can now sort your list in 3 different ways:");
            Print("(", "1", ") Increasing");
            Print("(", "2", ") Decreasing");
            Print("(", "3", ") Zig-Zag");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    Increasing();
                }
                else if(key.Key == ConsoleKey.D2)
                {
                    Decreasing();
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    ZigZag();
                }
            }
        }

        void Increasing()
        {

        }

        void Decreasing()
        {

        }

        void ZigZag()
        {

        }
    }
}
