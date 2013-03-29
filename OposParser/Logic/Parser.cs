using System;
using System.Collections.Generic;
using System.Collections;
using OposParser.Interface;

namespace OposParser.Logic
{
        /// <summary>
        /// Facade for the OposParser Logic.
        /// </summary>
        public class Parser
        {
                private ISpreadSheetData _dataSource;
                
                /// <summary>
                /// Creates a new facade for the given datasource.
                /// </summary>
                /// <param name="dataSource">The data source to use.</param>
                public Parser (ISpreadSheetData dataSource)
                {
                        _dataSource = dataSource;
                }
                
                public IList<ICell> GetCells (string column,
                                              string startRow,
                                              string endRow)
                {
                        return _dataSource.GetCells (column, startRow, endRow);
                }
                
                public void WriteCells (IList<ICell> cells)
                {
                        _dataSource.WriteCells (cells);
                }
                
                /// <summary>
                /// Applies the operation to the range.
                /// Returns the List of cells for which the operation fulfilled
                /// the condition.
                /// </summary>
                /// <returns>The operation to range.</returns>
                /// <param name="op">Operation to apply.</param>
                /// <param name="cells">Cells to apply the operation to.</param>
                /// <param name="condition">Condition to fulfill.</param>
                public IList<ICell> ApplyOperationToRange (IOperation op,
                                                           IList<ICell> cells,
                                                           string condition)
                {
                        throw new NotImplementedException ();
                }
        }
}