using System;

namespace OposParser
{
	/// <summary>
	/// Introduces an abstraction to the cells returned from the
	/// spreadsheet-datasource.
	/// </summary>
		public interface ICell<T>
		{
				string Row { get; set; }

				int Column { get; set; }

				T Value { get; set; }
		}
}

