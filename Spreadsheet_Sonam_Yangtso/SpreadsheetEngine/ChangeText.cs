using CptS321;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public class ChangeText : ICommand
    {
        private string oldText;
        private string newText;
        private Cell cell;

        public ChangeText(Cell cell, string oldText,  string newText)
        {
            this.cell = cell;
            this.oldText = oldText;
            this.newText = newText;
        }

        public void Execute()
        {
            this.cell.Text = this.newText;
        }

        public void Undo()
        {
            this.cell.Text = this.oldText;
        }

    }
}
