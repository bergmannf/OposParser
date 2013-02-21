
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.VBox vbox2;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Table table3;
	private global::Gtk.ComboBox comboboxDatatype;
	private global::Gtk.ComboBox comboboxTextComp;
	private global::Gtk.Image compOperatorErrorImage;
	private global::Gtk.Image dataTypeErrorImage;
	private global::Gtk.Image endColumnErrorImage;
	private global::Gtk.Image endRowErrorImage;
	private global::Gtk.Entry entryColumnEnd;
	private global::Gtk.Entry entryColumnStart;
	private global::Gtk.Entry entryComparisonValue;
	private global::Gtk.Entry entryRowEnd;
	private global::Gtk.Entry entryRowStart;
	private global::Gtk.ScrolledWindow ErrorTextViewScrollWindow;
	private global::Gtk.TextView errorTextView;
	private global::Gtk.Label labelColEnd;
	private global::Gtk.Label labelColStart;
	private global::Gtk.Label labelComparisonValue;
	private global::Gtk.Label labelDatatype;
	private global::Gtk.Label labelRowEnd;
	private global::Gtk.Label labelRowStart;
	private global::Gtk.Label labelTextComp;
	private global::Gtk.Image startColumnErrorImage;
	private global::Gtk.Image startRowErrorImage;
	private global::Gtk.Image textCompErrorImage;
	private global::Gtk.HButtonBox hbuttonbox2;
	private global::Gtk.Button buttonOk;
	private global::Gtk.Button buttonCancel;
	private global::Gtk.Frame frame1;
	private global::Gtk.Alignment GtkAlignment;
	private global::Gtk.Table table4;
	private global::Gtk.RadioButton radioAddition;
	private global::Gtk.RadioButton radioDivision;
	private global::Gtk.RadioButton radioMultiplication;
	private global::Gtk.RadioButton radioSubtraction;
	private global::Gtk.Label frameOperations;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.BorderWidth = ((uint)(5));
		this.AllowShrink = true;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Homogeneous = true;
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.table3 = new global::Gtk.Table (((uint)(5)), ((uint)(6)), false);
		this.table3.Name = "table3";
		this.table3.RowSpacing = ((uint)(5));
		this.table3.ColumnSpacing = ((uint)(5));
		// Container child table3.Gtk.Table+TableChild
		this.comboboxDatatype = global::Gtk.ComboBox.NewText ();
		this.comboboxDatatype.Name = "comboboxDatatype";
		this.table3.Add (this.comboboxDatatype);
		global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table3 [this.comboboxDatatype]));
		w2.TopAttach = ((uint)(3));
		w2.BottomAttach = ((uint)(4));
		w2.LeftAttach = ((uint)(1));
		w2.RightAttach = ((uint)(2));
		w2.XOptions = ((global::Gtk.AttachOptions)(4));
		w2.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.comboboxTextComp = global::Gtk.ComboBox.NewText ();
		this.comboboxTextComp.Name = "comboboxTextComp";
		this.table3.Add (this.comboboxTextComp);
		global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table3 [this.comboboxTextComp]));
		w3.TopAttach = ((uint)(2));
		w3.BottomAttach = ((uint)(3));
		w3.LeftAttach = ((uint)(4));
		w3.RightAttach = ((uint)(5));
		w3.XOptions = ((global::Gtk.AttachOptions)(4));
		w3.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.compOperatorErrorImage = new global::Gtk.Image ();
		this.compOperatorErrorImage.Name = "compOperatorErrorImage";
		this.compOperatorErrorImage.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "stock_dialog-error", global::Gtk.IconSize.Menu);
		this.table3.Add (this.compOperatorErrorImage);
		global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table3 [this.compOperatorErrorImage]));
		w4.TopAttach = ((uint)(2));
		w4.BottomAttach = ((uint)(3));
		w4.LeftAttach = ((uint)(2));
		w4.RightAttach = ((uint)(3));
		w4.XOptions = ((global::Gtk.AttachOptions)(0));
		w4.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.dataTypeErrorImage = new global::Gtk.Image ();
		this.dataTypeErrorImage.Name = "dataTypeErrorImage";
		this.dataTypeErrorImage.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "stock_dialog-error", global::Gtk.IconSize.Menu);
		this.table3.Add (this.dataTypeErrorImage);
		global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table3 [this.dataTypeErrorImage]));
		w5.TopAttach = ((uint)(3));
		w5.BottomAttach = ((uint)(4));
		w5.LeftAttach = ((uint)(2));
		w5.RightAttach = ((uint)(3));
		w5.XOptions = ((global::Gtk.AttachOptions)(0));
		w5.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.endColumnErrorImage = new global::Gtk.Image ();
		this.endColumnErrorImage.Name = "endColumnErrorImage";
		this.endColumnErrorImage.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "stock_dialog-error", global::Gtk.IconSize.Menu);
		this.table3.Add (this.endColumnErrorImage);
		global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table3 [this.endColumnErrorImage]));
		w6.TopAttach = ((uint)(1));
		w6.BottomAttach = ((uint)(2));
		w6.LeftAttach = ((uint)(5));
		w6.RightAttach = ((uint)(6));
		w6.XOptions = ((global::Gtk.AttachOptions)(0));
		w6.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.endRowErrorImage = new global::Gtk.Image ();
		this.endRowErrorImage.Name = "endRowErrorImage";
		this.endRowErrorImage.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "stock_dialog-error", global::Gtk.IconSize.Menu);
		this.table3.Add (this.endRowErrorImage);
		global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table3 [this.endRowErrorImage]));
		w7.LeftAttach = ((uint)(5));
		w7.RightAttach = ((uint)(6));
		w7.XOptions = ((global::Gtk.AttachOptions)(0));
		w7.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.entryColumnEnd = new global::Gtk.Entry ();
		this.entryColumnEnd.CanFocus = true;
		this.entryColumnEnd.Name = "entryColumnEnd";
		this.entryColumnEnd.IsEditable = true;
		this.entryColumnEnd.InvisibleChar = '●';
		this.table3.Add (this.entryColumnEnd);
		global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table3 [this.entryColumnEnd]));
		w8.TopAttach = ((uint)(1));
		w8.BottomAttach = ((uint)(2));
		w8.LeftAttach = ((uint)(4));
		w8.RightAttach = ((uint)(5));
		w8.XOptions = ((global::Gtk.AttachOptions)(4));
		w8.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.entryColumnStart = new global::Gtk.Entry ();
		this.entryColumnStart.CanFocus = true;
		this.entryColumnStart.Name = "entryColumnStart";
		this.entryColumnStart.IsEditable = true;
		this.entryColumnStart.InvisibleChar = '●';
		this.table3.Add (this.entryColumnStart);
		global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table3 [this.entryColumnStart]));
		w9.TopAttach = ((uint)(1));
		w9.BottomAttach = ((uint)(2));
		w9.LeftAttach = ((uint)(1));
		w9.RightAttach = ((uint)(2));
		w9.XOptions = ((global::Gtk.AttachOptions)(4));
		w9.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.entryComparisonValue = new global::Gtk.Entry ();
		this.entryComparisonValue.CanFocus = true;
		this.entryComparisonValue.Name = "entryComparisonValue";
		this.entryComparisonValue.IsEditable = true;
		this.entryComparisonValue.InvisibleChar = '●';
		this.table3.Add (this.entryComparisonValue);
		global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table3 [this.entryComparisonValue]));
		w10.TopAttach = ((uint)(2));
		w10.BottomAttach = ((uint)(3));
		w10.LeftAttach = ((uint)(1));
		w10.RightAttach = ((uint)(2));
		w10.XOptions = ((global::Gtk.AttachOptions)(4));
		w10.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.entryRowEnd = new global::Gtk.Entry ();
		this.entryRowEnd.CanFocus = true;
		this.entryRowEnd.Name = "entryRowEnd";
		this.entryRowEnd.IsEditable = true;
		this.entryRowEnd.InvisibleChar = '●';
		this.table3.Add (this.entryRowEnd);
		global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table3 [this.entryRowEnd]));
		w11.LeftAttach = ((uint)(4));
		w11.RightAttach = ((uint)(5));
		w11.XOptions = ((global::Gtk.AttachOptions)(4));
		w11.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.entryRowStart = new global::Gtk.Entry ();
		this.entryRowStart.CanFocus = true;
		this.entryRowStart.Name = "entryRowStart";
		this.entryRowStart.IsEditable = true;
		this.entryRowStart.InvisibleChar = '●';
		this.table3.Add (this.entryRowStart);
		global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table3 [this.entryRowStart]));
		w12.LeftAttach = ((uint)(1));
		w12.RightAttach = ((uint)(2));
		w12.XOptions = ((global::Gtk.AttachOptions)(4));
		w12.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.ErrorTextViewScrollWindow = new global::Gtk.ScrolledWindow ();
		this.ErrorTextViewScrollWindow.Name = "ErrorTextViewScrollWindow";
		this.ErrorTextViewScrollWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child ErrorTextViewScrollWindow.Gtk.Container+ContainerChild
		this.errorTextView = new global::Gtk.TextView ();
		this.errorTextView.CanFocus = true;
		this.errorTextView.Name = "errorTextView";
		this.ErrorTextViewScrollWindow.Add (this.errorTextView);
		this.table3.Add (this.ErrorTextViewScrollWindow);
		global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table3 [this.ErrorTextViewScrollWindow]));
		w14.TopAttach = ((uint)(4));
		w14.BottomAttach = ((uint)(5));
		w14.RightAttach = ((uint)(6));
		w14.XOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.labelColEnd = new global::Gtk.Label ();
		this.labelColEnd.TooltipMarkup = "Wird keine Endspalte eingegeben wird nur eine Spalte genutzt.\nWird eine Endspalte angegeben wird die Operation auf die Spalten nacheinander angewendet.";
		this.labelColEnd.Name = "labelColEnd";
		this.labelColEnd.LabelProp = global::Mono.Unix.Catalog.GetString ("Spalte (End):");
		this.table3.Add (this.labelColEnd);
		global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table3 [this.labelColEnd]));
		w15.TopAttach = ((uint)(1));
		w15.BottomAttach = ((uint)(2));
		w15.LeftAttach = ((uint)(3));
		w15.RightAttach = ((uint)(4));
		w15.XOptions = ((global::Gtk.AttachOptions)(4));
		w15.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.labelColStart = new global::Gtk.Label ();
		this.labelColStart.Name = "labelColStart";
		this.labelColStart.LabelProp = global::Mono.Unix.Catalog.GetString ("Spalte (Start):");
		this.table3.Add (this.labelColStart);
		global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table3 [this.labelColStart]));
		w16.TopAttach = ((uint)(1));
		w16.BottomAttach = ((uint)(2));
		w16.XOptions = ((global::Gtk.AttachOptions)(4));
		w16.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.labelComparisonValue = new global::Gtk.Label ();
		this.labelComparisonValue.Name = "labelComparisonValue";
		this.labelComparisonValue.LabelProp = global::Mono.Unix.Catalog.GetString ("Vergleichswert:");
		this.table3.Add (this.labelComparisonValue);
		global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table3 [this.labelComparisonValue]));
		w17.TopAttach = ((uint)(2));
		w17.BottomAttach = ((uint)(3));
		w17.XOptions = ((global::Gtk.AttachOptions)(4));
		w17.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.labelDatatype = new global::Gtk.Label ();
		this.labelDatatype.Name = "labelDatatype";
		this.labelDatatype.LabelProp = global::Mono.Unix.Catalog.GetString ("Datentyp:");
		this.table3.Add (this.labelDatatype);
		global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table3 [this.labelDatatype]));
		w18.TopAttach = ((uint)(3));
		w18.BottomAttach = ((uint)(4));
		w18.XOptions = ((global::Gtk.AttachOptions)(4));
		w18.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.labelRowEnd = new global::Gtk.Label ();
		this.labelRowEnd.Name = "labelRowEnd";
		this.labelRowEnd.LabelProp = global::Mono.Unix.Catalog.GetString ("Zeile (Ende):");
		this.table3.Add (this.labelRowEnd);
		global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table3 [this.labelRowEnd]));
		w19.LeftAttach = ((uint)(3));
		w19.RightAttach = ((uint)(4));
		w19.XOptions = ((global::Gtk.AttachOptions)(4));
		w19.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.labelRowStart = new global::Gtk.Label ();
		this.labelRowStart.Name = "labelRowStart";
		this.labelRowStart.LabelProp = global::Mono.Unix.Catalog.GetString ("Zeile (Start):");
		this.table3.Add (this.labelRowStart);
		global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table3 [this.labelRowStart]));
		w20.XOptions = ((global::Gtk.AttachOptions)(4));
		w20.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.labelTextComp = new global::Gtk.Label ();
		this.labelTextComp.Name = "labelTextComp";
		this.labelTextComp.LabelProp = global::Mono.Unix.Catalog.GetString ("Textvergleich:");
		this.table3.Add (this.labelTextComp);
		global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.table3 [this.labelTextComp]));
		w21.TopAttach = ((uint)(2));
		w21.BottomAttach = ((uint)(3));
		w21.LeftAttach = ((uint)(3));
		w21.RightAttach = ((uint)(4));
		w21.XOptions = ((global::Gtk.AttachOptions)(4));
		w21.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.startColumnErrorImage = new global::Gtk.Image ();
		this.startColumnErrorImage.Name = "startColumnErrorImage";
		this.startColumnErrorImage.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "stock_dialog-error", global::Gtk.IconSize.Menu);
		this.table3.Add (this.startColumnErrorImage);
		global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.table3 [this.startColumnErrorImage]));
		w22.TopAttach = ((uint)(1));
		w22.BottomAttach = ((uint)(2));
		w22.LeftAttach = ((uint)(2));
		w22.RightAttach = ((uint)(3));
		w22.XOptions = ((global::Gtk.AttachOptions)(0));
		w22.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table3.Gtk.Table+TableChild
		this.startRowErrorImage = new global::Gtk.Image ();
		this.startRowErrorImage.Name = "startRowErrorImage";
		this.startRowErrorImage.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "stock_dialog-error", global::Gtk.IconSize.Menu);
		this.table3.Add (this.startRowErrorImage);
		global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.table3 [this.startRowErrorImage]));
		w23.LeftAttach = ((uint)(2));
		w23.RightAttach = ((uint)(3));
		w23.XOptions = ((global::Gtk.AttachOptions)(2));
		w23.YOptions = ((global::Gtk.AttachOptions)(6));
		// Container child table3.Gtk.Table+TableChild
		this.textCompErrorImage = new global::Gtk.Image ();
		this.textCompErrorImage.Name = "textCompErrorImage";
		this.textCompErrorImage.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "stock_dialog-error", global::Gtk.IconSize.Menu);
		this.table3.Add (this.textCompErrorImage);
		global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.table3 [this.textCompErrorImage]));
		w24.TopAttach = ((uint)(2));
		w24.BottomAttach = ((uint)(3));
		w24.LeftAttach = ((uint)(5));
		w24.RightAttach = ((uint)(6));
		w24.XOptions = ((global::Gtk.AttachOptions)(0));
		w24.YOptions = ((global::Gtk.AttachOptions)(4));
		this.hbox1.Add (this.table3);
		global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.table3]));
		w25.Position = 0;
		w25.Expand = false;
		w25.Fill = false;
		this.vbox2.Add (this.hbox1);
		global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
		w26.Position = 0;
		w26.Padding = ((uint)(5));
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbuttonbox2 = new global::Gtk.HButtonBox ();
		this.hbuttonbox2.Name = "hbuttonbox2";
		// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
		this.buttonOk = new global::Gtk.Button ();
		this.buttonOk.CanFocus = true;
		this.buttonOk.Name = "buttonOk";
		this.buttonOk.UseStock = true;
		this.buttonOk.UseUnderline = true;
		this.buttonOk.Label = "gtk-cancel";
		this.hbuttonbox2.Add (this.buttonOk);
		global::Gtk.ButtonBox.ButtonBoxChild w27 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.buttonOk]));
		w27.Expand = false;
		w27.Fill = false;
		// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
		this.buttonCancel = new global::Gtk.Button ();
		this.buttonCancel.CanFocus = true;
		this.buttonCancel.Name = "buttonCancel";
		this.buttonCancel.UseStock = true;
		this.buttonCancel.UseUnderline = true;
		this.buttonCancel.Label = "gtk-ok";
		this.hbuttonbox2.Add (this.buttonCancel);
		global::Gtk.ButtonBox.ButtonBoxChild w28 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.buttonCancel]));
		w28.Position = 1;
		w28.Expand = false;
		w28.Fill = false;
		this.vbox2.Add (this.hbuttonbox2);
		global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbuttonbox2]));
		w29.PackType = ((global::Gtk.PackType)(1));
		w29.Position = 1;
		w29.Expand = false;
		w29.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.frame1 = new global::Gtk.Frame ();
		this.frame1.Name = "frame1";
		this.frame1.ShadowType = ((global::Gtk.ShadowType)(2));
		this.frame1.LabelXalign = 0.5F;
		this.frame1.LabelYalign = 0F;
		// Container child frame1.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.table4 = new global::Gtk.Table (((uint)(2)), ((uint)(2)), true);
		this.table4.Name = "table4";
		this.table4.RowSpacing = ((uint)(6));
		this.table4.ColumnSpacing = ((uint)(6));
		// Container child table4.Gtk.Table+TableChild
		this.radioAddition = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Addieren"));
		this.radioAddition.CanFocus = true;
		this.radioAddition.Name = "radioAddition";
		this.radioAddition.DrawIndicator = true;
		this.radioAddition.UseUnderline = true;
		this.radioAddition.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		this.table4.Add (this.radioAddition);
		global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.table4 [this.radioAddition]));
		w30.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table4.Gtk.Table+TableChild
		this.radioDivision = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Dividieren"));
		this.radioDivision.CanFocus = true;
		this.radioDivision.Name = "radioDivision";
		this.radioDivision.DrawIndicator = true;
		this.radioDivision.UseUnderline = true;
		this.radioDivision.Group = this.radioAddition.Group;
		this.table4.Add (this.radioDivision);
		global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.table4 [this.radioDivision]));
		w31.TopAttach = ((uint)(1));
		w31.BottomAttach = ((uint)(2));
		w31.LeftAttach = ((uint)(1));
		w31.RightAttach = ((uint)(2));
		w31.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table4.Gtk.Table+TableChild
		this.radioMultiplication = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Multiplizieren"));
		this.radioMultiplication.CanFocus = true;
		this.radioMultiplication.Name = "radioMultiplication";
		this.radioMultiplication.DrawIndicator = true;
		this.radioMultiplication.UseUnderline = true;
		this.radioMultiplication.Group = this.radioAddition.Group;
		this.table4.Add (this.radioMultiplication);
		global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.table4 [this.radioMultiplication]));
		w32.TopAttach = ((uint)(1));
		w32.BottomAttach = ((uint)(2));
		w32.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table4.Gtk.Table+TableChild
		this.radioSubtraction = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Subtrahieren"));
		this.radioSubtraction.CanFocus = true;
		this.radioSubtraction.Name = "radioSubtraction";
		this.radioSubtraction.DrawIndicator = true;
		this.radioSubtraction.UseUnderline = true;
		this.radioSubtraction.Group = this.radioAddition.Group;
		this.table4.Add (this.radioSubtraction);
		global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.table4 [this.radioSubtraction]));
		w33.LeftAttach = ((uint)(1));
		w33.RightAttach = ((uint)(2));
		w33.YOptions = ((global::Gtk.AttachOptions)(4));
		this.GtkAlignment.Add (this.table4);
		this.frame1.Add (this.GtkAlignment);
		this.frameOperations = new global::Gtk.Label ();
		this.frameOperations.WidthRequest = 95;
		this.frameOperations.HeightRequest = 57;
		this.frameOperations.Name = "frameOperations";
		this.frameOperations.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Operationen:</b>");
		this.frameOperations.UseMarkup = true;
		this.frame1.LabelWidget = this.frameOperations;
		this.vbox2.Add (this.frame1);
		global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.frame1]));
		w36.PackType = ((global::Gtk.PackType)(1));
		w36.Position = 2;
		w36.Expand = false;
		w36.Fill = false;
		this.Add (this.vbox2);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 578;
		this.DefaultHeight = 376;
		this.compOperatorErrorImage.Hide ();
		this.dataTypeErrorImage.Hide ();
		this.endColumnErrorImage.Hide ();
		this.endRowErrorImage.Hide ();
		this.errorTextView.Hide ();
		this.startColumnErrorImage.Hide ();
		this.startRowErrorImage.Hide ();
		this.textCompErrorImage.Hide ();
		this.Show ();
		this.entryRowStart.FocusOutEvent += new global::Gtk.FocusOutEventHandler (this.StartRowFocusOut);
		this.entryRowEnd.FocusOutEvent += new global::Gtk.FocusOutEventHandler (this.EndRowFocusOut);
		this.entryComparisonValue.FocusOutEvent += new global::Gtk.FocusOutEventHandler (this.ComparisonValueFocusOut);
		this.entryColumnStart.FocusOutEvent += new global::Gtk.FocusOutEventHandler (this.StartColumnFocusOut);
		this.entryColumnEnd.FocusOutEvent += new global::Gtk.FocusOutEventHandler (this.EndColumnFocusOut);
		this.buttonOk.Clicked += new global::System.EventHandler (this.CancelButtonClicked);
	}
}
