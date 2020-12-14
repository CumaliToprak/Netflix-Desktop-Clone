using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetflixApp.DbHelper
{
     class OleDbHelper
    {
        //Veri tabanı bağlantısını sağlayan nesne.
       static OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=|DataDirectory|\NetflixDB.accdb;Persist Security Info=True");
       static OleDbDataAdapter dataAdapter = new OleDbDataAdapter();  //veritabanı ile uygulama katmanı arasında veri akışını sağlar.
       static OleDbCommand command = new OleDbCommand();
      

        private static void openConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabani bağlantısı açılamadı!" + ex.Message);
            }
        }

        public static DataTable GetData(DataTable dataTable, string sqlQuery)
        {
            command.Connection = connection;
            command.CommandText = sqlQuery;
            dataAdapter.SelectCommand = command;
            openConnection();
            dataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static bool insertData(string sqlQuery)
        {
            try
            {
                command.CommandText = sqlQuery;
                command.Connection = connection;
                openConnection();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return false;
        }

        public static bool updateData(string sqlQuery)
        {
            try
            {
                command.CommandText = sqlQuery;
                command.Connection = connection;
                openConnection();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.Close();
            }

            return false;
        }

    }
}
