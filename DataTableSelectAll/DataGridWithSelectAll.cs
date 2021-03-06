﻿using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DataTableSelectAll
{
    class DataGridWithSelectAll : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DataTable Items { get; set; }


        protected virtual string selectedPropertyName => "IsSelected";
        protected virtual string cellTemplateKey => "IsSelected";
        protected virtual string headerTemplateKey => "SelectAll";


        protected void AddItemsCallback()
        {
            Items.ColumnChanged += (s, e) =>
            {
                if (e.Column.ColumnName == selectedPropertyName)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectAll"));
                }
            };
        }

        public void Bind(DataGrid dataGrid)
        {
            dataGrid.AutoGeneratingColumn += (s, e) =>
            {
                if (e.PropertyName == selectedPropertyName)
                {
                    var c = new DataGridTemplateColumn()
                    {
                        CellTemplate = (DataTemplate)dataGrid.Resources[cellTemplateKey],
                        Header = e.Column.Header,
                        HeaderTemplate = (DataTemplate)dataGrid.Resources[headerTemplateKey],
                        HeaderStringFormat = e.Column.HeaderStringFormat,
                        SortMemberPath = e.PropertyName // this is used to index into the DataRowView so it MUST be the property's name (for this implementation anyways)
                    };
                    e.Column = c;
                }
            };

            dataGrid.DataContext = this;
            
        }


        public bool? SelectAll
        {
            get
            {
                var uniqueList = Items.AsEnumerable().Select(row => row[selectedPropertyName]).Distinct().ToList();
                return uniqueList.Count() == 1 ? (bool?)uniqueList.First() : null;
            }
            set
            {
                Items.AsEnumerable().ToList().ForEach(row => row[selectedPropertyName] = value);
            }
        }
    }
}
