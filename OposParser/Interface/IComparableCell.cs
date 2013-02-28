using System;

namespace OposParser.Interface
{
        public interface IComparableCell : ICell, IComparable
        {
                bool Matches (IComparableCell c1);
        }
}

