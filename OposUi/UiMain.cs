using System;
using Gtk;

namespace OposUi
{
        public class UiMain
        {
                public static void Main (string[] args)
                {
                        Console.WriteLine ("Starting UI");
                        Application.Init ();
                        MainWindow win = new MainWindow ();
                        win.Show ();
                        Application.Run ();
                }
        }
}
