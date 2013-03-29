using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using ExcelDna;
using System.Runtime.InteropServices;
using NLog;
using OposParser.Interface;

namespace ExcelInterop
{
        /// <summary>
        /// Provide an abstraction to the required functions from Excel.
        /// </summary>
        public class ExcelDatasource: ISpreadSheetData
        {
                private Application _excelApplication;
                private static Logger logger = LogManager.GetCurrentClassLogger ();

                public static Application ActiveExcel {
                        get {
                                return (Application)ExcelDna.Integration.ExcelDnaUtil.Application;
                        }
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="OposParser.ExcelInterop"/> class.
                /// </summary>
                public ExcelDatasource (Application excel)
                {
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
                public IList<ICell> GetCells (string column,
                                       string startRow,
                                       string endRow)
                {
                        // Generate the start and endpoint;
                        string excelRangeStart = column + startRow;
                        string excelRangeEnd = column + endRow;
                        IList<ICell> cellValues = new List<ICell> ();

                        Worksheet activeSheet = (Worksheet)this._excelApplication.ActiveSheet;
                        Range cells = activeSheet.get_Range (excelRangeStart, excelRangeEnd);
                        if (cells != null) {
                                Type t = DetermineDataType (cells);
                                foreach (Range cell in cells.Cells) {
                                        int row = cell.Row;
                                        int col = cell.Column;
                                        object val = cell.Value;
                                        ICell c = ExcelCell.CreateCell (val, row, col);
                                        cellValues.Add (c);
                                }
                        }
                        return cellValues;
                }

                public void WriteCells (IList<ICell> cells)
                {
                        Worksheet activeSheet = null;
                        Range excelCell = null;
                        try {
                                // Prevent excel from display the update for each cell;
                                this._excelApplication.ScreenUpdating = false;

                                activeSheet = (Worksheet)this._excelApplication.ActiveSheet;
                                foreach (ICell cell in cells) {
                                        string column = cell.Column;
                                        int row = cell.Row;
                                        string accessIdentifier = row + column;
                                        excelCell = activeSheet.get_Range (accessIdentifier);
                                        excelCell.Value2 = cell.Value;
                                }

                                this._excelApplication.ScreenUpdating = true;
                        } catch (COMException e) {
                                logger.Error ("COMException occured when writing cells: " + e.ToString ());
                                if (excelCell != null)
                                        Marshal.ReleaseComObject (excelCell);
                                if (activeSheet != null)
                                        Marshal.ReleaseComObject (activeSheet);
                                _excelApplication.ScreenUpdating = true;
                                Marshal.ReleaseComObject (_excelApplication);
                                throw new InteropException ("Something crashed in Excel.");
                        }
                }
                
                /// <summary>
                /// Returns the type that is used most often in a range of cells.
                /// </summary>
                /// <returns>The predominant <c>Type</c> in the range of cells.</returns>
                public static Type DetermineDataType (Range excelCells)
                {
                        IDictionary<Type, int> typeCounts = new Dictionary<Type, int> ();
                        foreach (Range cell in excelCells) {
                                if (cell.Value == null) {
                                        logger.Info ("A null value was encoutered in Cell: {0}{1}",
                      cell.Row,
                      cell.Column);
                                } else {
                                        Type cellType = cell.Value.GetType ();
                                        if (typeCounts.ContainsKey (cellType)) {
                                                typeCounts [cellType] += 1;
                                        } else {
                                                typeCounts.Add (cellType, 1);
                                        }
                                }
                        }
                        if (typeCounts.Count == 0)
                                throw new ArgumentException ("All cells were empty. Can not proceed");
                        Type maxUsedType = typeCounts.Aggregate ((l, r) => l.Value > r.Value ? l : r).Key;
                        return maxUsedType;
                }
        }

        public class InteropException : Exception
        {
                public InteropException (string message) : base(message)
                {
                }
        }

}