namespace Homework2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Finder
    {
        public static int CountDistinctIntegersUsingHash(int[] array)
        {
            HashSet<int> myHash = new HashSet<int>();
            foreach (int number in array)
            {
                myHash.Add(number);
            }

            return myHash.Count();
        }

        public static int CountDistinctIntegerByStorage(int[] array)
        {
            int uniqueCount = 0;
            int j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (j = i + 1; j < array.Length; j++)
                {
                    if (array[j] == array[i])
                    {
                        break;
                    }
                }

                if (j == array.Length)
                {
                    uniqueCount++;
                }
            }

            return uniqueCount;
        }

        public static int CountDistinctIntegerBySort(int[] array)
        {
            Array.Sort(array);
            int uniqueCount = 0;
            int i = 0;
            for (i = 0; i < array.Length - 1; i++)
            {
                if (array[i] != array[i + 1])
                {
                    uniqueCount++;
                }
            }

            if (array.Length > 0)
            {
                uniqueCount++;
            }

            return uniqueCount;
        }
    }
}
