namespace Sortier_Algorithmen
{
    internal class Algorithm : Screen
    {
        public override Screen Start()
        {
            ClearConsole();
            PrintText("Your List:");
            PrintList(mainList);
            Loop();
            return new Lobby();
        }
    }
}
