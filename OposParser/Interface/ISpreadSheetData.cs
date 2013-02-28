using System;
using System.Collections;
using System.Collections.Generic;

namespace OposParser.Interface
{
        /// <summary>
        /// Abstraction to the SpreadSheetDataSource.
        /// Normally this will interface to a currently running Excel application.
        /// Could, however also be used to interface to a library that can load
        /// data from an Excel-file or OpenOffice-Calc. 
        /// </summary>
        public interface ISpreadSheetData
        {
                /// <summary>
                /// Obtains the cells for the given range.
                /// The Column is denoted via letters ('A', 'B', ..., 'ZZ')
                /// The start and end row via numbers (1, ... n).
                /// </summary>
                /// <returns>
                /// A list of <see cref="OposParser.Interface.ICell"/> objects.
                /// </returns>
                /// <param name='column'>
                /// The column.
                /// </param>
                /// <param name='startRow'>
                /// The start row.
                /// </param>
                /// <param name='endRow'>
                /// The end row.
                /// </param>
                IList GetCells (string column,
		                          string startRow,
		                          string endRow);
                /// <summary>
                /// Writes the cells to the opened datasource.
                /// </summary>
                /// <param name='cells'>
                /// Cells.
                /// </param>
                void WriteCells (IList<ICell> cells);
        }
}

