// Sonam Yangtso
// <copyright file="fibonacciTextReader.cs" company="wsu">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace HW3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is FibonacciTextReader class.It extends TextReader class and override readLine method.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        // fields
        private int maxValue;
        private BigInteger firstNumber;
        private BigInteger secondNumber;
        private int count;

        /// <summary>
        /// This is constructor and takes the maximum number of numbers sequence
        /// </summary>
        /// <param name="number"></param>
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

        /// <summary>
        /// Override the ReadLine method which delivers the next number (as a string) in the
        /// Fibonaccisequence.You need logic in this function to handle the first two numbers as
        /// special cases. You must return null after the nth call, where n is the integer value passed
        /// to the constructor
        /// </summary>
        /// <returns></returns>
        public override string ReadLine()
        {
            BigInteger temp;

            while (this.count <= this.maxValue)
            {
                // if maxValue is 0
                if (this.count == 0)
                {
                    this.count++;
                    return this.firstNumber.ToString();
                }

                // if maxvlue is 1
                if (this.count == 1)
                {
                    this.count++;
                    return this.secondNumber.ToString();
                }
                else
                {
                    // maxvlue is greater than 1
                    temp = this.firstNumber + this.secondNumber;
                    this.firstNumber = this.secondNumber;
                    this.secondNumber = temp;
                    this.count++;
                    return temp.ToString();
                }
            }

            // mavalue is is less than zero
            return null;
        }
    }
}
