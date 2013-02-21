using System;

namespace OposUi
{
        public class MainWindowController
        {
                private MainWindow _mainWindow;
        
                public MainWindowController (MainWindow mainWindow)
                {
                        _mainWindow = mainWindow;
                }
                
                public bool RequiredFieldsFilled ()
                {
                        return false;
                }
        }
}

