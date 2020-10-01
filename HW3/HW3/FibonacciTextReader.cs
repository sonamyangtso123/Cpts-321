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
        private BigInteger firstNumber;
        private BigInteger secondNumber;
        private int count;


        // constructor

        public FibonacciTextReader(int number)
        {
            this.maxValue = number;
            this.firstNumber = 0;
            this.secondNumber = 1;
            this.count = 0;
        }

        public int MaxValue
        {
            get { return this.maxValue; }
            set { this.maxValue = value; }
        }

        public override string ReadLine()
        {
            BigInteger temp;

            while (count <= this.maxValue) 

            {
                if (count == 0)
                {
                    count++;
                    return firstNumber.ToString();

                }
                if (count == 1)
                {
                    count++;
                    return secondNumber.ToString();
                }
                else
                {

                    temp = firstNumber + secondNumber;
                    firstNumber = secondNumber;
                    secondNumber = temp;
                    count++;
                    return temp.ToString();
                }

            }
        return null;

        }
    }
}

