using System;

namespace OposParser.Interface
{
        /// <summary>
        /// Operation interface to inherit for all operations performable
        /// to the Cells.
        /// </summary>
        public interface IOperation
        {
                ICell Execute (ICell c1, ICell c2);
        }
}

