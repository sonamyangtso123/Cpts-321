// <copyright file="Cell.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/* Sonam Yangtso
   11689463 */

namespace CptS321
{
    using System.CodeDom;
    using System.ComponentModel;

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
        /// number of rows in a cell.
        /// </summary>
        ///
        private int rowIndex;

        /// <summary>
        /// Number of comumns in a cell.
        /// </summary>
        private int columnIndex;

        /// <summary>
        /// This is text that is typed into a cell.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        protected string text;
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// This is the value of the cell.
        /// </summary>
        protected string value;

        /// <summary>
        /// / This represent the background color of the cell.
        /// </summary>

        protected uint bgcolor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="row"> row.</param>
        /// <param name="column">column.</param>
        public Cell(int row, int column)
        {
            this.rowIndex = row;
            this.columnIndex = column;
            this.text = string.Empty;
            this.value = string.Empty;
            this.bgcolor = 0xFFFFFFFF;
        }

        /// <summary>
        /// gets the row index of the cell.
        /// </summary>
        public int RowIndex
        {
            get { return this.rowIndex; }
        }

        /// <summary>
        /// gets the column index of the cell.
        /// </summary>
        public int ColumnIndex
        {
            get { return this.columnIndex; }
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

                    // call onPrpertyChanged when ever updates
                    this.OnPropertyChanged("Text");
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the cell. .
        /// sets can be done by only by the Spreadsheet class.
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value == this.value)
                {
                    return;
                }

                this.value = value;

                // call onPropertyChanged when ever updates
                this.OnPropertyChanged("Value");
            }
        }

        public uint BGColor
        {
            get
            {
                return this.bgcolor;
            }

            set
            {
                // don't set the color if the color is same as the value
                if (value == this.bgcolor)
                {
                    return;
                }
                else
                {
                    this.bgcolor = value;
                }

                // call onPropertyChanged when ever updates
                this.OnPropertyChanged("Color");

            }
        }


        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.

        /// <summary>
        /// Cell text or value changes event handler.
        /// </summary>
        /// <param name="name">Text or Value.</param>
        protected virtual void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
