using System;
using NUnit.Framework;
using Moq;
using Microsoft.Office.Interop.Excel;

namespace OposTests
{
	[TestFixture()]
	public class ExcelInteropTest
	{
		private Mock<Application> _mockExcel;
		[SetUp]
		public void SetUp () {
			this._mockExcel = new Mock<Application>();
		}
		
		[Test()]
		public void TestCase ()
		{
			this._mockExcel.Setup((e) => (
				e.get_Range(It.IsAny<string>(),
			                It.IsAny<string>()))
			                             );
		}
	}
}

