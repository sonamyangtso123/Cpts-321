// <copyright file="ChangeColor.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// this is a concrete class ChangeColor class and implements the ICommand interface.
    /// </summary>
    public class ChangeColor : ICommand
    {
        private readonly List<uint> oldColor;
        private readonly List<Cell> cells;
        private readonly uint newColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeColor"/> class.
        /// </summary>
        /// <param name="cells">list of cells to change the color.</param>
        /// <param name="oldColor"> get the old color of the cells.</param>
        /// <param name="newColor"> new color.</param>.
        public ChangeColor(List<Cell> cells, List<uint> oldColor, uint newColor)
        {
            this.oldColor = oldColor;
            this.newColor = newColor;
            this.cells = cells;
        }

        /// <summary>
        /// This method changes existing color of each cells to a new color.
        /// </summary>
        public void Execute()
        {
            foreach (Cell cell in this.cells)
            {
                cell.BGColor = this.newColor;
            }
        }

        /// <summary>
        /// This method change the cells back to its old color.
        /// </summary>
        public void UnExecute()
        {
            for (int i = 0; i < this.cells.Count; i++)
            {
                this.cells[i].BGColor = this.oldColor[i];
            }
        }
    }
}
