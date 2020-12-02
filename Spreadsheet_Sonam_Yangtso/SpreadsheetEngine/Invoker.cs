// <copyright file="Invoker.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CptS321
{
    /// <summary>
    /// This is Invoker class. It contains undo and redo methods.
    /// </summary>
   public class Invoker
    {
        private readonly Stack<ICommand> undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> redoStack = new Stack<ICommand>();

        /// <summary>
        /// This Addundo method add the new command onthe undoStack.
        /// </summary>
        /// <param name="command"> new command. </param>
        public void AddUndo(ICommand command)
        {
            this.undoStack.Push(command);
        }

        /// <summary>
        /// This UndoCommand calls UnExecute methood from Icommand class on a command and push the command to redostack.
        /// </summary>
        public void UndoCommand()
        {
            if (this.undoStack.Count > 0)
            {
                this.undoStack.Peek().UnExecute();
                this.redoStack.Push(this.undoStack.Pop());
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// This method is calls the execute method from Icommand class on a caommand and push the command to undo stack.
        /// </summary>
        public void RedoCommand()
        {
            if (this.redoStack.Count > 0)
            {
                this.redoStack.Peek().Execute();
                this.undoStack.Push(this.redoStack.Pop());
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// This method check s there is any command on the undo stack.
        /// </summary>
        /// <returns>.boolean.</returns>
        public bool UndoAvailable()
        {
            if (this.undoStack.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method checks there is any commands left on the redo stack.
        /// </summary>
        /// <returns>boolean.</returns>
        public bool RedoAvailable()
        {
            if (this.redoStack.Count > 0)
            {
                return true;
            }

            return false;
        }

        public void ClearUndoStack()
        {
            this.undoStack.Clear();
        }

        public void ClearRedoStack()
        {
            this.redoStack.Clear();
        }
    }
}
