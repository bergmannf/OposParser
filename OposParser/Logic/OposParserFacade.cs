using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using OposParser.Interface;

namespace OposParser.Logic
{
        /// <summary>
        /// Facade for the OposParser Logic.
        /// </summary>
        public class OposParserFacade
        {
                private ISpreadSheetData _dataSource;

                /// <summary>
                /// Creates a new facade for the given datasource.
                /// </summary>
                /// <param name="dataSource">The data source to use.</param>
                public OposParserFacade (ISpreadSheetData dataSource)
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

                public ICollection<string> GetAvailableComparisonsForType (Type value)
                {
                        throw new NotImplementedException ();
                }

                /// <summary>
                /// Attempts to infer the type of cells present by obtaining
                /// the first 30 cells and counting the possible types.
                /// </summary>
                /// <returns>The cell type for column.</returns>
                /// <param name="column">The column to use.</param>
                public Type InferCellTypeForColumn (string column) {
                        string startRow = "1";
                        string endRow = "30";
                        ICollection<ICell> cells = _dataSource.GetCells (column, startRow, endRow);
                        IDictionary<Type, int> typeCounts = new Dictionary<Type, int>();
                        foreach (ICell cell in cells) {
                                int oldValue = 0;
                                if (typeCounts.TryGetValue(cell.GetType(), out oldValue)) {
                                    typeCounts.Add(cell.GetType(), oldValue + 1);
                                } else {
                                        typeCounts.Add (cell.GetType(), 0);
                                }
                        }
                        int max = typeCounts.Max (k => k.Value);
                        return typeCounts.Where(k => k.Value.Equals(max)).FirstOrDefault().Key;
                }
        }
}