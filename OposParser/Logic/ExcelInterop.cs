using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using ExcelDna;

namespace OposParser
{
	/// <summary>
	/// Provide an abstraction to the required functions from Excel.
	/// </summary>
	public class ExcelInterop
	{
		private Application _excelApplication;
		
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
		public IList<object> ObtainCells (string column, 
		                                  string startRow,
		                                  string endRow)
		{
			// Generate the start and endpoint;
			string excelRangeStart = column + startRow;
			string excelRangeEnd = column + endRow;
			IList<object> cellValues = new List<object> ();
			
			Worksheet activeSheet = (Worksheet)this._excelApplication.ActiveSheet;
			Range cells = activeSheet.get_Range (excelRangeStart, excelRangeEnd);
			if (cells != null) {
				foreach (Range cell in cells.Cells) {
					object val = cell.Value;
					cellValues.Add (val);
				}
			}
			return cellValues;
		}
	}
}