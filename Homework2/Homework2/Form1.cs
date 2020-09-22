using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Random rand = new Random();

            // Declearing am array of 10000 integrs 
            int arrayLength = 10000;
            int[] list = new int[arrayLength];

            // Generate and save 10000 random integers between 0 and 20000
            for (int i = 0; i < arrayLength; i++)
            {
                list[i] = rand.Next(20001);
            }
        }
    }
}
