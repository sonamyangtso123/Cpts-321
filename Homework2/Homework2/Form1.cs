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

    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            StringBuilder stringOutput = new StringBuilder();

            // Declearing am array of 10000 integrs
            int arrayLength = 10000;
            int[] list = new int[arrayLength];

            // Generate and save 10000 random integers between 0 and 20000
            for (int i = 0; i < arrayLength; i++)
            {
                list[i] = rand.Next(20001);
            }

            int hashDistinctInteger = Finder.CountDistinctIntegersUsingHash(list);
            int storageDistinctInteger = Finder.CountDistinctIntegerByStorage(list);
            int sortDistinctInteger = Finder.CountDistinctIntegerBySort(list);

            stringOutput.Append("1. HashSet method:" + hashDistinctInteger + " unique numbers\r\n" +
             "  The time complexity for counting the unique integers in this method is  O(1).\r\n" +
             "  Adding the integers into hashset takes O(n) time and counting unique integer takes O(1).\r\n");
            stringOutput.Append("2. O(1) storage method: " + storageDistinctInteger + "Unique number \r\n");
            stringOutput.Append("3. Sorted method: " + sortDistinctInteger + " unique number \r\n");

            this.textBox1.Text = stringOutput.ToString();
        }
    }
}
