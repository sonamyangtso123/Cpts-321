using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public class OperatorNodeFactory
    {
        public static OperatorNode CreateNewNode(char op)
        {
            switch (op)
            {
                case '+':
                    return new PlusOperatorNode();

                case '-':
                    return new MinusOperatorNode();

                case '*':
                    return new MultiplicationOperatorNode();

                case '/':
                    return new DivisionOperatorNode();

                default:
                    return null;
            }
        }
      
    }
}
