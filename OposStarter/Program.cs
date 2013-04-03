using System;
using System.Threading;
using System.Windows;

using OposParser;

namespace OposStarter
{
        /// <summary>
        /// This is just a dummy entry point for debugging the application
        /// without running an Excel-Instance.
        /// </summary>
        public class Program
        {
                public static void Main ()
                {
                        Starter.OposParser ();
                        // Wait until the UI is closed.
                        Starter.AppThread.Join ();
                }
        }
}