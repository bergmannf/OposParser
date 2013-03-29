using System;

namespace OposParser.Interface
{
        public interface INumericCell: IComparableCell
        {
                double NumericValue { get; set; }
                INumericCell Add (INumericCell c2);
                INumericCell Substract (INumericCell c2);
                INumericCell Multiply (INumericCell c2);
                INumericCell Divide (INumericCell c2);
        }
}

