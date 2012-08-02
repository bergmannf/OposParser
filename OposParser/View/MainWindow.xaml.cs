using System;
using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using OposParser.Logic;

namespace OposParser
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		
		void applyButton_Click(object sender, RoutedEventArgs e)
		{
			String startCell = this.CellFromTextBox.Text;
			String endCell = this.CellToTextBox.Text;
			String column = this.ColumnTextBox.Text;
			ExcelInterop interop = new ExcelInterop(ExcelInterop.ActiveExcel);
			IList cells = interop.ObtainCells(column, startCell, endCell);
			
//			DisplayDerivedDataType(typeOfCells);
//			DisplayOperationsForType(typeOfCells);
			
			// Perform operation.
		}
		
		void DisplayDerivedDataType(Type type) {
			this.DatatypeComboBox.Items.Clear();
			if (type == typeof(string)){
				this.DatatypeComboBox.Items.Add("Zeichenkette");
			}
			else if (type == typeof(int) || type == typeof(double)) {
				this.DatatypeComboBox.Items.Add("Zahl");
			}
			else if (type == typeof(DateTime)){
				this.DatatypeComboBox.Items.Add("Datum");
			}
			else
			{
				this.DatatypeComboBox.Items.Add("Unbekannt");
			}
		}
		
		void DisplayOperationsForType(Type type) {
			this.OperationComboBox.Items.Clear();
			if (type == typeof(string)){
				this.OperationComboBox.Items.Add(new StringComparisonOperation());
			}
			if (type == typeof(int) || type == typeof(double)) {
			  this.OperationComboBox.Items.Add(new AdditionOperation());
//			  this.OperationComboBox.Items.Add(new SubstractionOperation());
//			  this.OperationComboBox.Items.Add(new DivisionOperation());
//			  this.OperationComboBox.Items.Add(new MultiplicationOperation());
			}
			if (type == typeof(DateTime)){
//			  this.OperationComboBox.Items.Add(new BeforeDateOperation());
//			  this.OperationComboBox.Items.Add(new AfterDateOperation());
			}
		}
	}
}