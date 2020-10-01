using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace HW3
{
    public class FibonacciTextReader : TextReader
    {
        private int maxValue;

        // constructor
        public FibonacciTextReader()
        {
            //this.MaxValue = 0;
        }
        public FibonacciTextReader(int value)
        {
            this.maxValue = value;
        }

        public int MaxValue
        {
            get { return this.maxValue; }
            set { this.maxValue = value; }
        }

        public override string ReadLine()
        {
            BigInteger firstNumber = 0;
            BigInteger secondNumber = 1;
            BigInteger temp;
            int count = 0;
            while (count < this.MaxValue)
            {
                if (this.MaxValue == 0)
                {
                    count++;
                    return firstNumber.ToString();
                }
                else if (MaxValue == 1)
                {
                    count++;
                    return secondNumber.ToString();
                }
                else
                {
                    temp = firstNumber + secondNumber;
                    firstNumber = secondNumber;
                    secondNumber = temp;
                    return temp.ToString();
                }
            }
            return null;
        }
    }
}
