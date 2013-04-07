using System;

namespace OposUi
{
        public class StringEventArgs : EventArgs
        {
                public string Value { get; set; }

                public StringEventArgs(string elem)
                {
                        this.Value = elem;
                }

        }
}

