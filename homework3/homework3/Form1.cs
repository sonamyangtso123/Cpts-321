﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace homework3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {


        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void LoadText(TextReader sr)
        {
            string word = "";
            string line;
            while((line = sr.ReadLine()) != null)
            {
                word += line;
            }
            this.textBox1.Text = word;
        }
    }
}

