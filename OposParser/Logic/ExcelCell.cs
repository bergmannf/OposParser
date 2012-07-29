using System;

/// <summary>
/// Store the value of an excel cell in a special object?
/// </summary>
public class ExcelCell
{
#region Properties
  private string _cellRow;
  private string _cellColumn;
#endregion

#region Ctor & Destructor
  /// <summary>
  /// Standard Constructor
  /// </summary>
  public ExcelCell(object originalCell)
  {
  this._originalCell = originalCell;
  this._cellRow = originalCell.Row;
  this._cellColumn = originalCell.Column;
}
#endregion


}