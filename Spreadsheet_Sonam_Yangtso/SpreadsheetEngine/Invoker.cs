using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CptS321
{
   public class Invoker
    {

        private Stack<ICommand> undoStack = new Stack<ICommand>();
        private Stack<ICommand> redoStack = new Stack<ICommand>();
        

        public void AddUndo(ICommand command)
        {
            this.undoStack.Push(command);
            
        }

        // Execute the undo command.
        public void UndoCommand()
        {
            if (undoStack.Count > 0)
            {

                this.undoStack.Peek().UnExecute();
                this.redoStack.Push(this.undoStack.Pop());
            }
            else
            {
                return;
            }
            
        }

        public void RedoCommand()
        {
            if(redoStack.Count > 0)
            {
                this.redoStack.Peek().Execute();
                this.undoStack.Push(this.redoStack.Pop());
            }
            else
            {
                return;
            }
            
            
        }

        public bool  UndoAvailable()
        {
            if (this.undoStack.Count > 0)

            {

                //return Undos.Peek().CommandType();
                return true;
                    
            }

            //return string.Empty;
            return false;
        }

        public bool RedoAvailable()
        {
            if (this.redoStack.Count > 0)
            {
                 //return Redos.Peek().()Name;
                return true;
            }

            //return string.Empty;
            return false;
        }






    }
}
