using System;

namespace OposParser
{
        public interface IOperation<T>
        {
                ICell<T> Execute (ICell<T> c1, ICell<T> c2);
        }
}

