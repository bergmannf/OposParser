using System;

namespace OposParser.Interface
{
        /// <summary>
        /// Introduces an abstraction to the cells returned from the
        /// spreadsheet-datasource.
        /// </summary>
        public interface ICell
        {
                object Value { get; set; }

                int Row { get; set; }

                string Column { get; set; }
        }
}

