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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.Security.Policy;
using System.Xml.Linq;

namespace Gopal1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string str = "server= LAPTOP-MI9LA60S\\SQLEXPRESS;integrated security=true;database=Gopal";
        SqlConnection conn = null;
        SqlCommand cmd = null;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string nationality = null;
                if (radioButton1.Checked == true)
                {
                    nationality = "M";
                }
                else if (radioButton2.Checked == true)
                {

                    nationality = "F";
                }


                string qr = "insert into customer values(@Customer_Name,@Product_ID,@Customer_Contact,@Quantity,@CGST,@SGST,@IGST,@CGST,@Total_Amount)";
                cmd = new SqlCommand(qr, conn);
                cmd.Parameters.Add("@Customer_Name", SqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@Product_ID", SqlDbType.VarChar).Value = comboBox1.Text;
                cmd.Parameters.Add("@Customer_Contact", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
                cmd.Parameters.Add("@CGST", SqlDbType.Int).Value = Convert.ToDecimal(textBox2.Text);
                cmd.Parameters.Add("@SGST", SqlDbType.Int).Value = Convert.ToDecimal(textBox2.Text);
                cmd.Parameters.Add("@IGST", SqlDbType.Int).Value = Convert.ToDecimal(textBox2.Text);
                cmd.Parameters.Add("@CGST", SqlDbType.Int).Value = Convert.ToDecimal(textBox2.Text);
                cmd.Parameters.Add("@Total_Amount", SqlDbType.Int).Value = Convert.ToDecimal(textBox2.Text);
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
            }
               
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {

                // conn.Close();

            }

        }

    }


                 
    
}
