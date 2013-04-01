using System;
using OposParser.Interface;

namespace OposParser
{
        public static class Comparators
        {
                #region Numeric comparisons
                public static Func<INumericCell, bool> GreaterEqual (double number) {
                        Func<INumericCell, bool> greaterEqual = 
                                (c) => c.NumericValue >= number;
                        return greaterEqual;
                }

                public static Func<INumericCell, bool> Greater (double number) {
                        Func<INumericCell, bool> greaterEqual =
                                (c) => c.NumericValue > number;
                        return greaterEqual;
                }

                public static Func<INumericCell, bool> LessEqual (double number) {
                        Func<INumericCell, bool> greaterEqual =
                                (c) => c.NumericValue <= number;
                        return greaterEqual;
                }

                public static Func<INumericCell, bool> Less (double number) {
                        Func<INumericCell, bool> greaterEqual =
                                (c) => c.NumericValue < number;
                        return greaterEqual;
                }

                public static Func<INumericCell, bool> Equal (double number) {
                        Func<INumericCell, bool> greaterEqual =
                                (c) => c.NumericValue == number;
                        return greaterEqual;
                }
                #endregion

                #region String comparsions
                public static Func<IComparableCell, bool> Contains (string text) {
                        Func<IComparableCell, bool> contains =
                                (c) => {
                                string s = c.Value as string;
                                if (s != null) {
                                        return s.Contains (text);
                                } else {
                                        return false;
                                }
                        };
                        return contains;
                }
                #endregion
        }
}

