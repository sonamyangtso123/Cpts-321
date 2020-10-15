// <copyright file="Form1.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Spreadsheet_Sonam_Yangtso
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
        private Spreadsheet sheet;

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
            for (int column = 065; column <= 090; column++)
            {
                char character = (char)column;
                this.dataGridView1.Columns.Add(character.ToString(), character.ToString());
            }

            for (int row = 1; row <= 50; row++)
            {
                this.dataGridView1.Rows.Add(row);
                this.dataGridView1.Rows[row - 1].HeaderCell.Value = row.ToString();
            }

            // subscribe to the property changed event
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

        /// <summary>
        /// this is demo method.
        /// </summary>
        /// <param name="sender"> Cell.</param>
        /// <param name="e"> changed in the value.</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                int randRow = rand.Next(50);
                int randColumn = rand.Next(26);
                this.sheet.GetCell(randRow, randColumn).Text = "Cpts321";
            }

            for (int j = 0; j < 50; j++)
            {
                this.sheet.GetCell(j, 1).Text = "This.is cell B" + (j + 1).ToString();
                this.sheet.GetCell(j, 0).Text = "=B" + (j + 1).ToString();
            }
        }
    }
}
