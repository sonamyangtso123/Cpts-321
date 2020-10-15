// <copyright file="SpreadsheetCell.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using CptS321;

namespace CptS321
{
    /// <summary>
    /// This is a SpreadsheetCell class. It is a subclass of abstract class Cell.
    /// We used this class for Cell class instaniation.
    /// </summary>
    public class SpreadsheetCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        /// <param name="rowIndex">it is a row number of the cell. </param>
        /// <param name="columnIndex">It is a column number of the cell.</param>
        public SpreadsheetCell(int rowIndex, int columnIndex)
            : base(rowIndex, columnIndex)
        {
        }
    }
}