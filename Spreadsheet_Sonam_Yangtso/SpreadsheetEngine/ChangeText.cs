// <copyright file="ChangeText.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using CptS321;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// This concrete ChangeText class implents the ICommand interface class.
    /// </summary>
    public class ChangeText : ICommand
    {
        private readonly string oldText;
        private readonly string newText;
        private readonly Cell cell;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeText"/> class.
        /// </summary>
        /// <param name="cell"> cell.</param>
        /// <param name="oldText">old text.</param>
        /// <param name="newText">new text.</param>
        public ChangeText(Cell cell, string oldText,  string newText)
        {
            this.cell = cell;
            this.oldText = oldText;
            this.newText = newText;
        }

        /// <summary>
        /// this method changes the cell text to a new text.
        /// </summary>
        public void Execute()
        {
            this.cell.Text = this.newText;
        }

        /// <summary>
        /// This method changes the cell text back to olf text.
        /// </summary>
        public void UnExecute()
        {
            this.cell.Text = this.oldText;
        }
    }
}
