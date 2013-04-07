using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OposUi
{
        public class MainWindowController
        {
                private MainWindow _mainWindow;
                private MainWindowModel _model;
                
                /// <summary>
                /// All rows must be simple numbers.
                /// </summary>
                private Regex RowRegex = new Regex (@"^\d+$");
                
                /// <summary>
                /// All columns must be simple letters.
                /// </summary>
                private Regex ColumnRegex = new Regex (@"^\w+$");

                const string InvalidComparisonMessage = "Der ausgewählte Vergleich ist nicht möglich.";
                const string InvalidRowMessage = "Eine Zeilenbezeichnung besteht nur aus Zahlen.";
                const string InvalidColumnMessage = "Eine Spaltenbezeichnung besteht nur aus Buchstaben.";

                public ISet<string> Errors { get; private set; }
                
                public string SelectedColumn { get; set; }

                public string SelectedStartRow { get; set; }

                public string SelectedEndRow { get; set; }

                public MainWindowController (MainWindow mainWindow, MainWindowModel model)
                {
                        _mainWindow = mainWindow;
                        _model = model;

                        Errors = new SortedSet<string> ();

                        RegisterEvents ();
                }

                void RegisterEvents ()
                {
                        _mainWindow.ColumnChanged += OnColumnChanged;
                        _mainWindow.StartRowChanged += OnStartRowChanged;
                        _mainWindow.EndRowChanged += OnEndRowChanged;
                        _mainWindow.ComparisonChanged += OnComparisonChanged;
                        _mainWindow.OperationChanged += OnOperationChanged;
                }
                
                public bool RequiredFieldsFilled ()
                {
                        return false;
                }

                void OnColumnChanged (object sender, StringEventArgs columnChanged)
                {
                        if (!string.IsNullOrEmpty (columnChanged.Value)) {
                                this.SelectedColumn = columnChanged.Value;
                                bool valid = ValidateColumn (this.SelectedColumn);
                                if (valid) {
                                        // _mainWindow.startColumnErrorImage.Visible = false;
                                        Errors.Remove (InvalidColumnMessage);
                                } else {
                                        // startColumnErrorImage.Visible = true;
                                        this.Errors.Add (InvalidColumnMessage);
                                }
                        } else {
                                Errors.Add (InvalidColumnMessage);
                        }
                        _mainWindow.DisplayErrorMessages (Errors);
                }

                void OnStartRowChanged (object sender, StringEventArgs e)
                {
                        if (!string.IsNullOrEmpty (e.Value)) {
                                this.SelectedStartRow = e.Value;
                                bool valid = ValidateRow (this.SelectedStartRow);
                                if (valid) {
                                        // startRowErrorImage.Visible = false;
                                        Errors.Remove (InvalidRowMessage);
                                } else {
                                        // startRowErrorImage.Visible = true;
                                        this.Errors.Add (InvalidRowMessage);
                                }
                        } else {
                                this.Errors.Add (InvalidRowMessage);
                        }
                        _mainWindow.DisplayErrorMessages (Errors);
                }

                void OnEndRowChanged (object sender, StringEventArgs e)
                {
                        if (!string.IsNullOrEmpty (e.Value)) {
                                this.SelectedEndRow = e.Value;
                                bool valid = ValidateRow (this.SelectedEndRow);
                                if (valid) {
                                        // startRowErrorImage.Visible = false;
                                        Errors.Remove (InvalidRowMessage);
                                } else {
                                        // startRowErrorImage.Visible = true;
                                        this.Errors.Add (InvalidRowMessage);
                                }

                        }
                        else {
                                this.Errors.Add (InvalidRowMessage);
                        }
                        _mainWindow.DisplayErrorMessages (Errors);
                }

                void OnOperationChanged (object sender, EventArgs e)
                {
                        throw new NotImplementedException ();
                }

                void OnComparisonChanged (object sender, StringEventArgs e) 
                {
                        if (!string.IsNullOrEmpty (e.Value)) {

                        } else {
                                Errors.Add (InvalidComparisonMessage);
                        }
                        _mainWindow.DisplayErrorMessages (Errors);
                }

                void OnMajorTypeChanged (object sender, TypeEventArgs e) {
                        if (e.Value != null) {
                                ICollection<string> comparisons = _model.GetComparisonsForType(e.Value);
                                _mainWindow.DisplayComparisons (comparisons);
                        }
                }

                #region Validation
                
                /// <summary>
                /// Validates the row.
                /// </summary>
                /// <returns>
                /// The row.
                /// </returns>
                /// <param name='rowText'>
                /// If set to <c>true</c> row text.
                /// </param>
                public bool ValidateRow (string rowText)
                {
                        if (rowText != null && RowRegex.IsMatch (rowText)) {
                                return true;
                        } else {
                                return false;
                        }
                }
                
                /// <summary>
                /// Validates the column.
                /// </summary>
                /// <returns>
                /// The column.
                /// </returns>
                /// <param name='columnText'>
                /// If set to <c>true</c> column text.
                /// </param>
                public bool ValidateColumn (string columnText)
                {
                        if (columnText != null && ColumnRegex.IsMatch (columnText)) {
                                return true;
                        } else {
                                return false;
                        }
                }

                #endregion
        }
}

