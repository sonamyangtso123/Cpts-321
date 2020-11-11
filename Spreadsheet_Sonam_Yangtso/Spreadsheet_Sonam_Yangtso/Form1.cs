// <copyright file="Form1.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
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
    using CptS321;

    /// <summary>
    /// This is another main class.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly Spreadsheet sheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Initialze a spreadsheet oject in form's constructor with 50 rows and 26 colums.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();

            // Initialize a Spreadsheet object with 50rows and 26 columns.
            this.sheet = new Spreadsheet(50, 26);
        }
        
        /// <summary>
        /// This methods created a Spreadsheet with 50 rows and 26 columns.
        /// Subscribe to the spreadsheet's CellPropertyChangedEvent.
        /// </summary>
        /// <param name="sender"> parameter.</param>
        /// <param name="e"> paramet.</param>
        private void Form1_Load(object sender, EventArgs e)
        {


            for (int column = 65; column < 91; column++)
            {
                char character = (char)column;
                this.dataGridView1.Columns.Add(character.ToString(), character.ToString());
            }

            for (int row = 1; row <= 50; row++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[row - 1].HeaderCell.Value = row.ToString();
            }
            this.sheet.CellPropertyChanged += this.OnCellPropertyChanged;

        }
        /// <summary>
        /// This method implements when a cell's Value changes it gets updates in the DataGridView.
        /// </summary>
        /// <param name="sender"> for the cell.</param>
        /// <param name="e">for thecell. </param>
        private void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SpreadsheetCell updateCell = sender as SpreadsheetCell;

            if (e.PropertyName == "Value")
            {
                // Modify the value in the ColumnIndex cell of the RowIndex row.
                this.dataGridView1.Rows[updateCell.RowIndex].Cells[updateCell.ColumnIndex].Value = updateCell.Value;
            }


        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // get the Text property of the cell and save it into msg.
            // msg is the value that we want to the datagrid cell.
            string msg = this.sheet.GetCell(e.RowIndex, e.ColumnIndex).Text;

            if (msg.Length > 0 && msg[0] == '=')
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = msg;
            }


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.sheet.CellTextChanged(e.RowIndex, e.ColumnIndex, (string)this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

        }

        
    }
}
