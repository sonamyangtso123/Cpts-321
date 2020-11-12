using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
   public class Invoker
    {
        private Stack<ICommand> Undos = new Stack<ICommand>();
        private Stack<ICommand> Redos = new Stack<ICommand>();

        public void Execution(ICommand command)
        {
            
                command.Execute();
            

            this.Undos.Push(command);
        }

       

       
    }
}
