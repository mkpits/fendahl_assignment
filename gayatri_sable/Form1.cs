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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string str = "Data Source=LAPTOP-KFIAGKVF\\SQLEXPRESS;Initial Catalog=GAYATRI_DB;Integrated Security=True";
        SqlConnection conn=new SqlConnection(str);
        SqlCommand cmd;

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
          
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            try
            {
                string qr = "select Nation_Name from TableNation";
                
                cmd = new SqlCommand(qr, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["Nation_Name"].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int state_id = 0;
            try
            {
                string qr = "select State_ID from TableState Where State_Name=@state_name";

                cmd = new SqlCommand(qr, conn);
                conn.Open();
                cmd.Parameters.Add("@state_name", SqlDbType.VarChar).Value = comboBox2.SelectedItem;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    state_id = Convert.ToInt32(dr["State_ID"]);
                    //comboBox1.Items.Add(dr["Nation_Name"].ToString());
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }


            try
            {
                string qr = "select* from TableCity Where State_Id=@state_id";

                cmd = new SqlCommand(qr, conn);
                conn.Open();
                cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = state_id;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //nation_id = Convert.ToInt32(dr["nation_id"]);
                    comboBox3.Items.Add(dr["City_Name"].ToString());
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int nation_id = 0;
            try
            {
                string qr = "select Nation_ID from TableNation Where Nation_Name=@nation_name";

                cmd = new SqlCommand(qr, conn);
                conn.Open();
                cmd.Parameters.Add("@nation_name", SqlDbType.VarChar).Value = comboBox1.SelectedItem;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    nation_id = Convert.ToInt32(dr["Nation_ID"]);
                    //comboBox1.Items.Add(dr["Nation_Name"].ToString());
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
            
            try
            {
                string qr = "select* from TableState Where Nation_Id=@nation_id";

                cmd = new SqlCommand(qr, conn);
                conn.Open();
                cmd.Parameters.Add("@nation_id", SqlDbType.Int).Value = nation_id;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //nation_id = Convert.ToInt32(dr["nation_id"]);
                    comboBox2.Items.Add(dr["State_Name"].ToString());
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
           

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "1000";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.Text = "3000";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;   
            radioButton3.Checked = false;
            radioButton4.Checked= false;
            comboBox1.Items.Clear(); comboBox2.Items.Clear();comboBox3.Items.Clear();
        }
    }
}
