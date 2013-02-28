using System;
using OposParser.Interface;

namespace OposParser.Logic
{
        public class AdditionOperation: IOperation
        {
                #region IOperation implementation

                public ICell Execute (ICell c1, ICell c2)
                {
                        throw new NotImplementedException ();
                }

                #endregion
                
                public INumericCell Add (INumericCell c1, INumericCell c2)
                {
                        return c1.Add (c2);
                }
        }
}

