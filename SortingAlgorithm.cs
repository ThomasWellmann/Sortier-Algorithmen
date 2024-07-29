using System.Net.Sockets;

namespace Sortier_Algorithmen
{
    internal class SortingAlgorithm
    {
        public List<int> list = new List<int>();
        List<int> sorted = new List<int>();
        Random rnd = new Random(DateTime.Now.Millisecond);

        public SortingAlgorithm(List<int> _list)
        {
            list = _list;
        }

        public void Sort(int _sortAlgorithm = 2)
        {
            if (_sortAlgorithm != 0) //Bubble Sort
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
            }
            else if (_sortAlgorithm == 2)
            {
                //...
            }
            else if (_sortAlgorithm == 3)
            {
                //...
            }
            //sorted = list;
        }

        public void Increscent()
        {
            //list = sorted;
            Sort();
        }

        public void Decrescent()
        {
            Sort();
            for (int i = 0; i < list.Count / 2; i++)
            {
                int n = list.Count - 1 - i;
                int temp = list[i];
                list[i] = list[n];
                list[n] = temp;
            }
        }

        public void ZigZag()
        {
            list = sorted;
            //...
        }

        public void Shuffle()
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int n = rnd.Next(i + 1);
                int temp = list[n];
                list[n] = list[i];
                list[i] = temp;
            }
        }

        public void Add(int _toAdd, string _shownAs)
        {
            list.Add(_toAdd); 
            Sort();
            if (_shownAs == "increscent") Increscent();
            else if (_shownAs == "decrescent") Decrescent();
            else if (_shownAs == "zig-zag") ZigZag();
        }
    }
}
