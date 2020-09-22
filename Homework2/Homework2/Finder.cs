using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class Finder
    {
        public static int CountDistinctIntegers(int[] array)
        {
            HashSet<int> myHash = new HashSet<int>();
            //foreach (int number in array)
            //{
            //    myHash.Add(number);
            //}
            return myHash.Count();
        }
    }
}
