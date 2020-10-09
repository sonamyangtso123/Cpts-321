// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Spreadsheet_Sonam_Yangtso;
using Cpts321;

namespace NUnit.Tests
{
    [TestFixture]
    public class TestClass
    {
        Spreadsheet sheet;
        SpreadsheetCell cell;

        [Test]
        public void TestSpreadsheetCellGetter()
        {
            this.cell = new SpreadsheetCell(9,8);
            Assert.That(cell.RowIndex, Is.EqualTo(1));
            Assert.That(cell.ColumnIndex, Is.EqualTo(5));
        }
        [Test]
        public void TestSpreadsheetRowCount()
        {
            this.sheet = new Spreadsheet(8, 3);
            Assert.That(sheet.RowCount, Is.EqualTo(8));
           
        }
        [Test]

        public void TestSpreadsheetColumnCount()
        {
            this.sheet = new Spreadsheet(3, 5);
            Assert.That(sheet.ColumnCount, Is.EqualTo(5));
        }


    }
}
