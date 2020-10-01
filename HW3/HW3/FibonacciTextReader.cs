using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW3
{
    public class FibonacciTextReader : TextReader
    {
        private int maxValue;

       // constructor
       public FibonacciTextReader(int value)
        {
            this.maxValue = value;
        }

        public override string ReadLine()
        {
            return base.ReadLine();
        }
    }
}
