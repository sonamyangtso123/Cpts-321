// <copyright file="Form1.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// This is another main class.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly Spreadsheet sheet;
        private readonly Invoker commandManager = new Invoker();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Initialze a spreadsheet oject in form's constructor with 50 rows and 26 colums.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();

            // Initialize a Spreadsheet object with 50rows and 26 columns.
            this.sheet = new Spreadsheet(50, 26);
            this.UndoRedoAvailable();
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
        /// This method implements when a cell's Value changes.
        /// it gets updates in the DataGridView.
        /// Event Handler.
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
            else if (e.PropertyName == "Color")
            {
                this.dataGridView1.Rows[updateCell.RowIndex].Cells[updateCell.ColumnIndex].Style.BackColor = Color.FromArgb((int)updateCell.BGColor);
            }
        }

        /// <summary>
        /// Event to handle editing in a cell on the grid.
        /// </summary>
        /// <param name="sender">
        /// Object sender.
        /// </param>
        /// <param name="e">
        /// Event handler to handle editing.
        /// </param>
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // get the Text property of the cell and save it into msg.
            // msg is the value that we want to the datagrid cell.
            string msg = this.sheet.GetCell(e.RowIndex, e.ColumnIndex).Text;

            if (msg.Length > 0 && msg[0] == '=')
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = msg;
            }
        }

        /// <summary>
        /// This event handler fr any chenges in cell text.
        /// </summary>
        /// <param name="sender">object sender.</param>
        /// <param name="e"> event handler.</param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // this.sheet.GetCell(e.RowIndex, e.ColumnIndex).Text = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            this.sheet.CellTextChanged(e.RowIndex, e.ColumnIndex, (string)this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            ICommand cmd = new ChangeText(this.sheet.GetCell(e.RowIndex, e.ColumnIndex), this.sheet.GetCell(e.RowIndex, e.ColumnIndex).Value, (string)this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            this.commandManager.AddUndo(cmd);
            this.UndoRedoAvailable();
        }

        /// <summary>
        /// event handler for back ground color change in the cell.
        /// </summary>
        /// <param name="sender">object sender.</param>
        /// <param name="e"> e.</param>
        private void ChangeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Cell> cells = new List<Cell>();
            List<uint> oldColors = new List<uint>();

            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
                {
                    cells.Add(this.sheet.GetCell(cell.RowIndex, cell.ColumnIndex));
                    oldColors.Add(this.sheet.GetCell(cell.RowIndex, cell.ColumnIndex).BGColor);
                    this.sheet.GetCell(cell.RowIndex, cell.ColumnIndex).BGColor = (uint)this.colorDialog1.Color.ToArgb();
                }

                ICommand cmd = new ChangeColor(cells, oldColors, (uint)this.colorDialog1.Color.ToArgb());
                this.commandManager.AddUndo(cmd);
                this.UndoRedoAvailable();
            }
        }

    /// <summary>
    /// This method checks there is any undo or redo available on the cell grid.
    /// </summary>
        private void UndoRedoAvailable()
        {
            if (this.commandManager.UndoAvailable() == false)
            {
                this.undoToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.undoToolStripMenuItem.Enabled = true;
            }

            if (this.commandManager.RedoAvailable() == false)
            {
                this.redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.redoToolStripMenuItem.Enabled = true;
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.commandManager.UndoCommand();
            this.UndoRedoAvailable();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.commandManager.RedoCommand();
            this.UndoRedoAvailable();
        }

        /// <summary>
        /// Save button will execute the save method in the spreadsheet cell.
        /// </summary>
        /// <param name="sender"> sender.</param>
        /// <param name="e">e .</param>
        private void SaveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Only allow to save XML files.
            this.saveFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            this.saveFileDialog1.FilterIndex = 0;
            this.saveFileDialog1.Title = "Save an XML File";
            this.saveFileDialog1.DefaultExt = "xml";

            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fileStream = (System.IO.FileStream)this.saveFileDialog1.OpenFile();
                this.sheet.Save(fileStream);
                fileStream.Close();
            }
        }

        /// <summary>
        /// this Load button will execute the load method from spreadsheet class.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">e.</param>
        private void LoadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Only open xml files.
            this.openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            this.openFileDialog1.FilterIndex = 0;
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.Title = "Open an XML File";

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fileStream = (System.IO.FileStream)this.openFileDialog1.OpenFile();

                this.commandManager.ClearUndoStack();
                this.commandManager.ClearRedoStack();
                this.sheet.Load(fileStream);

                fileStream.Close();
            }
        }
    }
}
