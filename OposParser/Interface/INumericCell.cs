using System;

namespace OposParser.Interface
{
        public interface INumericCell: IComparableCell
        {
                INumericCell Add (INumericCell c1, INumericCell c2);
                INumericCell Substract (INumericCell c1, INumericCell c2);
                INumericCell Multiply (INumericCell c1, INumericCell c2);
                INumericCell Divide (INumericCell c1, INumericCell c2);
        }
}

