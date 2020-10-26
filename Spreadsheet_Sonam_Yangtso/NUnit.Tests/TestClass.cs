// <copyright file="TestClass.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using CptS321;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System;

namespace NUnit.Tests
{
    /// <summary>
    /// Test class for the Assignment4.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        /// <summary>
        /// create an instance of Spreadsheet class.
        /// </summary>
        private Spreadsheet sheet;

        /// <summary>
        /// create an instance of cell class.
        /// </summary>
        private SpreadsheetCell cell;

        /// <summary>
        /// test the SpreadsheetCell class constructor.
        /// </summary>
        [Test]
        public void TestSpreadsheetCellGetter()
        {
            this.cell = new SpreadsheetCell(9, 8);
            Assert.That(this.cell.RowIndex, Is.EqualTo(9));
            Assert.That(this.cell.ColumnIndex, Is.EqualTo(8));
        }

       [Test]
        public void TestExpressionTreeWithCombinationOfOperators()
        {
            ExpressionTree tree = new ExpressionTree("(2*3)+6");
            double value = tree.Evaluate();
            Assert.AreEqual(Convert.ToDouble(12), value);
        }

        /// <summary>
        /// test case for the Spreadsheet class constructor.
        /// </summary>
        [Test]
        public void TestSpreadsheetRowCount()
        {
            this.sheet = new Spreadsheet(8, 3);
            Assert.That(this.sheet.RowCount, Is.EqualTo(8));
        }

        /// <summary>
        /// test the Spreadsheet class constructor and its ColumnCount property.
        /// </summary>
        [Test]

        public void TestSpreadsheetColumnCount()
        {
            this.sheet = new Spreadsheet(3, 5);
            Assert.That(this.sheet.ColumnCount, Is.EqualTo(5));
        }

        /// <summary>
        /// Test the GetCell method in the spreadsheet class.
        /// </summary>
        [Test]

        public void TestGetCell()
        {
            this.sheet = new Spreadsheet(50, 26);
            this.sheet.GetCell(3, 5).Text = "hello";
            Assert.That(this.sheet.GetCell(3, 5).Text, Is.EqualTo("hello"));
        }

        // Start here with Homework5 Test cases

        /// <summary>
        /// Test ExpressionTree constructor.
        /// </summary>
        /// 

        [Test]
        public void TestExpressionTreeConstructorWithAString()
        {
            ExpressionTree tree = new ExpressionTree("A1+B1");
            Assert.AreEqual(tree.InFix, "A1+B1");
        }
        [Test]
        public void TestExpressionTreeWithAddition()
        {
            ExpressionTree tree = new ExpressionTree("10+0");
            double value = tree.Evaluate();
            Assert.AreEqual(Convert.ToDouble(10.0), value);
        }

        [Test]
        public void TestExpressionNodeConstructor()
        {
            ExpressionTree expression = new ExpressionTree("8+0");
            Assert.AreEqual("8", expression.Evaluate().ToString());
        }

        /// <summary>
        /// test evaluate method for addition expression.
        /// </summary>
        [Test]
        public void TestPlusEvaluateMethod()
        {
            string expression = "3+4+3";
            ExpressionTree tree = new ExpressionTree(expression);
            Assert.AreEqual("10", tree.Evaluate().ToString());
        }

        /// <summary>
        /// Test evaluate method for subtraction expression.
        /// </summary>
       [Test]
        public void TestMinusEvaluateMethod()
        {
            string expression = "7-3-0";
            ExpressionTree tree = new ExpressionTree(expression);
            Assert.AreEqual("4", tree.Evaluate().ToString());
        }

        /// <summary>
        /// test evalute method for multiplication expression.
        /// </summary>
        [Test]
        public void TestMultiplicationEvaluateMethd()
        {
            string expression = "10*3*2";
            ExpressionTree tree = new ExpressionTree(expression);
            Assert.AreEqual("60", tree.Evaluate().ToString());
        }

        /// <summary>
        /// test evalaute method for division expression.
        /// </summary>
        [Test]
        public void TestDivisionEvaluateMethod()
        {
            string expression = "5/2";
            ExpressionTree tree = new ExpressionTree(expression);
            Assert.AreEqual("2.5", tree.Evaluate().ToString());
        }

        /// <summary>
        /// test evalute method for decimal expression.
        /// </summary>
        [Test]
        public void TestDecimalEvaluateMethod()
        {
            ExpressionTree tree = new ExpressionTree("2.0+3.0");
            Assert.AreEqual("7.9", tree.Evaluate().ToString());
        }

        /// <summary>
        /// test the evaluate method if an expression is multiply by zero.
        /// </summary>
        [Test]
        public void TestMultiplyByZeroEvaluateMethod()
        {
            ExpressionTree tree = new ExpressionTree("3*4*3*99*7*0");
            Assert.AreEqual("0", tree.Evaluate().ToString());
        }

        /// <summary>
        /// test the evaluate method if the expression is divided by zero.
        /// </summary>
        [Test]
        public void TestDivideByZero()
        {
            string expression = "3950/0";
            ExpressionTree tree = new ExpressionTree(expression);
            Assert.AreEqual("∞", tree.Evaluate().ToString());
        }

        /// <summary>
        /// test the setVaraible method.
        /// </summary>
        [Test]
        public void TestSetVariableMethod()
        {
            ExpressionTree tree = new ExpressionTree("10+x+y");

            Assert.AreEqual("10+x+y", tree.InFix);

            tree.SetVariable("x", 2.0);
            tree.SetVariable("y", 4.0);

            Assert.AreEqual("16", tree.Evaluate().ToString());
        }

        [Test]
        public void TestMultiplicationPrecedenceProperty()
        {
            ExpressionTree tree = new ExpressionTree("3+4*3");
            Assert.AreEqual("15", tree.Evaluate().ToString());
        }

        [Test]
        public void TestParenthesisProperty()
        {
            ExpressionTree tree = new ExpressionTree("(3+3) -(2+2)");
            Assert.AreEqual("2", tree.Evaluate().ToString());
        }

        [Test]
        public void TestDivisionPrecedenceProperty()
        {
            ExpressionTree tree = new ExpressionTree("5+10/2");
            Assert.AreEqual("10", tree.Evaluate().ToString());
        }

        [Test]
        public void TestAnExpression()
        {
            ExpressionTree tree = new ExpressionTree("3+4*3/2-7");
            Assert.AreEqual("2", tree.Evaluate().ToString());
        }
    }
}
