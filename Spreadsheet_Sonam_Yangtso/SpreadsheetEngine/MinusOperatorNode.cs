﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace CptS321
{
    public class MinusOperatorNode :OperatorNode
    {
        public static char Operator
        {
            get { return '-'; }
        }

        public static ushort Precedence
        {
            get { return 7; }
        }

        public static Associative Associativity
        {
            get { return Associative.Left; }
        }

        public MinusOperatorNode()
        {
        }

        public override double Evaluate()
        {
            return Left.Evaluate() - Right.Evaluate();
        }
    }
}
