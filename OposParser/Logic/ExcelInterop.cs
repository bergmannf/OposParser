using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using ExcelDna;
using System.Runtime.InteropServices;
using NLog;

namespace OposParser
{
	/// <summary>
	/// Provide an abstraction to the required functions from Excel.
	/// </summary>
	public class ExcelInterop
	{
		private Application _excelApplication;
		
		private static Logger logger = LogManager.GetCurrentClassLogger();
		
		public static Application ActiveExcel {
			get {
				return (Application) ExcelDna.Integration.ExcelDnaUtil.Application;
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="OposParser.ExcelInterop"/> class.
		/// </summary>
		public ExcelInterop(Application excel) {
			// Acquire reference to currently running excel.
			this._excelApplication = excel;
		}
		
		/// <summary>
		/// Obtains the cells specified by the input parameters.
		/// </summary>
		/// <returns>
		/// The cells as a list of objects.
		/// </returns>
		/// <param name='column'>
		/// The column that contains the cells.
		/// </param>
		/// <param name='startRow'>
		/// The row to start.
		/// </param>
		/// <param name='endRow'>
		/// The row to stop.
		/// </param>
		public IList<ExcelCell> ObtainCells (string column,
		                                  string startRow,
		                                  string endRow)
		{
			// Generate the start and endpoint;
			string excelRangeStart = column + startRow;
			string excelRangeEnd = column + endRow;
			IList<ExcelCell> cellValues = new List<ExcelCell> ();
			
			Worksheet activeSheet = (Worksheet)this._excelApplication.ActiveSheet;
			Range cells = activeSheet.get_Range (excelRangeStart, excelRangeEnd);
			if (cells != null) {
				foreach (Range cell in cells.Cells) {
					int row = cell.Row;
					int col = cell.Column;
					Type dataType = cell.GetType();
					object val = cell.Value;
					var c = new ExcelCell(row, col, val);
					cellValues.Add (c);
				}
			}
			return cellValues;
		}
		
		public void WriteCells(IList<ExcelCell> cells) {
			Worksheet activeSheet = null;
			Range excelCell = null;
			try {
				// Prevent excel from display the update for each cell;
				this._excelApplication.ScreenUpdating = false;
				
				activeSheet = (Worksheet)this._excelApplication.ActiveSheet;
				foreach (ExcelCell cell in cells) {
					string row = cell.Row;
					int column = cell.Column;
					string accessIdentifier = row + column;
					excelCell = activeSheet.get_Range(accessIdentifier);
					excelCell.Value2 = cell.Value;
				}
				
				this._excelApplication.ScreenUpdating = true;
			} catch (COMException e) {
				logger.Error("COMException occured when writing cells: " + e.ToString());
				if (excelCell != null) 
					Marshal.ReleaseComObject(excelCell);
				if (activeSheet != null)
					Marshal.ReleaseComObject(activeSheet);
				_excelApplication.ScreenUpdating = true;
				Marshal.ReleaseComObject(_excelApplication);
				throw new InteropException("Something crashed in Excel.");
			}
		}
	}
	
	public class InteropException : Exception {
		public InteropException(string message) : base(message)
		{}
	}
	
	public class ExcelCell {
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
		
		public object Value {
			get { return _value; }
			set { _value = value; }
		}
		
		private Type _type;
		
		public Type Type {
			get { return _type; }
			set { _type = value; }
		}
		
		public ExcelCell(int row, int column, object val)
		{
			Row = ConvertRowToString(row);
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
		public static string ConvertRowToString(int rowAsInt) {
			if (rowAsInt <= 0) 
				throw new ArgumentOutOfRangeException("ExcelRows start at 1.");
			if (rowAsInt < AlphabetLength) {
				char asciiValueOfInt = (char)(rowAsInt - 1 + AsciiFirstCharacterValue);
				return Convert.ToString(asciiValueOfInt);
			} else {
				// Need to put characters in front
				int prefix = rowAsInt / AlphabetLength;
				int suffix = rowAsInt - prefix * (AlphabetLength - 1);
				return ConvertRowToString(prefix) + ConvertRowToString(suffix);
			}
			// Deducting 1 takes into account that Excel starts
			// indexing at 1 and not 0.
		}
	}
}