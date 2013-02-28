using System;

namespace OposParser.Interface
{
        /// <summary>
        /// Introduces an abstraction to the cells returned from the
        /// spreadsheet-datasource.
        /// </summary>
        public interface ICell
        {
                string Row { get; set; }

                int Column { get; set; }

                object Value { get; set; }
        }
}

