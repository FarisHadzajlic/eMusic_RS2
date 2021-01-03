using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMusic.WinUI.Helper
{
    public class DGVHelper
    {
        public static void PopulateWithList<T>(DataGridView dgv, IList<T> list, List<string> properties = null)
        {
            if (properties == null)
            {
                properties = typeof(T).GetProperties().Select(i => i.Name).ToList();
            }

            dgv.ColumnCount = properties.Count();
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Name = properties[i];
            }

            var typeProperties = typeof(T).GetProperties();
            foreach (var item in list)
            {
                string[] values = new string[dgv.ColumnCount];
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    foreach (var typeProperty in typeProperties)
                    {
                        if (properties[i] == typeProperty.Name && item != null)
                        {
                            values[i] = typeProperty.GetValue(item)?.ToString();
                            break;
                        }
                    }
                }
                dgv.Rows.Add(values);
            }
        }
    }
}
