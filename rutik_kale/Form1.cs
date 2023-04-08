using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Rutik_kale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string str = "server=\\SQLEXPRESS;Integrated security= true; database=Rutik_kale";
        SqlConnection conn = null;
        SqlCommand cmd= null;
            
          

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }

            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from TableInvoiceDetails", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "TableInvoiceDetails");
                dataGridView1.DataSource = ds.Tables["TableInvoiceDetails"];
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
                                    
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
           try
            {
            
            }
            catch 
            {

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(str);
                string qr = "select * from TableProduct;";
                cmd = new SqlCommand(qr, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[""].ToString());
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
    }
}
