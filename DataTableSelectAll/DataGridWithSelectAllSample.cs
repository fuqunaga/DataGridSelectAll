using System.Data;

namespace DataTableSelectAll
{
    class DataGridWithSelectAllSample : DataGridWithSelectAll
    {
        public DataGridWithSelectAllSample()
        {
            Items = CreateItems();
            AddItemsCallback();
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

            return dt;
        }
    }
}
