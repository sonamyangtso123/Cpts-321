using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public class ConstantNode : ExpressionTreeNode
    {
        private readonly double value;

        public ConstantNode(double value)
        {
            this.value = value;

        }
        public ConstantNode()
        {

        }
        public double Value
        {
            get;set;

        }

        /// <inheritdoc/>
        public override double Evaluate()
        {
            return Value;
        }
    }
}
