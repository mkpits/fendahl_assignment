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

namespace Pranjali_Bhute
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string str = "server=.\\sqlexpress;integrated security=true;database=Pranjali_Bhute";
        SqlConnection conn = new SqlConnection(str);
        SqlCommand cmd = null;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            try 
            { 
               string qr = "select Product_Name from TableProduct";
               cmd = new SqlCommand(qr, conn);
               conn.Open();
               SqlDataReader dr = cmd.ExecuteReader();
               while (dr.Read())
               {
                    comboBox1.Items.Add(dr["ProductName"].ToString());  
               }
               dr.Close();
               conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
               conn.Close();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

