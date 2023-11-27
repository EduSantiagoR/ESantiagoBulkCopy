using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CargaMasiva
    {
        public static ML.Result ReadExcel(string connectionString)
        {
            ML.Result result = new ML.Result();
            using(OleDbConnection context = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM [RegistrosBulkCopy]";
                using(OleDbCommand cmd = new OleDbCommand(query, context))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = cmd;

                    DataTable tablaProducto = new DataTable();
                    adapter.Fill(tablaProducto);

                    if(tablaProducto.Rows.Count > 0 )
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in tablaProducto.Rows)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.Proveedor = new ML.Proveedor();
                        }
                    }
                }
            }
            return result;
        }
    }
}
