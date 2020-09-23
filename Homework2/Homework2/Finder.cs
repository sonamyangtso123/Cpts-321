using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
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
            
            return uniqueCount;
        }

        public static int CountDistinctIntegerBySort(int[] array)
        {
            return 0;
        }
    }
}
