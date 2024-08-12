using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form3 : Form
    {
        private DataSet ds;

        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            {
                InitializeComponent();

                // Load data into the DataSet
                ds = new DataSet();
                using (SqlConnection connection = new SqlConnection("your_connection_string_here"))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM your_table_name_here", connection))
                    {
                        adapter.Fill(ds, "TableName");
                    }
                }
            }

        }
    }
}
