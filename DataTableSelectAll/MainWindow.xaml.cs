using System.Windows;

namespace DataTableSelectAll
{
    /// <summary>
    /// DataTableにBindingしつつSelectAllチェックボックスをヘッダーにつけるDataGridのサンプル
    /// https://stackoverflow.com/questions/25643765/wpf-datagrid-databind-to-datatable-cell-in-celltemplates-datatemplate
    /// https://stackoverflow.com/questions/21356662/selectall-in-datagrid
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var dataGridWithSelectAll = new DataGridWithSelectAllSample();
            dataGridWithSelectAll.Bind(MyDataGrid);
        }
    }
}