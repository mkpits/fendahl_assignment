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
using System.Reflection;
using static System.Windows.Forms.AxHost;

namespace Type_A_Machine_Test
{
    public partial class Form1 : Form
    {
        string s = "Server=.\\sqlexpress;integrated security=true;database=Practical_Type_A";
        SqlConnection conn;
        SqlCommand cmd;
        public string gender;
        public int NationID;
        public int StateID;
        public int CityID;

        public Form1()
        {
            InitializeComponent();
        }

        public void Nation()
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string s1 = "select Nation_Name from TableNation";
            SqlCommand cmd = new SqlCommand(s1, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add( dr["Nation_Name"].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Nation();
            GetNationID();
            GetStateID();
            GetCityID();
        }

        public void State()
        {
            try
            {
                SqlConnection conn = new SqlConnection(s);
                conn.Open();
                string s1 = "Select State_Name from TableState as SN inner join TableNation as TN on SN.Nation_ID = TN.Nation_ID where Nation_Name = '" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(s1, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["State_Name"].ToString());
                }
                dr.Close();
                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            State();
        }

        public void City()
        {
            try
            {
                SqlConnection conn = new SqlConnection(s);
                conn.Open();
                string s1 = "Select City_Name from TableCity as TC inner join TableState as TN on TC.State_ID=TN.State_ID where State_Name = '" + comboBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(s1, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["City_Name"].ToString());
                }
                dr.Close();
                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            City();
        }   
        
        public void GetNationID()
        {
            try
            {
                SqlConnection conn = new SqlConnection(s);
                conn.Open();
                string s1 = "select Nation_ID from TableNation where Nation_Name='" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(s1, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    NationID = Convert.ToInt32(dr["Nation_ID"]);
                }
               // MessageBox.Show("NationID" + NationID);
                dr.Close();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        public void GetStateID()
        {
            try
            {
                SqlConnection conn = new SqlConnection(s);
                conn.Open();
                string s1 = "select State_ID from TableState where State_Name='" + comboBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(s1, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    StateID = Convert.ToInt32(dr["State_ID"]);
                }
              //  MessageBox.Show("StateID" + StateID);
                dr.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        public void GetCityID()
        {
            try
            {
                SqlConnection conn = new SqlConnection(s);
                conn.Open();
                string s1 = "select City_ID from TableCity where City_Name='" + comboBox3.Text + "'";
                SqlCommand cmd = new SqlCommand(s1, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CityID = Convert.ToInt32(dr["City_ID"]);
                }
               // MessageBox.Show("CID" + CityID);
                dr.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        public void insertRegAddress()
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string s2 = "insert into TableRegAddress values(@CourseRegID,@NationID,@StateID,@CityID)";
            SqlCommand cmd1 = new SqlCommand(s2,conn);
            cmd1.Parameters.Add("@CourseRegID", SqlDbType.Int).Value = 1;
            cmd1.Parameters.Add("@NationID", SqlDbType.Int).Value = NationID;
            cmd1.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;
            cmd1.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
            cmd1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Stored TableRegAddress");
        }
        public void insertFeeDetail()
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string s2 = "insert into TableFeeDetail values(@CourseRegID,@TotalAmount,@MinPer,@PaidAmount,@BalAmount,@PaidDate)";
            SqlCommand cmd1 = new SqlCommand(s2, conn);
            cmd1.Parameters.Add("@CourseRegID", SqlDbType.Int).Value = 1;
            cmd1.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = textBox2.Text;
            cmd1.Parameters.Add("@MinPer", SqlDbType.Int).Value = 0;
            cmd1.Parameters.Add("@PaidAmount", SqlDbType.Int).Value = textBox4.Text;
            cmd1.Parameters.Add("@BalAmount", SqlDbType.Int).Value = textBox5.Text;
            cmd1.Parameters.Add("@PaidDate", SqlDbType.DateTime).Value = dateTimePicker1.Text;
            cmd1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Stored TableFeeDetail");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GetNationID();
                GetStateID();
                GetCityID();
                string category = null;
                if (radioButton1.Checked == true)
                {
                    category = "Student";

                }
                else if (radioButton2.Checked == true)
                {
                    category = "IT Professional";
                }

                if (radioButton3.Checked == true)
                {
                    gender = "Male";
                }
                else if (radioButton4.Checked == true)
                {
                    gender = "Female";
                }

                if (category == "Student")
                {
                   
                    SqlConnection conn = new SqlConnection(s);
                    conn.Open();
                    string s1 = "insert into TableCourseRegDetail values(@CategoryInd,@FullName,@GenderInd)";
                    SqlCommand cmd = new SqlCommand(s1, conn);
                    cmd.Parameters.Add("@CategoryInd", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@GenderInd", SqlDbType.VarChar).Value = gender;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Store Successfully in CourseRegDetail");
                    insertRegAddress();
                    insertFeeDetail();
                }
                else if(category=="IT Professional")
                {
                    SqlConnection conn = new SqlConnection(s);
                    conn.Open();
                    string s1 = "insert into TableCourseRegDetail values(@CategoryInd,@FullName,@GenderInd)";
                    SqlCommand cmd = new SqlCommand(s1, conn);
                    cmd.Parameters.Add("@CategoryInd", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@GenderInd", SqlDbType.VarChar).Value = gender;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Store Successfully in CourseRegDetail");
                    insertRegAddress();
                    insertFeeDetail();
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text="1000";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            decimal paidamount=0;

            if(radioButton1.Checked == true)
            {
                paidamount = Convert.ToDecimal(textBox2.Text)-Convert.ToDecimal(textBox4.Text);
                textBox5.Text = paidamount.ToString();
            }

            else if (radioButton2.Checked == true)
            {
                paidamount = Convert.ToDecimal(textBox2.Text) - Convert.ToDecimal(textBox4.Text);
                textBox5.Text = paidamount.ToString();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "3000";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked= false;
            radioButton2.Checked= false;
            radioButton3.Checked= false;
            radioButton4.Checked= false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            
        }
    }
}
