using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

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
			interop.ObtainCells(column, startCell, endCell);
		}
	}
}