namespace Sortier_Algorithmen
{
    internal abstract class Screen
    {
        protected readonly static int textMargin = 3;
        readonly static ConsoleColor defaultFColor = ConsoleColor.White;
        readonly static ConsoleColor defaultBColor = ConsoleColor.DarkBlue;
        readonly static ConsoleColor keyFColor = ConsoleColor.Green;
        readonly static ConsoleColor KeyBColor = ConsoleColor.Magenta;
        protected Random rnd = new(DateTime.Now.Millisecond);

        public abstract Screen Start();

        protected static void ResizeWindow(int _width = 0, int _height = 0)
        {
            if (_width == 0 && _height == 0)
            {
                _width = Console.LargestWindowWidth;
                _height = Console.LargestWindowHeight;
            }
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(_width, _height);
            Console.SetBufferSize(_width, 1000);
        }

        protected static void SetDefaultColors()
        {
            Console.ForegroundColor = defaultFColor;
            Console.BackgroundColor = defaultBColor;
        }

        protected static void SetKeyColors()
        {
            Console.ForegroundColor = keyFColor;
            Console.BackgroundColor = KeyBColor;
        }

        protected static string PrintList(List<int> _list, bool _print = true)
        {
            string list = "[ ";
            for (int i = 0; i < _list.Count; i++)
            {
                list += _list[i];
                list += (i != _list.Count - 1) ? " | " : "";
            }
            list += " ]";
            if (_print)
            {
                PrintText($"{list}\n");
                return null;
            }
            else return list;
        }

        protected static ConsoleKeyInfo ReadKey(bool _intercept = false)
        {
            TextMargin();
            Console.CursorVisible = !_intercept;
            var keyInput = Console.ReadKey(_intercept);
            Console.CursorVisible = false;
            return keyInput;
        }

        protected static string ReadLine()
        {
            TextMargin();
            Console.CursorVisible = true;
            var lineInput = Console.ReadLine();
            Console.CursorVisible = false;
            return lineInput;
        }

        protected static void TextMargin(int _offset = 0)
        {
            Console.SetCursorPosition(textMargin, Console.GetCursorPosition().Top + _offset);
        }

        protected static void PrintText(string _text1, string _key1 = "", string _text2 = "", string _key2 = "", string _text3 = "") //WriteLine with sidespace
        {
            TextMargin();
            Console.Write((_key1 == "") ? $"{_text1}\n" : _text1);
            if (_key1 != "")
            {
                SetKeyColors();
                Console.Write(_key1);
                SetDefaultColors();
                Console.Write((_key2 == "") ? $"{_text2}\n" : _text2);
            }
            if (_key2 != "")
            {
                SetKeyColors();
                Console.Write(_key2);
                SetDefaultColors();
                Console.Write($"{_text3}\n");
            }
        }

        protected static void ClearConsole()
        {
            Console.Clear();
            Console.WriteLine();
        }

        protected static void GetTextSpacements()
        {
            Console.WriteLine();

            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write('-');

            Console.WriteLine("\n");
        }

        protected static void Loop()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
