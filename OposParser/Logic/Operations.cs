using System;
using OposParser.Logic;
using OposParser.Interface;

namespace OposParser
{
        public static class Operations
        {
                public static Func<INumericCell, INumericCell, INumericCell> Add
                {
                        get {
                                Func<INumericCell, INumericCell, INumericCell> f =
                                (c1, c2) => c1.Add (c2);
                                return f;
                        }
                }

                public static Func<INumericCell, INumericCell, INumericCell> Substract
                {
                        get {
                                Func<INumericCell, INumericCell, INumericCell> f =
                                (c1, c2) => c1.Substract (c2);
                                return f;
                        }
                }

                public static Func<INumericCell, INumericCell, INumericCell> Multiply
                {
                        get {
                                Func<INumericCell, INumericCell, INumericCell> f =
                                (c1, c2) => c1.Multiply (c2);
                                return f;
                        }
                }

                public static Func<INumericCell, INumericCell, INumericCell> Divide
                {
                        get {
                                Func<INumericCell, INumericCell, INumericCell> f =
                                (c1, c2) => c1.Divide (c2);
                                return f;
                        }
                }
        }
}

