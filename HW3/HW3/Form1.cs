using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HW3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            DialogResult result = saveFileDialog1.ShowDialog();
            StreamWriter fileStream;
            if (result == DialogResult.OK)
            {
                fileStream = new StreamWriter(saveFileDialog1.FileName);
                fileStream.WriteLine(this.textBox1.Text);
                fileStream.Close();
            }

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void  LoadText (TextReader sr)
        {
            string word = "";
            string line;
            while((line = sr.ReadLine()) !=null)
            {
                word += line;
            }
            this.textBox1.Text = word;
        }

        private void loadFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            StreamReader readFile;
            if (result == DialogResult.OK)
            {
                using (readFile = File.OpenText(openFileDialog1.FileName))
                {
                    LoadText(readFile);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadFirst50FibanacciNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fibReader = new FibonacciTextReader(50);


            string index = "maxValue\t|   Fibonacci Values\r\n********\t|    ************************\r\n";
            for (int i = 1; i <= 50; i++)
            {
                index += i.ToString() + "\t|    " + fibReader.ReadLine() + "\r\n";
            }
            textBox1.Text = index;
        }

        private void loadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fibReader = new FibonacciTextReader(100);
            string index = "maxValue\t|   Fibonacci Values\r\n********\t|    ************************\r\n";
            for (int i = 1; i <= 100; i++)
            {
                index += i.ToString() + "\t|    " + fibReader.ReadLine() + "\r\n";
            }
            textBox1.Text = index;
        }
    }
}
