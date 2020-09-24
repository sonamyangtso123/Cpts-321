// <copyright file="Finder.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Homework2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is a Finder class. It has three different methods of
    /// finding unique integers in an array.
    /// </summary>
    public class Finder
    {
        /// <summary>
        /// This method use hashset data structure to count the
        /// nuber of distinct integers in a given array.
        /// </summary>
        /// <param name="array">arry.</param>
        /// <returns> number of distinct integers. </returns>
        public static int CountDistinctIntegersUsingHash(int[] array)
        {
            // initailize a new hashset
            HashSet<int> myHash = new HashSet<int>();

            // iterate through each elements in array
            foreach (int number in array)
            {
                // add to hashset
                myHash.Add(number);
            }

             // return the number of elements in the hashset myhash.
            return myHash.Count();
        }

        /// <summary>
        /// This method counts number of distinct integers in an array
        /// with O(1) space complexity.
        /// </summary>
        /// <param name="array">array.</param>
        /// <returns>Number of distinct integers.</returns>
        public static int CountDistinctIntegerByStorage(int[] array)
        {
            // counter for distinct numbers
            int uniqueCount = 0;

            // iterate through an array from index 0
            for (int i = 0; i < array.Length; i++)
            {
                // iterate through an array from index 1
                int j;
                for (j = i + 1; j < array.Length; j++)
                {
                    // compare an element at index[i+1] with index[i], if there are same, exit the inner loop
                    // and update the outer loop. If there are not same update the inner loop.
                    if (array[j] == array[i])
                    {
                        break;
                    }
                }

                // when there is no same integers in the array and j get equal to array length upadta the distict
                // integer counter.
                if (j == array.Length)
                {
                    uniqueCount++;
                }
            }

            // return the number of distinct numbers in an array
            return uniqueCount;
        }

        /// <summary>
        /// This method counts number of distinct integers in an array
        /// by using bulid in sort method with O(1) space complexity.
        /// </summary>
        /// <param name="array"> array.</param>
        /// <returns> number of distinct integers.</returns>
        public static int CountDistinctIntegerBySort(int[] array)
        {
            // sort the given array using build in mehtod Sort
            Array.Sort(array);
            int uniqueCount = 0;
            int i;
            for (i = 0; i < array.Length - 1; i++)
            {
                // compare the adjacent elements in an array, if they are not same
                if (array[i] != array[i + 1])
                { // update the unique coun counter
                    uniqueCount++;
                }
            }

            // make a count for last element
            if (array.Length > 0)
            {
                uniqueCount++;
            }

            return uniqueCount;
        }
    }
}
