using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
				this.Build ();
		}
		protected void CancelButtonClicked (object sender, EventArgs e)
		{
				Application.Quit ();
		}

}
