// <copyright file="Spreadsheet.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cpt321;

    /// <summary>
    /// This is a spreadsheet class.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// ArrayOfCells is a 2D array of type Cell.
        /// </summary>
        public Cell[,] ArrayOfCells;
        private int numberOfRows;
        private int numberOfColumns;

        /// <summary>
        /// Initailize am  a property changed event handler to empty.
        /// </summary>
#pragma warning disable SA1130 // Use lambda syntax
        public event PropertyChangedEventHandler CellPropertyChanged = delegate { };
#pragma warning restore SA1130 // Use lambda syntax

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.It creates an array of 2D
        /// rows and columns .
        /// </summary>
        /// <param name="rowCount"> Takes number of rows in order to initalize in the 2d array.
        /// </param>
        /// <param name="columnCount"> Takes numbers of columns in order to initalize in the 2d array.
        /// </param>
        public Spreadsheet(int rowCount, int columnCount)
        {
            this.numberOfRows = rowCount;
            this.numberOfColumns = columnCount;
            this.ArrayOfCells = new Cell[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    this.ArrayOfCells[i, j] = new SpreadsheetCell(i, j);

                    this.ArrayOfCells[i, j].PropertyChanged += this.OnPropertyChanged;
                }
            }
        }

        /// <summary>
        /// GetCell method will return the given specific row and column cell.
        /// </summary>
        /// <param name="row">given row index.</param>
        /// <param name="column"> given column index.</param>
        /// <returns>return the given row and coulmn index cell.</returns
        public Cell GetCell(int row, int column)
        {
            if (this.ArrayOfCells[row, column] == null)
            {
                return null;
            }

            return this.ArrayOfCells[row, column];
        }

        /// <summary>
        /// Function to keep track of property changes.
        /// </summary>
        /// <param name="sender">
        /// sender contains a reference to the control/object that raised the event.
        /// </param>
        /// <param name="e">
        ///  e containts the event data.
        /// </param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SpreadsheetCell cell = sender as SpreadsheetCell;
            if (e.PropertyName == "Text")
            {
                if (cell.Text[0] != '=')
                {
                    cell.Value = cell.Text;
                }
                else
                {
                    int rowIndex = int.Parse(cell.Text.Substring(2)) - 1;
                    int columnIndex = (int)(cell.Text[1] - 065);
                    cell.Value = this.GetCell(rowIndex, columnIndex).Value;
                }
            }

              // CellPropertyChanged(Cell, new PropertyChangedEventArgs("Text"));
            this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(e.PropertyName));
        }

        /// <summary>
        /// Gets method for RowCount, It will return the number of rows.
        /// </summary>
        public int RowCount
        {
            get { return this.numberOfRows; }
        }

        /// <summary>
        /// Gets method for CoulumnCount. It will return the number of columns in a given Spreadsheet.
        /// </summary>
        public int ColumnCount
        {
            get { return this.numberOfColumns; }
        }
    }
}
