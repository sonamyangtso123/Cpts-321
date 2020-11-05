// <copyright file="Cell.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/* Sonam Yangtso
   11689463 */

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is abstract base class and it represents one cell in the Spreadsheet
    /// It implements the INotifyPropertyChanged interface.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <inheritdoc/>
#pragma warning disable SA1130 // Use lambda syntax
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
#pragma warning restore SA1130 // Use lambda syntax
        /// <summary>
        /// This is a row number of the cell.
        /// </summary>
        //protected int rowIndex;

        /// <summary
        /// This is a column number of the cell
        /// </summary>
       // protected int columnIndex;

        /// <summary>
        /// This is text that is typed into a cell.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        protected string text = string.Empty;
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// This is the value of the cell.
        /// </summary>
        protected string value = string.Empty;

        protected ExpressionTree tree;

        private Dictionary<int, string> location = new Dictionary<int, string>();

        // The list of all of the variable names in which the cell references.
        public Dictionary<string, double> varNames = new Dictionary<string, double>();



        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="rowIndex">row number of the cell. </param>
        /// <param name="columnIndex"> Column number of the cell.</param>
        public Cell(int rowIndex, int columnIndex)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;

            int k = 0;
            for (int i = 65; i < 91; i++)
            {
                this.location.Add(k, ((char)i).ToString());
                ++k;
            }

        }

        public string IndexName
        {
            get
            {
                return this.location[this.ColumnIndex].ToString() + (this.RowIndex + 1).ToString();
            }
        }



        /// <summary>
        /// gets the row number of the cell.
        /// </summary>
        public int RowIndex
        {
            get; 
        }

        /// <summary>
        /// gets the column number of the cell.
        /// </summary>
        public int ColumnIndex
        {
            get;
            }
            

        /// /// <summary>
        /// Gets or sets the changes that happens in text of the cell.
        /// If the text is set to exact same text, do nothing just return it.
        /// If the text is being changed then update the text in the cell by
        /// ivoking ProvertyChnagedEvent.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (value == this.text)
                {
                    return;
                }
                else
                {
                    this.text = value;

                    // notify anything that subscribes to this event that the “Text” property has changed.
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }

        /// <summary>
        /// Gets the value of the cell. .
        /// sets can be done by only by the Spreadsheet class.
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }

            internal set
            {
                if(value == this.value)
                {
                    return;
                }
                this.value = value;

                // notify anything that subscribes to this event that the “Value” property has changed.
                this.PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }

        // From here changes Imade 
        private void OnPropertyChanged(string passedInName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(passedInName));
        }

        public void SubExpTreeToCell(Cell cell)
        {
            this.tree.SubscribeToCell(cell);
        }

        // creates a new expression tree for the cell.
        public void NewExpression(string exp)
        {
            this.tree = new ExpressionTree(exp);
            this.varNames = this.tree.Variables;
            this.tree.parent = this;
        }

        // computes the expression tree for the cell.
        public string ComputeExpression()
        {
            return this.tree.Evaluate().ToString();
        }





    }
}
