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

        public static class IterToolTestAdditions
        {

                public static int Add (int number, int number2)
                {
                        return number + number2;
                }

                public static INumericCell Add (INumericCell c1,
                                                INumericCell c2)
                {
                        return c1.Add (c2);
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
