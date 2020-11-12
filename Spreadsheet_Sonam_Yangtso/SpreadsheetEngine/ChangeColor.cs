using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public class ChangeColor : ICommand
    {
        private List <uint> oldColor;
        private List<Cell> cells;
        private uint newColor;
        private Cell cell;
        private uint bGColor;
        private uint v;

        public ChangeColor(List<Cell> cells, List<uint>oldColor, uint newColor)
        {
            this.oldColor = oldColor;
            this.newColor = newColor;
            this.cells = cells;
        }

        public ChangeColor(Cell cell, uint bGColor, uint v)
        {
            this.cell = cell;
            this.bGColor = bGColor;
            this.v = v;
        }

        public void Execute()
        {
            foreach (Cell cell in this.cells)
            {
                cell.BGColor = this.newColor;
            }

        }

        public void Undo()
        {
            for (int i = 0; i < cells.Count; i++)
            {
                this.cells[i].BGColor = this.oldColor[i];
            }
           
        }

    }
}
