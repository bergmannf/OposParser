using System;
using NUnit.Framework;
using ExcelInterop;
using OposParser.Interface;

namespace OposTests
{
        [TestFixture]
        public class ExcelCellTests
        {
                [SetUp]
                public void SetUp ()
                {
                }

                [Test]
                public void TestCorrectCellType() {
                        ICell numericCell = ExcelCell.CreateCell (5.0, 1, 2);
                        Assert.AreSame (typeof(NumericCell), numericCell.GetType());
                        ICell someOtherCell = ExcelCell.CreateCell ("string", 1, 2);
                        Assert.AreEqual (typeof(ComparableExcelCell), someOtherCell.GetType ());
                }

                [Test]
                public void TestConvertcolumn ()
                {
                        int column = 1;
                        string expectedString = "A";
                        string actualString = ExcelCell.ConvertColumnToString (column);
                        Assert.AreEqual (expectedString, actualString.ToUpper ());

                        column = 2;
                        expectedString = "B";
                        actualString = ExcelCell.ConvertColumnToString (column);
                        Assert.AreEqual (expectedString, actualString.ToUpper ());

                        column = 26;
                        expectedString = "Z";
                        actualString = ExcelCell.ConvertColumnToString (column);
                        Assert.AreEqual (expectedString, actualString);

                        column = 27;
                        expectedString = "AA";
                        actualString = ExcelCell.ConvertColumnToString (column);
                        Assert.AreEqual (expectedString, actualString);

                        column = 52;
                        expectedString = "AZ";
                        actualString = ExcelCell.ConvertColumnToString (column);
                        Assert.AreEqual (expectedString, actualString);

                        column = 676;
                        expectedString = "YZ";
                        actualString = ExcelCell.ConvertColumnToString (column);
                        Assert.AreEqual (expectedString, actualString);

                        column = 703;
                        expectedString = "AAA";
                        actualString = ExcelCell.ConvertColumnToString (column);
                        Assert.AreEqual (expectedString, actualString);
                }

                [Test]
                [ExpectedException(typeof(ArgumentOutOfRangeException))]
                public void TestInvalidcolumnNumber ()
                {
                        int column = 0;
                        ExcelCell.ConvertColumnToString (column);
                }
        }
}
