
namespace Homework_11
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.urlDownloadButton = new System.Windows.Forms.Button();
            this.resultDataTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(420, 34);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(317, 26);
            this.urlTextBox.TabIndex = 0;
            // 
            // urlDownloadButton
            // 
            this.urlDownloadButton.Location = new System.Drawing.Point(420, 84);
            this.urlDownloadButton.Name = "urlDownloadButton";
            this.urlDownloadButton.Size = new System.Drawing.Size(309, 36);
            this.urlDownloadButton.TabIndex = 1;
            this.urlDownloadButton.Text = "\"Download string from URL\"";
            this.urlDownloadButton.UseVisualStyleBackColor = true;
            this.urlDownloadButton.Click += new System.EventHandler(this.URLDownLoadButton1_Click);
            // 
            // resultDataTextBox
            // 
            this.resultDataTextBox.Location = new System.Drawing.Point(408, 149);
            this.resultDataTextBox.Multiline = true;
            this.resultDataTextBox.Name = "resultDataTextBox";
            this.resultDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultDataTextBox.Size = new System.Drawing.Size(321, 318);
            this.resultDataTextBox.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(429, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(42, 20);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(416, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Download result (as string)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 557);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.resultDataTextBox);
            this.Controls.Add(this.urlDownloadButton);
            this.Controls.Add(this.urlTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button urlDownloadButton;
        private System.Windows.Forms.TextBox resultDataTextBox;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label2;
    }
}

