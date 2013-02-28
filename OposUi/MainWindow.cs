using System;
using System.Text.RegularExpressions;
using Gtk;

namespace OposUi
{
        public partial class MainWindow: Gtk.Window
        {
                private MainWindowController _controller;
                private MainWindowModel _model;
                /// <summary>
                /// All rows must be simple numbers.
                /// </summary>
                private Regex RowRegex = new Regex (@"^\d+$");
                const string InvalidRowMessage = "Eine Zeilenbezeichnung besteht nur aus Zahlen.";

                /// <summary>
                /// All columns must be simple letters.
                /// </summary>
                private Regex ColumnRegex = new Regex (@"^\w+$");
                const string InvalidColumnMessage = "Eine Spaltenbezeichnung besteht nur aus Buchstaben.";

                public MainWindow (): base (Gtk.WindowType.Toplevel)
                {
                        this.Build ();
                }

        #region Validators

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
        
                public void ChangeOkButtonEnabledState (bool isEnabled)
                {
                        buttonOk.Sensitive = isEnabled;
                }

        #endregion

                protected void CancelButtonClicked (object sender, EventArgs e)
                {
                        Application.Quit ();
                }

                protected void StartRowFocusOut (object o, FocusOutEventArgs args)
                {
                        Entry startRow = o as Entry;
                        if (startRow != null) {
                                string text = startRow.Text;
                                bool valid = ValidateRow (text);
                                if (valid) {
                                        startRowErrorImage.Visible = false;
                                        HideErrorMessage ();
                                } else {
                                        startRowErrorImage.Visible = true;
                                        DisplayErrorMessage (InvalidRowMessage);
                                }
                        }
                }

                protected void EndRowFocusOut (object o, FocusOutEventArgs args)
                {
                        Entry startRow = o as Entry;
                        if (startRow != null) {
                                string text = startRow.Text;
                                bool valid = ValidateRow (text);
                                if (valid) {
                                        endRowErrorImage.Visible = false;
                                        HideErrorMessage ();
                                } else {
                                        endRowErrorImage.Visible = true;
                                        DisplayErrorMessage (InvalidRowMessage);
                                }
                        }
                }

                protected void StartColumnFocusOut (object o, FocusOutEventArgs args)
                {
                        Entry startColumn = o as Entry;
                        if (startColumn != null) {
                                string text = startColumn.Text;
                                bool valid = ValidateColumn (text);
                                if (valid) {
                                        startColumnErrorImage.Visible = false;
                                        HideErrorMessage ();
                                } else {
                                        startColumnErrorImage.Visible = true;
                                        DisplayErrorMessage (InvalidColumnMessage);
                                }
                        }
                }

                protected void EndColumnFocusOut (object o, FocusOutEventArgs args)
                {
                        Entry endColumn = o as Entry;
                        if (endColumn != null) {
                                string text = endColumn.Text;
                                bool valid = ValidateColumn (text);
                                if (valid) {
                                        endColumnErrorImage.Visible = false;
                                        HideErrorMessage ();
                                } else {
                                        endColumnErrorImage.Visible = true;
                                        DisplayErrorMessage (InvalidColumnMessage);
                                }
                        }
                }

                protected void ComparisonValueFocusOut (object o, FocusOutEventArgs args)
                {
                        Entry compEntry = o as Entry;
                        if (compEntry != null) {
                    
                        }
                }

                private void DisplayErrorMessage (string message)
                {
                        string previousText = errorTextView.Buffer.Text;
                        string newMessage = null;
                        if (!string.IsNullOrEmpty (previousText)) {
                                newMessage = string.Join (Environment.NewLine, previousText, message);
                        } else {
                                newMessage = message;
                        }
                        Gdk.Color red = new Gdk.Color (255, 0, 0);
                        ErrorTextViewScrollWindow.ModifyBg (StateType.Normal, red);
                        errorTextView.Visible = true;
                        errorTextView.Buffer.Text = newMessage;
                }

                private void HideErrorMessage ()
                {
                        ErrorTextViewScrollWindow.ModifyBg (StateType.Normal);
                        errorTextView.Visible = false;
                }
        
                protected void OnOkButtonClicked (object sender, EventArgs e)
                {
                        throw new NotImplementedException ();
                }
        }
}
