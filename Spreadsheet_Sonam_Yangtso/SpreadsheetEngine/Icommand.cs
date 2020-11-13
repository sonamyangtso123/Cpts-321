using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    
    public interface ICommand
    {

        //string CommandType();
         void  Execute();

        void UnExecute ();
    }
}
