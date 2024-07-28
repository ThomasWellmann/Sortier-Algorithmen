namespace Sortier_Algorithmen
{
    internal class SortingAlgorithm
    {
        public List<int> list;
        public SortingAlgorithm(List<int> _list)
        {
            list = _list;
        }

        public void Increscent() //Bubble Sort
        {
            var swapped = false;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;

                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
            //list.Sort();
        }

        public void Decrescent()
        {
            var swapped = false;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j] < list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;

                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }

        public void ZigZag()
        {

        }

        public void Shuffle()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                int value = list[j];
                list[j] = list[i];
                list[i] = value;
            }
        }

        public void Add(int _toAdd, string _sortedAs)
        {
            list.Add(_toAdd);
            if (_sortedAs == "increscent") Increscent();
            else if (_sortedAs == "decrescent") Decrescent();
            else if (_sortedAs == "zig-zagging") ZigZag();
        }
    }
}
