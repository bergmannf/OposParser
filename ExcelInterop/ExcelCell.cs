using System;
using OposParser.Interface;

namespace ExcelInterop
{
        public class ExcelCell: ICell
        {
                private string _row;
		
                public string Row {
                        get { return _row; }
                        set { _row = value; }
                }
                private int _column;
		
                public int Column {
                        get { return _column; }
                        set { _column = value; }
                }
		
                private object _value;
		
                /// <summary>
                ///
                /// </summary>
                public object Value {
                        get { return _value; }
                        set { _value = value; }
                }
		
                /// <summary>
                /// </summary>
                public ExcelCell (int row, int column, object val)
                {
                        Row = ExcelCell.ConvertRowToString (row);
                        Column = column;
                        Value = val;
                }
		
                private const int AsciiFirstCharacterValue = 65;
                private const int AlphabetLength = 27;
		
                /// <summary>
                /// This method will convert an integer representation returned by
                /// COM-interop into the normal representation in alphanumeric
                /// format: 1 -> A, 26 -> Z, 27 -> AA, asf.
                /// </summary>
                /// <param name="rowAsInt">The integere denoting the row
                /// number.</param>
                /// <returns>The string corresponding to the row.</returns>
                public static string ConvertRowToString (int rowAsInt)
                {
                        if (rowAsInt <= 0)
                                throw new ArgumentOutOfRangeException ("ExcelRows start at 1.");
                        if (rowAsInt < AlphabetLength) {
                                char asciiValueOfInt = (char)(rowAsInt - 1 + AsciiFirstCharacterValue);
                                return Convert.ToString (asciiValueOfInt);
                        } else {
                                // Need to put characters in front
                                int prefix = rowAsInt / AlphabetLength;
                                int suffix = rowAsInt - prefix * (AlphabetLength - 1);
                                return ConvertRowToString (prefix) + ConvertRowToString (suffix);
                        }
                        // Deducting 1 takes into account that Excel starts
                        // indexing at 1 and not 0.
                }
		
                /// <summary>
                /// Determines wether the cell is a numeric cell.
                /// </summary>
                /// <value></value>
                public static bool IsNumeric (object val)
                {
                        return (val.GetType () == typeof(int) ||
                                val.GetType () == typeof(Int16) ||
                                val.GetType () == typeof(Int32) ||
                                val.GetType () == typeof(Int64) ||
                                val.GetType () == typeof(double));
                }
        }
}

