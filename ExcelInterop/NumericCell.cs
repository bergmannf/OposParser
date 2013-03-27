using System;
using OposParser.Interface;

namespace ExcelInterop
{
        public class NumericCell: INumericCell
        {
                private double _value;

                /// <summary>
                /// Numeric value encompassed by this cell.
                /// </summary>
                /// <value>The value.</value>
                public double Value {
                        get {
                                return _value;
                        }
                        set {
                                _value = value;
                        }
                }

                public NumericCell ()
                {
                }

                #region INumericCell implementation

                public INumericCell Add (INumericCell c1, INumericCell c2)
                {
                        throw new NotImplementedException ();
                }

                public INumericCell Substract (INumericCell c1, INumericCell c2)
                {
                        throw new NotImplementedException ();
                }

                public INumericCell Multiply (INumericCell c1, INumericCell c2)
                {
                        throw new NotImplementedException ();
                }

                public INumericCell Divide (INumericCell c1, INumericCell c2)
                {
                        throw new NotImplementedException ();
                }

                #endregion

                #region IComparableCell implementation

                public bool Matches (IComparableCell c1)
                {
                        throw new NotImplementedException ();
                }

                #endregion

                #region IComparable implementation

                public int CompareTo (object obj)
                {
                        throw new NotImplementedException ();
                }

                #endregion

                #region ICell implementation

                public string Row {
                        get {
                                throw new NotImplementedException ();
                        }
                        set {
                                throw new NotImplementedException ();
                        }
                }

                public int Column {
                        get {
                                throw new NotImplementedException ();
                        }
                        set {
                                throw new NotImplementedException ();
                        }
                }

                public object Value {
                        get {
                                throw new NotImplementedException ();
                        }
                        set {
                                throw new NotImplementedException ();
                        }
                }

                #endregion
        }
}

