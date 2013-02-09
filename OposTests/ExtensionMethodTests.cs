using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using NUnit.Framework;
using OposParser;
using OposParser.Logic;
using ExcelInterop;

namespace OposTests
{
	[TestFixture]
	public class IterToolsTest
	{
		[Test]
		public void TestApplyUntilInt()
		{
			int[] numbers = new int[]{1, 2, 3, 4, 5, 6};
			Func<int, bool> c = IterTools.PartiallyApply<int, bool>(IterToolTestAdditions.GreaterEqual,
			                                                        10);
			Func<int, int, int> f = IterToolTestAdditions.Add;
			Tuple<int, int> results = IterTools.ApplyUntil<int>(numbers,
			                                                    f,
			                                                    c);
			Assert.AreEqual(Tuple.Create(4, 10), results);
		}

		[Test]
		public void TestApplyUntilExcelCell()
		{
			ICollection<ExcelCell<double>> cells = new List<ExcelCell<double>>{
				new ExcelCell<double>(1, 1, 1),
				new ExcelCell<double>(1, 2, 2),
				new ExcelCell<double>(2 ,1, 3)
			};
			var c = IterTools.PartiallyApply<ExcelCell<double>, bool>(IterToolTestAdditions.GreaterEqual,
			                                                          new ExcelCell<double>(999, 999, 10.0));
			Func<ExcelCell<double>, ExcelCell<double>, ExcelCell<double>> f = IterToolTestAdditions.Add;
			var cell = IterTools.ApplyUntil<ExcelCell<double>>(cells,
			                                                   f,
			                                                   c);
			Assert.AreEqual(cell.Item1.Value, 6);
		}

		[Test]
		public void TestApplyUntilNonGenericReference()
		{
			ICollection<ExcelCell<double>> castCells = null;
			IList cells = new List<ExcelCell<double>>{
				new ExcelCell<double>(1, 1, 1),
				new ExcelCell<double>(1, 2, 2),
				new ExcelCell<double>(2 ,1, 3)
			};
			if (cells[0].GetType() == typeof(ExcelCell<double>)) {
				castCells = (ICollection<ExcelCell<double>>) cells;
			}
			var c = IterTools.PartiallyApply<ExcelCell<double>, bool>(IterToolTestAdditions.GreaterEqual,
			                                                          new ExcelCell<double>(999, 999, 10.0));
			Func<ExcelCell<double>, ExcelCell<double>, ExcelCell<double>> f = IterToolTestAdditions.Add;
			var cell = IterTools.ApplyUntil<ExcelCell<double>>(castCells,
			                                                   f,
			                                                   c);
			Assert.AreEqual(cell.Item1.Value, 6);
		}

		//              public static bool GreaterEqual(ExcelCell number, ExcelCell number2) {
		//                      if (number.Value >= number2.Value) {
		//                              return true;
		//                      }
		//                      return false;
		//              }

		//              public static ExcelCell CellAdd(ExcelCell cell1, ExcelCell cell2) {
		//                      object sum;
		//                      try {
		//                              sum = cell1.Value + cell2.Value;
		//                      } catch (Exception e) {
		//                              throw;
		//                      }
		//                      return sum;
		//              }
	}

	public static class IterToolTestAdditions {

		public static int Add(int number, int number2) {
			return number + number2;
		}

		public static ExcelCell<double> Add(ExcelCell<double> c1,
		                                    ExcelCell<double> c2)
		{
			return ExcelCell<double>.Create(999, 999,(c1.Value + c2.Value));
		}

		public static bool GreaterEqual(int number, int comparison) {
			if (number >= comparison) {
				return true;
			}
			return false;
		}

		public static bool GreaterEqual(ExcelCell<double> c1,
		                                ExcelCell<double> comparison)
		{
			return c1.Value > comparison.Value;
		}
	}
}
