using System;
using System.Collections.Generic;
using System.Linq;

namespace OposParser.Logic
{
  public class AdditionOperation
  {
#region Ctor & Destructor
    /// <summary>
    /// Creates an addition operation.
    /// </summary>
    public AdditionOperation()
    {
    }
#endregion
    
    /// <summary>
    /// Description
    /// </summary>
    public void Execute(int previousValue, int currentValue)
    {
    	IEnumerable<int> numbers = new List<int>();
    	numbers.Sum();
    }

  }
}