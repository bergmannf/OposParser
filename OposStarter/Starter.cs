using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using ExcelDna.Integration;
using OposUi;

namespace OposParser
{
        /// <summary>
        /// Description of Starter.
        /// </summary>
        public class Starter
        {
                static Thread appThread;
                private delegate void UiStartDelegate ();
		
                /// <summary>
                /// This is the function called from Excel to open the UI.
                /// </summary>
                [ExcelCommand(MenuName="OposApplications", MenuText="OposParser")]
                public static void OposParser ()
                {
                        appThread = new Thread (OpenUi);
                        appThread.SetApartmentState (ApartmentState.STA);
                        appThread.IsBackground = true;
                        appThread.Start ();
                }
		
                /// <summary>
                /// Either open a new window or reactivates the old window.
                /// </summary>
                /// <remarks>
                /// This is necessary as the application will run inside the Excel
                /// AppDomain and can not be closed completely.
                /// However to allow closing and reopening of the application the windows
                /// will be hidden when the application is "closed".
                /// </remarks>
                private static void OpenUi ()
                {
                        string[] nullArgs = new string[0];
                        UiMain.Main (nullArgs);
                }
        }
}
