namespace Sortier_Algorithmen
{
    internal class Algorithm : Screen
    {
        List<int> mainList;

        public override Screen Start()
        {
            mainList = Lobby.GetList();

            ClearConsole();
            PrintText("Your List:");
            PrintList(mainList);
            Loop();

            return new Lobby();
        }
    }
}
