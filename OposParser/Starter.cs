using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using ExcelDna.Integration;

namespace OposParser
{
	/// <summary>
	/// Description of Starter.
	/// </summary>
	public class Starter
	{
		static Application application;
		static Window window;
		private  delegate void UiStartDelegate();
		
		/// <summary>
		/// This is the function called from Excel to open the UI.
		/// </summary>
		[ExcelFunction(Description="Start the Opos-Parser UI", 
		               Category="Useful Functions")]
		public static void OposParser()
		{
			if (application == null) {
				var appThread = new Thread(new ThreadStart(() =>
                    {
                    try {
                        application = new Application();
                        application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                        application.Run();
                    } catch (Exception e) {
                        MessageBox.Show(e.ToString());
                    }
                    }));
				appThread.SetApartmentState(ApartmentState.STA);
				appThread.Start();
				
				// Make sure that the application is created before continuing.
				while (application == null) {
					Thread.Yield();
				}
			}

			UiStartDelegate ui = OpenUi;
			application.Dispatcher.Invoke(ui);
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
		private static void OpenUi() {
			if (window == null) {
				window = new MainWindow();
				window.Closing += (s, e) => {
					window.Hide();
					e.Cancel = true;
				};
			}
			window.Show();
		}
	}
}
