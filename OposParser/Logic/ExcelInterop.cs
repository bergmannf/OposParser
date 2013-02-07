﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public IList ObtainCells (string column,
                              string startRow,
                              string endRow)
    {
      // Generate the start and endpoint;
      string excelRangeStart = column + startRow;
      string excelRangeEnd = column + endRow;
      IList cellValues = new List<ExcelCell<object>>();

      Worksheet activeSheet = (Worksheet)this._excelApplication.ActiveSheet;
      Range cells = activeSheet.get_Range (excelRangeStart, excelRangeEnd);
      if (cells != null) {
        Type t = DetermineDataType(cells);
        if (t == typeof(int)||
            t == typeof(double))
          {
            cellValues = CreateDoubleCells(cells);
          }
        else if (t == typeof(string))
          {
            cellValues = CreateStringCells(cells);
          }
        else if (t == typeof(DateTime))
          {
            cellValues = CreateDateTimeCells(cells);
          }
        else {
        	throw new ArgumentException("The major amount of cells can not be processed " +
        	                            "by the application.");
        }
      }
      return cellValues;
    }

  

    public void WriteCells(IList<ExcelCell<object>> cells) {
      Worksheet activeSheet = null;
      Range excelCell = null;
      try {
        // Prevent excel from display the update for each cell;
        this._excelApplication.ScreenUpdating = false;

        activeSheet = (Worksheet)this._excelApplication.ActiveSheet;
        foreach (ExcelCell<object> cell in cells) {
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

    private static IList CreateDateTimeCells(Range cells)
    {
      IList datetimeCells = new List<ExcelCell<DateTime>>();
      foreach (Range cell in cells.Cells) {
        int row = cell.Row;
        int col = cell.Column;
        object val = cell.Value;
        var c = ExcelCell<DateTime>.Create(row, col, val);
        datetimeCells.Add (c);
      }
      return datetimeCells;
    }
    
    private static IList CreateStringCells(Range cells)
    {
      IList stringCells = new List<ExcelCell<string>>();
      foreach (Range cell in cells.Cells) {
        int row = cell.Row;
        int col = cell.Column;
        object val = cell.Value;
        var c = ExcelCell<string>.Create(row, col, val);
        stringCells.Add (c);
      }
      return stringCells;
    }
    
    private static IList CreateDoubleCells(Range cells)
    {
      IList doubleCells = new List<ExcelCell<double>>();
      foreach (Range cell in cells.Cells) {
        int row = cell.Row;
        int col = cell.Column;
        object val = cell.Value;
        var c = ExcelCell<double>.Create(row, col, val);
        doubleCells.Add (c);
      }
      return doubleCells;
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
          logger.Info("A null value was encoutered in Cell: {0}{1}",
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
        throw new ArgumentException("All cells were empty. Can not proceed");
      Type maxUsedType = typeCounts.Aggregate ((l, r) => l.Value > r.Value ? l : r).Key;
      return maxUsedType;
    }
  }

  public class InteropException : Exception {
    public InteropException(string message) : base(message)
    {}
  }

  public class ExcelCell<T> {
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

    private T _value;

    /// <summary>
    ///
    /// </summary>
    public T Value {
      get { return _value; }
      set { _value = value; }
    }

    /// <summary>
    /// </summary>
    public ExcelCell(int row, int column, T val)
    {
      Row = ExcelCell<T>.ConvertRowToString(row);
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

    /// <summary>
    /// Creates a new cell to hold datetime values.
    /// </summary>
    /// <returns><c>ExcelCell<string></c></returns>
    public static ExcelCell<T> Create(int row, int column, object value)
    {
      T castedValue = (T) value;
      ExcelCell<T> cell = new ExcelCell<T>(row,
                                           column,
                                           castedValue);
      return cell;
    }

    /// <summary>
    /// Determines wether the cell is a numeric cell.
    /// </summary>
    /// <value></value>
    public static bool IsNumeric(object val)
    {
      return (val.GetType() == typeof(int) ||
              val.GetType() == typeof(Int16) ||
              val.GetType() == typeof(Int32) ||
              val.GetType() == typeof(Int64) ||
              val.GetType() == typeof(double));
    }
  }
}