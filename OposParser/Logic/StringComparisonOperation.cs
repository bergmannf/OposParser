
using System;

namespace OposParser.Logic
{
	/// <summary>
	/// Description of StringComparisonOperation.
	/// </summary>
	public class StringComparisonOperation
	{
		public StringComparisonOperation()
		{}
		
		public bool Compare(string haystack, string needle) {
			return true;
		}
		
		public bool CompareFuzzy(string haystack, string needle) {
			return true;
		}
		
		public string ToString() {
			return "Text-Vergleich";
		}
	}
}
