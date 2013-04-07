using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                public void TestApplyUntilNonGenericReference ()
                {
                        ICollection<INumericCell> castCells = null;
                        ICollection<ICell> cells = NumericTestCells ();
                        if (cells.First() is INumericCell ) {
                                var tmpEnum = (from cl in cells
                                               select (INumericCell) cl);
                                castCells = tmpEnum.ToList();
                        }
                        var c = GreaterThanCondition (10);
                        Func<INumericCell, INumericCell, INumericCell> f = IterToolTestAdditions.Add;
                        var cell = IterTools.ApplyUntil<INumericCell> (castCells,
                                                               f,
                                                               c);
                        Assert.AreEqual (cell.Item1.Value, 4);
                }

                [Test]
                public void TestOposParserOperations () {
                        // SETUP
                        ICollection<INumericCell> castCells = null;
                        ICollection<ICell> cells = NumericTestCells ();
                        if (cells.First() is INumericCell ) {
                                var tmpEnum = (from cl in cells
                                               select (INumericCell) cl);
                                castCells = tmpEnum.ToList();
                        }
                        var condition = GreaterThanCondition (10);

                        // TESTS and ASSERTS
                        Func<INumericCell, INumericCell, INumericCell> f = Operations.Add;
                        var cell = IterTools.ApplyUntil<INumericCell> (castCells,
                                                                       f,
                                                                       condition);
                        Assert.AreEqual (cell.Item1.Value, 4);

                        cell = IterTools.ApplyUntil<INumericCell> (castCells,
                                                                   Operations.Multiply,
                                                                   condition);
                        Assert.AreEqual (2, cell.Item1.Value);

                        cell = IterTools.ApplyUntil<INumericCell> (castCells,
                                                                   Operations.Divide,
                                                                   condition);
                        Assert.AreEqual (0.5, cell.Item1.Value);

                        cell = IterTools.ApplyUntil<INumericCell> (castCells,
                                                                   Operations.Substract,
                                                                   condition);
                        Assert.AreEqual (-2, cell.Item1.Value);
                }

                [Test]
                public void TestArithmeticOperationsWithConditionHit () {
                        ICollection<INumericCell> castCells = null;
                        ICollection<ICell> cells = NumericTestCells ();
                        if (cells.First() is INumericCell ) {
                                var tmpEnum = (from cl in cells
                                               select (INumericCell) cl);
                                castCells = tmpEnum.ToList();
                        }
                        Func<INumericCell, bool> condition = Comparisons.GreaterEqual(2);
                        Func<INumericCell, INumericCell, INumericCell> f = Operations.Add;
                        var cell = IterTools.ApplyUntil<INumericCell> (castCells,
                                                                       f,
                                                                       condition);
                        Assert.AreEqual (2, cell.Item2.Value);
                        Assert.AreEqual (1, cell.Item1.Value);
                        Assert.AreEqual (2, cell.Item1.Row);
                        Assert.AreEqual ("B", cell.Item1.Column);
                }

                [Test]
                public void TestStringOperation () {
                        ICollection<IComparableCell> cells = new List<IComparableCell> {
                                new ComparableExcelCell("one", 1, 1),
                                new ComparableExcelCell("two", 1, 2),
                                new ComparableExcelCell("three", 1, 3)
                        };
                        Func<IComparableCell, bool> condition = Comparisons.Contains ("two");
                        var cell = cells.Where (c => condition(c));
                        Assert.AreEqual ("two", cell.First().Value);
                }

                static ICollection<ICell> NumericTestCells ()
                {
                        ICollection<ICell> cells = new List<ICell> {
                                new NumericCell (1, 1, 1),
                                new NumericCell (1, 2, 2),
                                new NumericCell (2, 1, 3)
                        };
                        return cells;
                }

                static Func<INumericCell, bool> GreaterThanCondition (int c)
                {
                        return IterTools.PartiallyApply<INumericCell, bool> (IterToolTestAdditions.GreaterEqual,
                                                                             new NumericCell (c, int.MaxValue, int.MaxValue));
                }
        }

}
