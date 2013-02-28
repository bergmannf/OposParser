using System;
using System.Collections.Generic;
using OposParser.Logic;
using OposParser.Interface;

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
                
                private IList<IOperation> _availableComparisonOperations;

                public IList<IOperation> AvailableComparisonOperations {
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

