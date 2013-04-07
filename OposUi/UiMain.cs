using System;
using Gtk;
using OposParser.Logic;
using OposParser.Interface;

namespace OposUi
{
        public class UiMain
        {
                public static void Main (string[] args)
                {
                        Console.WriteLine ("Starting UI");
                        Application.Init ();
                        ISpreadSheetData ds = null;
                        try {
                                ds = new ExcelInterop.ExcelDatasource ();
                        } catch {
                                ds = null;
                        }
                        OposParserFacade parser = new OposParserFacade (ds);
                        MainWindowModel model = new MainWindowModel (parser);
                        MainWindow view = new MainWindow ();
                        MainWindowController controller = new MainWindowController (view, model);
                        view.Show ();
                        Application.Run ();
                }
        }
}
