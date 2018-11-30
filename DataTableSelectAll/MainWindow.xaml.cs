using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTableSelectAll
{
    /// <summary>
    /// DataTableにBindingしつつSelectAllチェックボックスをヘッダーにつけるDataGridのサンプル
    /// https://stackoverflow.com/questions/25643765/wpf-datagrid-databind-to-datatable-cell-in-celltemplates-datatemplate
    /// https://stackoverflow.com/questions/21356662/selectall-in-datagrid
    /// </summary>
    public partial class MainWindow : Window
    {
        DataGridWithSelectAll dataGridWithSelectAll;

        public MainWindow()
        {
            InitializeComponent();

            dataGridWithSelectAll = new DataGridWithSelectAll(MyDataGrid);
        }


/*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(string.Join(",", Items.AsEnumerable().Select(row => row["IsSelected"].ToString())));
            Debug.WriteLine(string.Join(",", Items.AsEnumerable().Select(row => row["StringColumn"].ToString())));
        }
        */
    }
}