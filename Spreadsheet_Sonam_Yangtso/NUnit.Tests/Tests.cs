// <copyright file="TestClass.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using NUnit.Framework;
using CptS321;
using System.Runtime.CompilerServices;
using System.Diagnostics.SymbolStore;
using System.Security.Cryptography;

namespace CptS321
{
    /// <summary
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

        /// <summary>
        /// test case for the Spreadsheet class constructor.
        /// </summary>
        [Test]
        public void TestSpreadsheetRowCount()
        {
            this.sheet = new Spreadsheet(8, 3);
            Assert.That(this.sheet.NumberOfRows, Is.EqualTo(8));
        }

        /// <summary>
        /// test the Spreadsheet class constructor and its ColumnCount property.
        /// </summary>
        [Test]

        public void TestSpreadsheetColumnCount()
        {
            this.sheet = new Spreadsheet(3, 5);
            Assert.That(this.sheet.NumberOfColumns, Is.EqualTo(5));
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
            Assert.AreEqual(tree.InFixExpression, "A1+B1");
        }

        /// <summary>
        /// This Test method test the plus operator.
        /// </summary>
        [Test]
        public void TestExpressionTreeWithPlusOperator()
        {
            ExpressionTree tree = new ExpressionTree("1+2/3*6");
            double value = tree.Evaluate();
            Assert.AreEqual("5", value.ToString());
        }

        /// <summary>
        ///
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
            string expression = "4-5";
            ExpressionTree tree = new ExpressionTree(expression);
            Assert.AreEqual("-1", tree.Evaluate().ToString());
        }

        /// <summary>
        /// test evalute method for multiplication expression.
        /// </summary>
        [Test]
        public void TestMultiplicationEvaluateMethd()
        {
            string expression = "10+3-2";
            ExpressionTree tree = new ExpressionTree(expression);
            Assert.AreEqual("11", tree.Evaluate().ToString());
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
        /// test the evaluate method if an expression is multiply by zero.
        /// </summary>
        [Test]
        public void TestMultiplyByZeroEvaluateMethod()
        {
            ExpressionTree tree = new ExpressionTree("3*4*3*99*7*0");
            Assert.AreEqual("0", tree.Evaluate().ToString());
        }

        /// <summary>
        /// This method test the constructor of the ExpressionTree constructor.
        /// </summary>
        [Test]
        public void TestExpressionTreeConstructor()
        {
            ExpressionTree expression = new ExpressionTree("8");
            Assert.AreEqual("8", expression.InFixExpression.ToString());
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
        public void TestSetVariableMethodException()
        {
            ExpressionTree tree = new ExpressionTree("10+x+y");
            Assert.AreEqual("10", tree.Evaluate().ToString());
        }

        /// <summary>
        /// Test setvaraible method.
        /// </summary>
        [Test]
        public void SetVariableMethod()
        {
            ExpressionTree tree = new ExpressionTree("x+y");
            tree.SetVariable("x", 5.0);
            tree.SetVariable("y", 4.0);

            Assert.AreEqual("9", tree.Evaluate().ToString());
        }

        // Additional Test cases for homework 6

        /// <summary>
        /// This test method test the multiplication operator  precedence over plus operator.
        /// </summary>
        [Test]
        public void TestMultiplicationPrecedenceProperty()
        {
            ExpressionTree tree = new ExpressionTree("3+4*3+4");
            Assert.AreEqual("19", tree.Evaluate().ToString());
        }

        /// <summary>
        /// This method test the parenthesis precedence over other operators.
        /// </summary>
        [Test]
        public void TestParenthesisPrecedence()
        {
            ExpressionTree tree = new ExpressionTree("((1+2)+(6+3)-6)");
            Assert.AreEqual("6", tree.Evaluate().ToString());
        }

        /// <summary>
        /// This test method for Parenthesis precedence over multiplication.
        /// </summary>
        [Test]
        public void TestParenthesisPrecedenceOverMultiplicationOperator()
        {
            ExpressionTree tree = new ExpressionTree("((3+3)*2)");
            Assert.AreEqual("12", tree.Evaluate().ToString());
        }

        /// <summary>
        /// This method test the division operator precedence.
        /// </summary>
        [Test]
        public void TestDivisionPrecedence()
        {
            ExpressionTree tree = new ExpressionTree("5+10/2+5-2");
            Assert.AreEqual("13", tree.Evaluate().ToString());
        }

        /// <summary>
        /// This test the precedence of all the operators over each other.
        /// </summary>
        [Test]
        public void TestOperatorPrecedence()
        {
            ExpressionTree tree = new ExpressionTree("3+4*3+14/7");
            Assert.AreEqual("17", tree.Evaluate().ToString());
        }

        /// <summary>
        /// This method tests an expression for varible value pair.
        /// </summary>
        [Test]
        public void TestExpressionTreeWithNumbersAndVariables()
        {
            ExpressionTree tree = new ExpressionTree("w-5+y+3");
            Assert.AreEqual("-2", tree.Evaluate().ToString());
        }

        /// <summary>
        /// This method test combination of operators.
        /// </summary>
        [Test]
        public void TestExpressionTreeWithCombinationOfOperators()
        {
            ExpressionTree tree = new ExpressionTree("(2+3)*6-3/2");
            Assert.AreEqual("28.5", tree.Evaluate().ToString());
        }

        /// <summary>
        /// This Test method test for new variable in the dictionary.
        /// </summary>
        [Test]
        public void TestForNewVaraibleException()
        {
            ExpressionTree tree = new ExpressionTree("x");

            Assert.AreEqual("0", tree.Evaluate().ToString());
        }

        // Homework7 test cases starts here

        /// <summary>
        /// Tset set and get method of cell property.
        /// </summary>
        [Test]

        public void TestTextValueProperty()
        {
            this.sheet = new Spreadsheet(50, 26);
            this.sheet.GetCell(3, 5).Text = "99";
            Assert.AreEqual("99", this.sheet.GetCell(3, 5).Value);
            this.sheet.GetCell(3, 5).Value = "99";
            Assert.AreEqual("99", this.sheet.GetCell(3, 5).Text);
        }

        /// <summary>
        /// Cell property test.
        /// </summary>
        [Test]
        public void Test()
        {
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
            Cell A1;
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
            Cell B2;
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
            Cell B1;
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
            Spreadsheet sheet = new Spreadsheet(10, 10);
            A1 = (Cell)sheet.GetCell(5, 5);
            B2 = (Cell)sheet.GetCell(6, 6);
            B1 = (Cell)sheet.GetCell(8, 8);
            A1.Text = "22";
            B2.Text = "33";
            B1.Text = "=A1+B2";
            Assert.AreEqual(B1.Text, "=A1+B2");
            Assert.AreEqual(B2.Text, "33");
        }
    }
}
