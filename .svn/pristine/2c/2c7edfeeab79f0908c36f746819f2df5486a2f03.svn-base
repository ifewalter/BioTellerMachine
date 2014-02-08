using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Connection;
using System.Data.SqlClient;

namespace TellerMachineAdmin
{
    public partial class Log : Form
    {
        private ConnectionStatement connectionStatement = new ConnectionStatement();
        private SqlDataReader dataReader;

        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(loadLogEntries);
            thread.Start();
          //  thread.Join();
        }

        private void loadLogEntries()
        {
            dataReader = connectionStatement.fetchLogs();
            StringBuilder builder = new StringBuilder();
            
            //   System.Data.DataRow dataRow;
            foreach (IDataRecord dataRow in dataReader)
            {
                builder.Append(dataRow.GetString(3));
                builder.Append(" / ");
                builder.Append(dataRow.GetString(2));
                builder.Append(" / ");
                builder.Append(dataRow.GetString(1));
                builder.AppendLine("\n");
            }
            dataReader.Close();
            textBox1.Text = builder.ToString();
        }
    }
}
