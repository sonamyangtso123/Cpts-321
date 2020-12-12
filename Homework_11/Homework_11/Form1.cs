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
            sortButton.Enabled = false;
            //// instantiate a stopwatch for timing

            var arrayOfList = CreateRandomLists();
            Thread thread = new Thread(() => SortListsThread(arrayOfList));
            thread.Start();
            sortButton.Enabled = true;

        }

        /// <summary>
        /// generate an 8 size array of random list
        /// </summary>
        /// <returns></returns>
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

        private void SortListsThread(List<int>[] lists)
        {
            List<int>[] arrayOfLists = CreateRandomLists();
            Stopwatch timer1 = new Stopwatch();
            timer1.Start();
            Thread singleThread = new Thread(() =>
            {
                for (int i = 0; i < 8; i++)
                {
                    arrayOfLists[i].Sort();
                }
            });
            singleThread.Start();
            singleThread.Join();
            timer1.Stop();
            //long SingleThreadElapsedTime = timer1.ElapsedMilliseconds;

            arrayOfLists = CreateRandomLists();
            Stopwatch timer2 = new Stopwatch();
            timer2.Start();
            Thread[] eightThreads = new Thread[8];

            for (var j = 0; j < 8; j++)
            {
                // prevent the threads from accessing the same j variable
                var temp = j;

                eightThreads[temp] = new Thread(() =>
                {
                    // give each thread a list to sort
                    arrayOfLists[temp].Sort();
                });
            }

            // start the timer

            // start each thread
            for (var k = 0; k < 8; k++)
            {
                eightThreads[k].Start();
            }

            foreach (var thread in eightThreads)
            {
                thread.Join();
            }

            timer2.Stop();
            //BeginInvoke(new Action(SortingCompleted));
            string singelThreadElapsed = timer1.ElapsedMilliseconds.ToString();
            string multiThreadElapsed = timer2.ElapsedMilliseconds.ToString();

            this.Invoke(new Action(() =>
                {
                    // stop the timer when done
                    // and calculate the elapsed time
                    if(sortOutPut.Text!=null)
                    {
                        sortOutPut.Clear();
                    }
                    sortOutPut.Text += "single thread Time : " + singelThreadElapsed + " milliseconds" + Environment.NewLine;
                    
                    sortOutPut.Text += "multi thread time: " + multiThreadElapsed + " milliseconds" ;

                }));

        }

    }
}

