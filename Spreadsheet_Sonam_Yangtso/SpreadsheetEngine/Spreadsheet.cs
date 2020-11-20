// <copyright file="Spreadsheet.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
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
            this.ArrayOfCells = new Cell[rowCount, columnCount];
            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    Cell cell = new SpreadsheetCell(i, j);
                    cell.PropertyChanged += this.OnSpreadsheetPropertyChanged;
                    this.ArrayOfCells[i, j] = cell;
                }
            }
        }

        /// <summary>
        /// Gets method for RowCount, It will return the number of rows.
        /// </summary>
        public int NumberOfRows
        {
            get
            {
                return this.ArrayOfCells.GetLength(0);
            }
        }

        /// <summary>
        /// Gets method for CoulumnCount. It will return the number of columns in a given Spreadsheet.
        /// </summary>
        public int NumberOfColumns
        {
            get
            {
                return this.ArrayOfCells.GetLength(1);
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
        /// This method get called in the Form class when the text of cell get changes to value.
        /// This method serve as a way for outside world.
        /// subscribe to a single event that lets them know when any property for any cell in the worksheet has changed.
        /// The spreadsheet class has to subscribe to all the PropertyChanged events for every cell in order to allow this to happen.
        ///   This is where the spreadsheet will set the value for a particular cell if its text has just changed. The implementation of
        ///   this is discussed more in step 6.
        ///   When a cell triggers the event the spreadsheet will “route” it by calling its CellPropertyChanged event.
        /// </summary>
        /// <param name="rowIndex">row index of the cell.</param>
        /// <param name="columnIndex">column number. </param>
        /// <param name="newText"> new text.</param>
        /// <returns>True /False.</returns>
        public bool CellTextChanged(int rowIndex, int columnIndex, string newText)
        {
            /* Subscribe to cell property changed event */
            // this.GetCell(rowIndex, columnIndex).PropertyChanged += this.CellPropertyChanged;
            if (this.GetCell(rowIndex, columnIndex) != null)
            {
                this.GetCell(rowIndex, columnIndex).Text = newText;
                this.EvaluateNewCellValue(this.GetCell(rowIndex, columnIndex));
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EvaluateNewCellValue(Cell currentCell)
        {
            /* Conversion Required */
            if (currentCell.Text[0] != '=')
            {
                currentCell.Value = currentCell.Text;
            }
            else
            {
                /* Set value equal to another cell's value */
                ExpressionTree expTree = new ExpressionTree(currentCell.Text.Substring(1));

                List<string> variableList = expTree.GetVariableName();

                /* Can assume that all variables will be cells in the form (A1, B2, etc.) for this Assignment */
                foreach (string key in variableList)
                {
                    int colNum = key[0] - 65;       // convert ascii to index
                    int rowNum = int.Parse(key[1].ToString()) - 1;

                    if (double.TryParse(this.GetCell(rowNum, colNum).Value, out double value))
                    {
                        expTree.SetVariable(key, value);
                    }
                    else
                    {
                        expTree.SetVariable(key, 0);
                    }
                }

                currentCell.Value = expTree.Evaluate().ToString();
                Console.WriteLine(currentCell.Value);
            }
        }

        private void OnSpreadsheetPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
                this.EvaluateNewCellValue((Cell)sender);

                this.CellPropertyChanged.Invoke(sender, e);
        }

        public void Save(Stream stream)
        {
            // create an writeFile for xml file
            XmlWriter writeFile = XmlWriter.Create(stream);
            writeFile.WriteStartDocument();

            // create outermost element of the xml file
            writeFile.WriteStartElement("Spreadsheet");
            foreach (var cell in this.ArrayOfCells)
            {
                // if each cell has non default value
                if (cell.Text != string.Empty || cell.BGColor != 0xFFFFFFFF)
                {
                    writeFile.WriteStartElement("cell");
                    writeFile.WriteAttributeString("row", cell.RowIndex.ToString());
                    writeFile.WriteAttributeString("column", cell.ColumnIndex.ToString());

                    writeFile.WriteStartElement("BGColor");
                    writeFile.WriteString(cell.BGColor.ToString());
                    writeFile.WriteEndElement();

                    writeFile.WriteStartElement("Text");
                    writeFile.WriteString(cell.Text);
                    writeFile.WriteEndElement();

                    writeFile.WriteEndElement();
                }
            }

            writeFile.WriteEndElement();
            writeFile.WriteEndDocument();

            writeFile.Close();
        }

        public void Load(Stream stream)
        {
            Cell tempCell = new SpreadsheetCell(-1, -1);

            // Create a file to read
            XmlReader readFile = XmlReader.Create(stream);

            // Clear all cells before loading
            foreach (Cell cell in this.ArrayOfCells)
            {
                cell.BGColor = 0xFFFFFFFF;
                cell.Text = string.Empty;
            }

            // Read through the file
            while (!readFile.EOF)
            {
                if (readFile.NodeType == XmlNodeType.Element && readFile.Name == "cell")
                {
                    tempCell = this.ArrayOfCells[int.Parse(readFile.GetAttribute("row")), int.Parse(readFile.GetAttribute("col"))];
                    readFile.Read();
                }
                else if (readFile.NodeType == XmlNodeType.Element && readFile.Name == "BGColor")
                    tempCell.BGColor = uint.Parse(readFile.ReadElementContentAsString());
            
                else if (readFile.NodeType == XmlNodeType.Element && readFile.Name == "Text")
            {
                tempCell.Text = readFile.ReadElementContentAsString();
            }
            else
            {
                readFile.Read();
            }
        }

        // Close the file
        readFile.Close();
        }




}
}
