namespace Sortier_Algorithmen
{
    internal abstract class Screen
    {
        readonly int textMargin = 3;
        protected List<int> mainList = new List<int>(); 
        protected Random rnd = new(DateTime.Now.Millisecond);

        public abstract Screen Start();

        protected void ResizeWindow(int _width = 100, int _height = 50)
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(_width, _height);
            Console.SetBufferSize(_width, 1000);
        }

        protected void PrintList(List<int> _list)
        {
            TextMargin();
            Console.Write("[ ");
            for (int i = 0; i < _list.Count; i++)
            {
                Console.Write(_list[i]);
                if (i != _list.Count - 1) Console.Write(" | ");
            }
            Console.Write(" ]\n");
        }

        protected ConsoleKeyInfo ReadKey(bool _intercept = false)
        {
            TextMargin();
            Console.CursorVisible = !_intercept;
            var keyInput = Console.ReadKey(_intercept);
            Console.CursorVisible = false;
            return keyInput;
        }

        protected string ReadLine()
        {
            TextMargin();
            Console.CursorVisible = true;
            var lineInput = Console.ReadLine();
            Console.CursorVisible = false;
            return lineInput;
        }

        protected void TextMargin(int _offset = 0)
        {
            Console.SetCursorPosition(textMargin, Console.GetCursorPosition().Top + _offset);
        }
        protected void PrintText(string _text, int _offSet = 0) //WriteLine with sidespace
        {
            TextMargin(_offSet);
            Console.WriteLine(_text);
        }

        protected void ClearConsole()
        {
            Console.Clear();
            Console.WriteLine();
        }

        protected void GetTextSpacements()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        protected void Loop()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
