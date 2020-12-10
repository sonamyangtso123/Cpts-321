using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_11
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

        private void URLDownLoadButton1_Click(object sender, EventArgs e)
        {
            //disable UI components 
            urlTextBox.Enabled = false;
            resultDataTextBox.Enabled = false;
            urlDownloadButton.Enabled = false;
            // create an array of type byte to save the data from a resource
            //byte[] data;
            // instantaite an webClient class
            WebClient cleint = new WebClient();
            string resultData = string.Empty;

            // create a new thread to download
            Thread thread = new Thread(() =>
            {
                resultData = cleint.DownloadString(urlTextBox.Text);
                this.Invoke(new Action(() =>
                {
                    resultDataTextBox.Text = resultData;
                }));
            });
            // start a thread
            thread.Start();
            // re-enable the UI compoments

            urlTextBox.Enabled = true;
            resultDataTextBox.Enabled = true;
            urlDownloadButton.Enabled = true;



        }


    }
}
