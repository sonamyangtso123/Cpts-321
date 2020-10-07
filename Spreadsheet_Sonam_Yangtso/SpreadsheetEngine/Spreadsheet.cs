using Cpt321;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpts321
{
    class Spreadsheet
    {
        private int numberOfRows;
        private int numberOfColumns;
        private Cell[,] cells;
        public event PropertyChangedEventHandler CellPropertyChanged = delegate { };

        public Spreadsheet(int rowCount, int columnCount)
        {
            this.numberOfRows = rowCount;
            this.numberOfColumns = columnCount;
            this. cells = new Cell[rowCount, columnCount];
            for(int i= 0; i<rowCount;i++)
            {
                for(int j = 0; j < columnCount; j++)  
                {
                    this.cells [i, j] = new SCell (i, j); 
                }
            }

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
            if (this.cells[row, column] != null)
            {
                return this.cells[row, column];
            }
            return null;
        }
    }
}
