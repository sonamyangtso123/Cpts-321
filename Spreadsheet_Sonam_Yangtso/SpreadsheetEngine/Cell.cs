﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Cpt321
{
    public abstract class Cell : INotifyPropertyChanged
    {
        // 
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private readonly int rowIndex;
        private readonly int columnIndex;
        protected String text = String.Empty;
        protected String value = String.Empty;

        // constructor
        public Cell(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }

        // 
        public int RowIndex
        {
            get { return this.rowIndex; }
        }
        //
        public int ColumnIndex
        {
            get
            {
                return this.columnIndex;
            }
        }

        public String Text
        {
            get { return this.text; }
            set
            {
                if (value == this.text) { return;}
                this.text =value;
                PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }

        public String Value
        {
            get { return this.Value; }
           internal set
            {
                if(value == Value) { return; }
                this.value = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));

            }
        }

    }

}
