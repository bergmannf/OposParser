using System;

namespace OposUi
{
        public class TypeEventArgs: EventArgs
        {
                public Type Value {
                        get;
                        set;
                }

                public TypeEventArgs (Type t)
                {
                        this.Value = t;
                }
        }
}

