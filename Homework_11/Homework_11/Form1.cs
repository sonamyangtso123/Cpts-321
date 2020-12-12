// <copyright file="Form1.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Homework_11
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    ///  In this class it build a new WinForms application that utilizes different aspects of
    /// threading and asynchronous methods.
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
        }

        private void URLDownLoadButton1_Click(object sender, EventArgs e)
        {
            // disable UI components.
            this.urlTextBox.Enabled = false;
            this.urlDownloadButton.Enabled = false;

            // instantaite an webClient class
            WebClient cleint = new WebClient();
            string resultData = string.Empty;

            // create a new thread to download
            Thread thread = new Thread(() =>
            {
                // get input from client
                resultData = cleint.DownloadString(this.urlTextBox.Text);

                // invoke action
                // source:https://stackoverflow.com/questions/7750519/methodinvoke-delegate-or-lambda-expression
                this.Invoke(new Action(() =>
                {
                   this.resultDataTextBox.Text = resultData;
                }));
            });

            // start a thread
            thread.Start();

            // re-enable the UI compoments
            this.urlTextBox.Enabled = true;
            this.urlDownloadButton.Enabled = true;
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            this.sortButton.Enabled = false;
            
            this.sortButton.Enabled = true;
            var arrayOfList = this.CreateRandomLists();
            Thread thread = new Thread(() => this.SortListsThread(arrayOfList));
            thread.Start();
            
        }

        private void SortEachList(List<int>list)
        {
            list.Sort();
        }
        
        private void SortArrayOfLists(List<int>[]arrayLists)
        {
            for(int i=0;i<arrayLists.Length; i++)
            {
                arrayLists[i].Sort();
            }
        }
        

        private void SortListsThread(List<int>[] lists)
        {
            List<int>[] arrayOfLists = this.CreateRandomLists();
            Stopwatch timer = new Stopwatch();
            
            Thread sortThread = new Thread(() => this.SortArrayOfLists(arrayOfLists));
            timer.Start();
            sortThread.Start();
            sortThread.Join();
            timer.Stop();

            long singleThreadElapsed = timer.ElapsedMilliseconds;

            timer.Reset();
            timer.Start();
            for(int i= 0;i<8;i++)

            {
                int temp = i;
                Thread thread = new Thread(() => SortEachList(arrayOfLists[temp]));
                

                thread.Start();
            }
            timer.Stop();
          
            //
            long multiThreadElapsed = timer.ElapsedMilliseconds;

            this.Invoke(new Action(() =>
                {
                    // stop the timer when done
                    // and calculate the elapsed time
                    if (this.sortOutPut.Text != null)
                    {
                        this.sortOutPut.Clear();
                    }

                    this.sortOutPut.Text += "single thread Time : " + singleThreadElapsed + " milliseconds" + Environment.NewLine;

                    this.sortOutPut.Text += "multi thread time: " + multiThreadElapsed + " milliseconds";
                }));
        }

        /// <summary>
        /// generate an 8 size array of random list.
        /// </summary>
        /// <returns>outer.</returns>
        private List<int>[] CreateRandomLists()
        {
            List<int>[] outer = new List<int>[8];
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                outer[i] = new List<int>();
                for (int j = 0; j < 1000000; j++)
                {
                    outer[i].Add(rand.Next());
                }
            }

            return outer;
        }
    }
}