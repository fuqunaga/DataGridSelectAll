using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DataTableSelectAll
{
    class DataGridWithSelectAll: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DataTable Items { get; set; }


        public DataGridWithSelectAll(DataGrid dataGrid)
        {
            Items = CreateItems();

            dataGrid.AutoGeneratingColumn += (s, e) =>
            {
                if (e.PropertyName == "IsSelected")
                {
                    var c = new DataGridTemplateColumn()
                    {
                        CellTemplate = (DataTemplate)dataGrid.Resources["IsSelected"],
                        Header = e.Column.Header,
                        HeaderTemplate = (DataTemplate)dataGrid.Resources["SelectAll"],
                        HeaderStringFormat = e.Column.HeaderStringFormat,
                        SortMemberPath = e.PropertyName // this is used to index into the DataRowView so it MUST be the property's name (for this implementation anyways)
                    };
                    e.Column = c;

                }
            };

            dataGrid.DataContext = this;
        }

        private DataTable CreateItems()
        {
            var dt = new DataTable();
            dt.Columns.Add("IsSelected", typeof(bool));
            dt.Columns.Add("StringColumn", typeof(string));
            dt.Columns.Add("IntColumn", typeof(int));

            dt.Rows.Add(true, "row0", 0);
            dt.Rows.Add(false, "row1", 1);
            dt.Rows.Add(true, "row2", 2);

            dt.ColumnChanged += (s, e) =>
            {
                if (e.Column.ColumnName == "IsSelected")
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsSelected"));
                }
            };

            return dt;
        }



        public bool? IsSelected
        {
            get
            {
                var uniqueList = Items.AsEnumerable().Select(row => row["IsSelected"]).Distinct().ToList();
                return uniqueList.Count() == 1 ? (bool?)uniqueList.First() : null;
            }
            set
            {
                Items.AsEnumerable().ToList().ForEach(row => row["IsSelected"] = value);
            }
        }
    }
}
