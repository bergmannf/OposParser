using System;
using System.Text.RegularExpressions;
using Gtk;
using System.Collections.Generic;

namespace OposUi
{
        public partial class MainWindow: Gtk.Window
        {
                private MainWindowModel _model;

                #region controller-required events

                public event EventHandler<StringEventArgs> ComparisonChanged;
                public event EventHandler<EventArgs> OperationChanged;
                public event EventHandler<StringEventArgs> ColumnChanged;
                public event EventHandler<StringEventArgs> EndRowChanged;
                public event EventHandler<StringEventArgs> StartRowChanged;
                public event EventHandler<StringEventArgs> ValueChanged;
                public event EventHandler<TypeEventArgs> TypeChanged;

                #endregion

                public MainWindow (): base (Gtk.WindowType.Toplevel)
                {
                        this.Build ();
                }

                public void DisplayComparisons (ICollection<string> comparisons)
                {
                        foreach (string comparison in comparisons) {
                                comboboxComp.InsertText(0, comparison);
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

                #region Validators

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
                                StartRowChanged(this, new StringEventArgs(startRow.Text));
                        }
                }

                protected void EndRowFocusOut (object o, FocusOutEventArgs args)
                {
                        Entry endRow = o as Entry;
                        if (endRow != null) {
                                EndRowChanged(this, new StringEventArgs(endRow.Text));
                        }
                }

                protected void ColumnFocusOut (object o, FocusOutEventArgs args)
                {
                        Entry startColumn = o as Entry;
                        if (startColumn != null) {
                                ColumnChanged (this, new StringEventArgs(startColumn.Text));
                        }
                }

                protected void ComparisonValueFocusOut (object o, FocusOutEventArgs args)
                {
                        Entry compEntry = o as Entry;
                        if (compEntry != null) {
                                ComparisonChanged(this, new StringEventArgs(compEntry.Text));
                        }
                }

                public void DisplayErrorMessages (ICollection<string> messages)
                {
                        errorTextView.Buffer.Text = "";
                        foreach (string message in messages) {
                                DisplayErrorMessage(message);
                        }
                }
        
                protected void OnOkButtonClicked (object sender, EventArgs e)
                {
                        string startColumn = entryColumnStart.Text;
                        string startRow = entryRowStart.Text;
                        string endRow = entryRowEnd.Text;
                }
        }
}
