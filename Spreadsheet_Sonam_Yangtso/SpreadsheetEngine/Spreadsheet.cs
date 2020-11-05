// <copyright file="Spreadsheet.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CptS321;

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
        // public event PropertyChangedEventHandler CellPropertyChanged = delegate { };
#pragma warning restore SA1130 // Use lambda syntax
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private Dictionary<string, int> location = new Dictionary<string, int>();


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
            this.NumberOfRows = rowCount;
            this.NumberOfColumns = columnCount;
            this.ArrayOfCells = new Cell[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    this.ArrayOfCells[i, j] = new SpreadsheetCell(i, j);

                    this.ArrayOfCells[i, j].PropertyChanged += this.CellPropertyChanged;
                }
            }
        }

        public int NumberOfRows
        {
            get;set;
           
        }

        public int NumberOfColumns
        {
            get;set;
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
        public void CellPropertyChanged(object sender, EventArgs e)
        {
            // Complete the implementation of the CellPropertyChanged event in the spreadsheet.

            // • The rules are if the text of the cell has just changed then the spreadsheet is responsible for updating the Value of the cell.
            SpreadsheetCell cell = sender as SpreadsheetCell;

            Console.WriteLine(cell.IndexName);

            // Console.WriteLine(e);

            PropertyChangedEventArgs E = e as PropertyChangedEventArgs;

            // If the value is changed in a cell than it must be updated in the spreadsheet. The rest of this function can be ignored in this case.
            if (E.PropertyName == "Value")
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(cell.RowIndex.ToString() + "," + cell.ColumnIndex.ToString() + "," + cell.Value)); // Send information to form to update dataviewgrid.
                return;
            }

            // • If the Text of the cell does NOT start with ‘=’ then the value is just set to the text.
            if (cell.Text[0] != '=')
            {
                cell.Value = cell.Text;
                this.PropertyChanged(cell, new PropertyChangedEventArgs("Text"));
            }
            else
            {
                // • Otherwise the value must be computed based on the formula that comes after the ‘=’.
                //   o Future versions (later homework assignments) will go much further with this but now we’ll only support one type of formula.
                //   o Support pulling the value from another cell. So if you see the text in the cell starting with ‘=’ then assume the remaining
                //     part is the name of the cell we need to copy a value from.
                //   o It’s not required for this assignment, but in the future we’ll need a way to deal with circular references (cell A gets value
                //     from B but B gets value from A), so keep that in mind.
                // cell.Value = this.GetTextFromSingleCell(cell.Text); // OLD CODE
                // Console.WriteLine("FIRST VALUES[2]: " + cell.Value); // OLD CODE
                cell.NewExpression(cell.Text.Substring(1));
                foreach (KeyValuePair<string, double> indexName in cell.varNames.ToList())
                {
                    Console.WriteLine(indexName.Key);
                    cell.SubExpTreeToCell(this.GetCellFromStringCoords(indexName.Key));
                }

                cell.Value = cell.ComputeExpression();
                this.PropertyChanged(this, new PropertyChangedEventArgs(cell.RowIndex.ToString() + "," + cell.ColumnIndex.ToString() + "," + cell.Value)); // Send information to form to update dataviewgrid.
            }
        }
        public string GetTextFromSingleCell(string cellName)
        {
            // cellName is the text of the cell which contains a string such as "A1" where "1" is the row of the cell to copy from
            // and "A" is the column of the cell to copy from. We look up "A" in the location dictionary to get its numerical column index.
            // return this.GetCell((cellName[2] - '0') - 1, this.location[cellName[1].ToString()]).Text; // a char - '0' = the int representation of the char.
            return this.GetCell(Convert.ToInt32(cellName[2].ToString()) - 1, this.location[cellName[1].ToString()]).Text;
        }

        // Returns a cell using its coordinates passed in as a string.
        public Cell GetCellFromStringCoords(string coords)
        {
            int col = this.location[coords[0].ToString()];
            int row = Convert.ToInt32(coords.Substring(1)) - 1;
            return this.GetCell(row, col);
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
        //private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    SpreadsheetCell cell = sender as SpreadsheetCell;
        //    if (e.PropertyName == "Text")
        //    {
        //        if (cell.Text[0] != '=')
        //        {
        //            cell.Value = cell.Text;
        //        }
        //        else
        //        {
        //            int rowIndex = int.Parse(cell.Text.Substring(2)) - 1;
        //            int columnIndex = (int)(cell.Text[1] - 065);
        //            cell.Value = this.GetCell(rowIndex, columnIndex).Value;
        //        }
        //    }

        //    // CellPropertyChanged(Cell, new PropertyChangedEventArgs("Text"));
        //    this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(e.PropertyName));
        //}

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


        public bool ChangeText(int row, int column, string newText)
        {
            /* Subscribe to cell property changed event */
            this.ArrayOfCells[row, column].PropertyChanged += this.CellPropertyChanged;

            if (this.ArrayOfCells[row, column] != null)
            {
                this.ArrayOfCells[row, column].Text = newText;
                this.GetChangedValue(this.ArrayOfCells[row, column]);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GetChangedValue(Cell targetCell)
        {
            /* Conversion Required */
            if (targetCell.Text != null && targetCell.Text[0] == '=')
            {
                int colNum = 0;
                int rowNum = 0;
                double value;
                /* Set value equal to another cell's value */
                ExpressionTree expTree = new ExpressionTree(targetCell.Text.TrimStart('='));

                List<string> variableList = expTree.GetVariableNames();

                /* Can assume that all variables will be cells in the form (A1, B2, etc.) for this Assignment */
                foreach (string var in variableList)
                {
                    colNum = var[0] - 65;       // convert ascii to index
                    rowNum = int.Parse(var[1].ToString()) - 1;

                    /* subscribe dependant cell's dependancychanged to needed cell's propertychanged */
                    //targetCell.UnsubscribeDependancy(ref this.ArrayOfCells[rowNum, colNum]);
                    //targetCell.SubscribeDependancy(ref this.ArrayOfCells[rowNum, colNum]);
                   // targetCell.DependancyChanged += new PropertyChangedEventHandler(this.SheetDependancyChangedHandler);

                    if (double.TryParse(this.ArrayOfCells[rowNum, colNum].Value, out value))
                    {
                        expTree.SetVariable(var, value);
                    }
                }

                targetCell.Value = expTree.Evaluate().ToString();
                Console.WriteLine(targetCell.Value);
            }
            else
            {
                targetCell.Value = targetCell.Text;
            }
        }

        private void SheetDependancyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            this.GetChangedValue((Cell)sender);
        }


    }
}
