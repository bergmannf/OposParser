using System;
using System.Collections.Generic;
using OposParser.Logic;

namespace OposUi
{
        public class MainWindowModel
        {
                #region Properties and Fields
                
                private MainWindowController _controller;
                
                private Parser _parser;
                
                private IList<ICell> _selectedCells;

                public IList<ICell> SelectedCells {
                        get {
                                return _selectedCells;
                        }
                        private set {
                                _selectedCells = value;
                        }
                }
                
                private IList<Operation> _availableComparisonOperations;

                public IList<Operation> AvailableComparisonOperations {
                        get {
                                return _availableComparisonOperations;
                        }
                        private set {
                                _availableComparisonOperations = value;
                        }
                }
                
                private Type _majorTypeInSelectedArea;

                public Type MajorTypeInSelectedArea {
                        get {
                                return _majorTypeInSelectedArea;
                        }
                        set {
                                _majorTypeInSelectedArea = value;
                        }
                }
                
                #endregion
        
                public MainWindowModel (MainWindowController controller)
                {
                        _controller = controller;
                }
        }
}

