using Cpt321;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpts321
{
    public class Spreadsheet
    {
        private int numberOfRows;
        private int numberOfColumns;
        public Cell[,] ArrayOfCells; // initialize the array if cells
        public event PropertyChangedEventHandler CellPropertyChanged = delegate { };

        public Spreadsheet(int rowCount, int columnCount)
        {
           


        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SpreadsheetCell cell = sender as SpreadsheetCell;
            if ("Text" == e.PropertyName)
            {
                if (cell.Text[0] != '=')
                {
                    cell.Value = cell.Text;
                }
            }
            this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(e.PropertyName));
        }
    

        public int RowCount
        {
            get { return this.numberOfRows; }
        }

        public int ColumnCount
        {
            get { return this.numberOfColumns; }
        }

        public Cell GetCell(int row, int column)
        {
            if (this.ArrayOfCells[row, column] != null)
            {
                return this.ArrayOfCells[row, column];
            }
            return null;
        }
    }
}
