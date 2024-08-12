using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        
        public static Form2 instance;
     
        public Form2()
        {
            InitializeComponent();
            instance = this;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LCKUMES\SQLEXPRESS01;Initial Catalog=Login;Integrated Security=True");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e)

        {

            Form2 form1 = new Form2();
            form1.Show();


            String username,user_password;

            username = label2.Text;
            user_password = label3.Text;

            try
            {
                String querry = "SELECT * FROM Login_new WHERE username ='"+label2.Text+"'AND password = '"+label3.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry,conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    username = label2.Text;
                    user_password = label3.Text;

                  Form1 form2= new Form1();
                    form1.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid login details","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    object value = ClearInputs();

                    label2.Focus();
                }


            }
            catch
                {
                MessageBox.Show("Error");

            }
            finally
            {
                conn.Close();
            }
        }

        private object ClearInputs()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object value = ClearInputs();

            label2.Focus(); 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
               Application.Exit();  

            }
            else {
                this.Show();
            }
        }
    }
}
