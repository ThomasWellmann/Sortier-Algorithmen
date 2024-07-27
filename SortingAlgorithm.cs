namespace Sortier_Algorithmen
{
    internal class SortingAlgorithm
    {
        List<int> list;
        public SortingAlgorithm(List<int> _list)
        {
            list = _list;
        }

        public List<int> Increasing() //Bubble Sort
        {
            var swapped = false;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for(int j = 0; j < list.Count - 1 - i; j++)
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
            return list;
        }

        public List<int> Decreasing()
        {
            var sortedList = list;
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
            return list;
        }

        public List<int> ZigZag()
        {
            return null;
        }
    }
}
