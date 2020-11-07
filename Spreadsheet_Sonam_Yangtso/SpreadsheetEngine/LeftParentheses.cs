using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    internal class LeftParentheses : CptS321.OperatorNode
    {
        public LeftParentheses()
            : base('(')
        {
        }
        public override ushort Precedence => 0;

        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            throw new System.InvalidOperationException("Evaluation can not be done on parentheses");
        }

    }
}
