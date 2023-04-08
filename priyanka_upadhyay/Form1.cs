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

namespace Priyanka_Upadhyay_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string sqlconn = " server=LAPTOP-AG42TJH3\\SQLEXPRESS;integrated Security=true;database=PriyankaUpadhyay";
        SqlConnection connection=new SqlConnection(sqlconn);
        SqlCommand command;
        int catoryInd;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string st = "select * from TableNation ";
                command = new SqlCommand(st, connection);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                //int nid = 0;
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["Nation_Name"].ToString());
                }
                dr.Close();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //try
            //{
            //    string st = "select State_Name from TableState where Nation_ID=@nation_id";
            //    command = new SqlCommand(st, connection);
            //    command.Parameters.Add("@nation_id",SqlDbType.Int)
            //    connection.Open();
            //    SqlDataReader dr = command.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        comboBox1.Items.Add(dr["Nation_Name"].ToString());
            //    }
            //    dr.Close();
            //    connection.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}




        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string category = null;
                if (radioButton1.Checked == true)
                {
                    category = "Student";
                }
                else if (radioButton2.Checked == true)
                {
                    category = "Professional";
                }
                string gender = null;
                if (radioButton1.Checked == true)
                {
                    gender = "Male";
                }
                else if (radioButton2.Checked == true)
                {
                    gender = "Female";
                }
                else if (radioButton3.Checked == true)
                {
                    gender = "Other";
                }
                string st = "insert into TableCourseRegDetail values(@CategoryInd,@FullName,@GenderInd)";
                command = new SqlCommand(st, connection);
                command.Parameters.Add("@CategoryInd", SqlDbType.Int).Value = catoryInd;
                command.Parameters.Add("@FullName", SqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@GenderInd", SqlDbType.VarChar).Value = gender;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        void categoryInd()
        {
            try
            {
                string st = " select CategoryInd from TableCourseRegDetail where FullName=@fname";
                command = new SqlCommand(st, connection);
                command.Parameters.Add("@fname", SqlDbType.VarChar).Value = textBox1.Text;
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nationid = 0;
            try
            {
                
                string st = "select Nation_ID from TableNation where  Nation_Name=@nationname";
                command = new SqlCommand(st, connection);
                command.Parameters.Add("@nationname", SqlDbType.VarChar).Value = comboBox1.Text;
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                
                while (dr.Read())
                {
                   nationid = Convert.ToInt32(dr["Nation_ID"].ToString());
                }
                dr.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                
                string st1 = "select State_Name from TableState where  Nation_ID=@nationid";
                command = new SqlCommand(st1, connection);
                command.Parameters.Add("@nationid", SqlDbType.Int).Value = nationid;
                connection.Open();
                SqlDataReader dr1 = command.ExecuteReader();
                comboBox2.Items.Clear();
                while (dr1.Read())
                {
                    comboBox2.Items.Add(dr1["State_Name"].ToString());
                }
                dr1.Close();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityid = 0;
            try
            {
                
                
                string st = "select State_ID from TableState where  State_Name=@statename";
                command = new SqlCommand(st, connection);
                command.Parameters.Add("@statename", SqlDbType.VarChar).Value = comboBox2.Text;
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    cityid = Convert.ToInt32(dr["State_ID"].ToString());
                }
                dr.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
             
                string st1 = "select City_Name from TableCity where  State_ID=@stateid";
                command = new SqlCommand(st1, connection);
                command.Parameters.Add("@stateid", SqlDbType.Int).Value = cityid;
                connection.Open();
                SqlDataReader dr1 = command.ExecuteReader();
                comboBox3.Items.Clear();
                while (dr1.Read())
                {
                    comboBox3.Items.Add(dr1["City_Name"].ToString());
                }
                dr1.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            float paidamount = Convert.ToInt32(textBox3.Text) * 0.50f;
            if (radioButton1.Checked)
            {
                textBox3.Text = "1000";
                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox3.Text = "3000";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            

        }
    }
}
