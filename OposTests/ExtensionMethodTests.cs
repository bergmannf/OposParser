using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using NUnit.Framework;
using OposParser;
using OposParser.Logic;
using ExcelInterop;
using OposParser.Interface;

namespace OposTests
{
        [TestFixture]
        public class IterToolsTest
        {
                [Test]
                public void TestApplyUntilInt ()
                {
                        int[] numbers = new int[]{1, 2, 3, 4, 5, 6};
                        Func<int, bool> c = IterTools.PartiallyApply<int, bool> (IterToolTestAdditions.GreaterEqual,
                                                                    10);
                        Func<int, int, int> f = IterToolTestAdditions.Add;
                        Tuple<int, int> results = IterTools.ApplyUntil<int> (numbers,
                                                                f,
                                                                c);
                        Assert.AreEqual (Tuple.Create (4, 10), results);
                }

                [Test]
                public void TestApplyUntilExcelCell ()
                {
                        ICollection<INumericCell> cells = new List<INumericCell>{
                new NumericCell(1, 1, 1),
                new NumericCell(1, 2, 2),
                new NumericCell(2 ,1, 3)
            };
                        var c = IterTools.PartiallyApply<INumericCell, bool> (IterToolTestAdditions.GreaterEqual,
                                                                      new NumericCell (10.0, 999, 999));
                        Func<INumericCell, INumericCell, INumericCell> f = IterToolTestAdditions.Add;
                        var cell = IterTools.ApplyUntil<INumericCell> (cells,
                                                               f,
                                                               c);
                        Assert.AreEqual (cell.Item1.Value, 6);
                }

                [Test]
                public void TestApplyUntilNonGenericReference ()
                {
                        ICollection<INumericCell> castCells = null;
                        IList cells = new List<INumericCell>{
                new NumericCell(1, 1, 1),
                new NumericCell(1, 2, 2),
                new NumericCell(2 ,1, 3)
            };
                        if (cells [0].GetType () == typeof(INumericCell)) {
                                castCells = (ICollection<INumericCell>)cells;
                        }
                        var c = IterTools.PartiallyApply<INumericCell, bool> (IterToolTestAdditions.GreaterEqual,
                                                                      new NumericCell (10.0, 999, 999));
                        Func<INumericCell, INumericCell, INumericCell> f = IterToolTestAdditions.Add;
                        var cell = IterTools.ApplyUntil<INumericCell> (castCells,
                                                               f,
                                                               c);
                        Assert.AreEqual (cell.Item1.Value, 6);
                }
        }

        public static class IterToolTestAdditions
        {

                public static int Add (int number, int number2)
                {
                        return number + number2;
                }

                public static INumericCell Add (INumericCell c1,
                                                INumericCell c2)
                {
                        return c1.Add(c2);
                }

                public static bool GreaterEqual (int number, int comparison)
                {
                        if (number >= comparison) {
                                return true;
                        }
                        return false;
                }

                public static bool GreaterEqual (INumericCell c1,
                                                 INumericCell comparison)
                {
                        return c1.NumericValue > comparison.NumericValue;
                }
        }
}
