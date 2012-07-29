using System;
using NUnit.Framework;
using Moq;
using OposParser;
using OposParser.Logic;

namespace OposTests
{
	[TestFixture()]
	public class ExcelCellTests
	{
		[SetUp()]
		public void SetUp () {
		}
		
		[Test()]
		public void TestConvertRow()
		{
			int row = 1;
			string expectedString = "A";
			string actualString = ExcelCell.ConvertRowToString(row);
			Assert.AreEqual(expectedString, actualString.ToUpper());
			
			row = 2;
			expectedString = "B";
			actualString = ExcelCell.ConvertRowToString(row);
			Assert.AreEqual(expectedString, actualString.ToUpper());
			
			row = 26;
			expectedString = "Z";
			actualString = ExcelCell.ConvertRowToString(row);
			Assert.AreEqual(expectedString, actualString);
			
			row = 27;
			expectedString = "AA";
			actualString = ExcelCell.ConvertRowToString(row);
			Assert.AreEqual(expectedString, actualString);
			
			row = 52;
			expectedString = "AZ";
			actualString = ExcelCell.ConvertRowToString(row);
			Assert.AreEqual(expectedString, actualString);
			
			row = 676;
			expectedString = "YZ";
			actualString = ExcelCell.ConvertRowToString(row);
			Assert.AreEqual(expectedString, actualString);
			
			row = 703;
			expectedString = "AAA";
			actualString = ExcelCell.ConvertRowToString(row);
			Assert.AreEqual(expectedString, actualString);
		}
		
		[Test()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestInvalidRowNumber(){
			int row = 0;
			ExcelCell.ConvertRowToString(row);
		}
	}
}

