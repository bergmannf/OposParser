using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace OposParser.Logic {

	public class Converter
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();
		
		#region Ctor & Destructor
		/// <summary>
		/// This class can convert excel cells into
		/// objects used by later routines.
		/// </summary>
		public Converter ()
		{
		}
		
		/// <summary>
		/// Returns the type that is used most often in a range of cells.
		/// </summary>
		/// <returns>The predominant <c>Type</c> in the range of cells.</returns>
		public static Type DetermineDataType (IList<ExcelCell> excelCells)
		{
			IDictionary<Type, int> typeCounts = new Dictionary<Type, int> ();
			foreach (ExcelCell cell in excelCells) {
				if (cell.Value == null) {
					logger.Info("A null value was encoutered in Cell: {0}{1}", 
					            cell.Column, 
					            cell.Row);
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

		#endregion
	}
}