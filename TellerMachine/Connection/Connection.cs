using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Connection
{

    public class Connection
    {
        private SqlConnection connection = new SqlConnection();

        public void createConnection()
        {

            connection.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Ifeoluwa Walter\\Documents\\Visual Studio 2010\\Projects\\TellerMachine\\TellerMachine\\ATM.mdf\";Integrated Security=True;User Instance=True";
            connection.Open();
        }

        public void checkConnection()
        {
            if (connection == null || connection.State == System.Data.ConnectionState.Closed)
            {
                createConnection();
            }
        }

        public SqlDataReader getDataReader(String SQL)
        {
            checkConnection();
            SqlCommand cmd = new SqlCommand(SQL, connection);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
        public DataTable getDataTable(String SQL)
        {
            checkConnection();
            SqlCommand cmd = new SqlCommand(SQL, connection);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }

        public void executeQuery(String SQL)
        {
            checkConnection();
            SqlCommand cmd = new SqlCommand(SQL, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

        }

    }
}
