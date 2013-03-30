using System;
using OposParser.Interface;

namespace ExcelInterop
{
        public class ComparableExcelCell: IComparableCell
        {
                #region IComparableCell implementation

                public bool Matches (IComparableCell c1)
                {
                        return this.Value.Equals (c1.Value);
                }

                #endregion

                #region IComparable implementation

                public int CompareTo (object obj)
                {
                        throw new NotImplementedException ();
                }

                #endregion

                #region ICell implementation

                public object Value { get; set; }

                public int Row { get; set; }

                public string Column { get; set; }

                #endregion

                /// <summary>
                /// Initializes a new instance of the <see cref="ExcelInterop.ComparableExcelCell"/> class.
                /// </summary>
                /// <param name="value">Value.</param>
                /// <param name="column">Column.</param>
                /// <param name="row">Row.</param>
                public ComparableExcelCell (object value, int column, int row):
                        this(value, ExcelCell.ConvertColumnToString(column), row)
                {
                }

                public ComparableExcelCell (object value, string column, int row)
                {
                        this.Value = value;
                        this.Column = column;
                        this.Row = row;
                }
        }
}

