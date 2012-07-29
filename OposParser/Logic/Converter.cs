using System;
using System.Collections.Generic;
using System.Linq;

public class Converter
{
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
	public static Type DetermineDataType (IList<object> excelCells)
	{
		IDictionary<Type, int> typeCounts = new Dictionary<Type, int> ();
		foreach (object cell in excelCells) {
			if (cell == null) {
				Console.WriteLine("A nullvalue was encountered");
			}
			Type cellType = cell.GetType ();
			if (typeCounts.ContainsKey (cellType)) {
				typeCounts [cellType] += 1;
			} else {
				typeCounts.Add (cellType, 1);
			}
		}
		Type maxUsedType = typeCounts.Aggregate ((l, r) => l.Value > r.Value ? l : r).Key;
		return maxUsedType;
	}

	#endregion
}