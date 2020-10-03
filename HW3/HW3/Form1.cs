// Sonam Yangtso
// <copyright file="FibonacciTextReader.cs" company="wsu">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
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

        /// <summary>
        /// This is a event for prompting user for a file name save a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// this event read all the text from the TextReader and
        /// and put it in the text box
        /// </summary>
        /// <param name="sr"></param>
        private void LoadText(TextReader sr)
        {
            string word = string.Empty;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                word += line;
            }

            this.textBox1.Text = word;
        }

        /// <summary>
        /// this is an event to load text from file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            StreamReader readFile;
            if (result == DialogResult.OK)
            {
                using (readFile = File.OpenText(openFileDialog1.FileName))
                {
                    this.LoadText(readFile);
                }
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// this is an event to load first 50fibonacci numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFirst50FibanacciNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fibReader = new FibonacciTextReader(50);

            string index = "maxValue\t|   Fibonacci Values\r\n********\t|    ************************\r\n";
            for (int i = 1; i <= 50; i++)
            {
                index += i.ToString() + "\t|    " + fibReader.ReadLine() + "\r\n";
            }

            this.textBox1.Text = index;
        }

        /// <summary>
        /// This is event to load first 100 fibonacci series
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fibReader = new FibonacciTextReader(100);
            string index = "maxValue\t|   Fibonacci Values\r\n********\t|    ************************\r\n";
            for (int i = 1; i <= 100; i++)
            {
                index += i.ToString() + "\t|    " + fibReader.ReadLine() + "\r\n";
            }

            this.textBox1.Text = index;
        }
    }
}
