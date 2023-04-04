using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlTypes;
namespace doan.net
{
    class cl
    {
        private string conStr = @"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=Quanlybanbooks;Integrated Security=True";

        private SqlConnection mysqlConnection;

        public cl ()
        {
            mysqlConnection = new SqlConnection(conStr);
        }

        public DataTable getData(string sSql)
        {
            try
            {
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSql, mysqlConnection);
                DataTable myDataTable = new DataTable();
                myDataAdapter.Fill(myDataTable);
                return myDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void runQuery(string sSql)
        {
            try
            {
                mysqlConnection.Open();
                SqlCommand mySqlCommand = new SqlCommand(sSql, mysqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
