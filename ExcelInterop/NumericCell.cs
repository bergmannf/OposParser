using System;
using OposParser.Interface;

namespace ExcelInterop
{
        public class NumericCell: ExcelCell, INumericCell
        {
                public new object Value {
                        get {
                                return this.NumericValue;
                        }
                        set {
                                if (ExcelCell.IsNumeric(value)) {
                                        NumericValue = (double) value;
                                }
                        }
                }

                /// <summary>
                /// Numeric value encompassed by this cell.
                /// </summary>
                /// <value>The value.</value>
                public double NumericValue { get; set; }

                /// <summary>
                /// Creates a new cell from values obtained via COM-interop.
                /// (column is an integer not the string "A", "B", ...)
                /// </summary>
                /// <param name="value">Value of the numeric cell.</param>
                /// <param name="column">Column of the numeric cell.</param>
                /// <param name="row">Row of the numeric cell.</param>
                public NumericCell (double value, int column, int row):
                        this(value, ExcelCell.ConvertColumnToString(column), row)
                {
                }

                /// <summary>
                /// Creates a new cell from the given values.
                /// </summary>
                /// <param name="value">Value.</param>
                /// <param name="column">Column.</param>
                /// <param name="row">Row.</param>
                public NumericCell (double value, string column, int row)
                {
                        this.NumericValue = value;
                        this.Column = column;
                        this.Row = row;
                }

                #region INumericCell implementation

                public INumericCell Add (INumericCell c1)
                {
                        double newValue = this.NumericValue + c1.NumericValue;
                        string newColumn = this.HigherColumn (c1);
                        int newRow = HigherRow (c1);
                        INumericCell result = new NumericCell (newValue, newColumn, newRow);
                        return result;
                }

                public INumericCell Substract (INumericCell c1)
                {
                        double newValue = this.NumericValue - c1.NumericValue;
                        string newColumn = HigherColumn (c1); 
                        int newRow = HigherRow (c1);
                        INumericCell result = new NumericCell (newValue, newColumn, newRow);
                        return result;
                }

                public INumericCell Multiply (INumericCell c1)
                {
                        double newValue = this.NumericValue * c1.NumericValue;
                        string newColumn = HigherColumn (c1); 
                        int newRow = HigherRow (c1);
                        INumericCell result = new NumericCell (newValue, newColumn, newRow);
                        return result;
                }

                public INumericCell Divide (INumericCell c1)
                {
                        double newValue = this.NumericValue / c1.NumericValue;
                        string newColumn = HigherColumn (c1); 
                        int newRow = HigherRow (c1);
                        INumericCell result = new NumericCell (newValue, newColumn, newRow);
                        return result;
                }

                #endregion

                #region IComparableCell implementation

                public bool Matches (IComparableCell c1)
                {
                        return this.Equals (c1);
                }

                #endregion

                #region IComparable implementation

                public int CompareTo (object obj)
                {
                        throw new NotImplementedException ();
                }

                #endregion
        }
}

