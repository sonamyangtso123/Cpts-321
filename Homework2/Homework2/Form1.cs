// <copyright file="Form1.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Homework2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// this is second main class. This class will use methods from Finder class.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // declearing an Ramdom number generator.
            Random rand = new Random();

            // define a stringbuilder
            StringBuilder stringOutput = new StringBuilder();

            // Declearing am array of 10000 integrs
            int arrayLength = 10000;
            int[] list = new int[arrayLength];

            // Generate and save 10000 random integers between 0 and 20000
            for (int i = 0; i < arrayLength; i++)
            {
                list[i] = rand.Next(20001);
            }

            // call methods from Finder class to find the distinct integer counts by three different ways.
            int hashDistinctInteger = Finder.CountDistinctIntegersUsingHash(list);
            int storageDistinctInteger = Finder.CountDistinctIntegerByStorage(list);
            int sortDistinctInteger = Finder.CountDistinctIntegerBySort(list);

            // save all the sring into stringbuilder
            stringOutput.Append("1. HashSet method:" + hashDistinctInteger + " unique numbers\r\n" +
             "  The time complexity for counting the unique integers in this method is  O(1).\r\n" +
             "  Adding the integers into hashset takes O(n) time and counting unique integer takes O(1).\r\n");
            stringOutput.Append("2. O(1) storage method: " + storageDistinctInteger + "Unique number \r\n");
            stringOutput.Append("3. Sorted method: " + sortDistinctInteger + " unique number \r\n");

            // display the string output on testbox
            this.textBox1.Text = stringOutput.ToString();
        }
    }
}
