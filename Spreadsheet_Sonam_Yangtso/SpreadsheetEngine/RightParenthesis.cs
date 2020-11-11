using CptS321;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class RightParentheses:OperatorNode
    {
        public RightParentheses()
            : base(')')
        {
        }

        public override ushort Precedence => 0;

        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            throw new System.InvalidOperationException("Evaluation can not be done on parentheses");
        }
    }
}
