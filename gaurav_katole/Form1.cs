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
namespace Gaurav
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string cs = "server=DESKTOP-PM3J8V7\\SQLEXPRESS;integrated security=True;database=rajkumar";
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand(cs);
        string str = null;
        SqlDataReader dr = null;
        decimal cgst;
        decimal sgst;
        decimal total_price;
        decimal igst;
        int category_id;
        int product_id;
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            str = "select Product_Type_Name from TableProductCategory";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            comboBox1.Text=("Select");
            while(dr.Read())
            {
                comboBox1.Items.Add(dr["Product_Type_Name"].ToString());
            }
            dr.Close();
            con.Close();

            str = "select Product_Name from TableProduct";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            comboBox1.Text = ("Select");
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Product_Name"].ToString());
            }
            dr.Close();
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            read();

            str = "insert into TableInvoiceDetails values(@Customer_Name,@Customer_Contact,@Product_Category_ID,@Product_ID,@Invoice_Date,@Quantity,@price,@CGST,@SGST,@IGST,@CGST_Value,@SGST_Value,@IGST_Value,@Total_Amount)";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.Add(new SqlParameter("@Customer_Name", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@Customer_Contact", textBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@Product_Category_ID", category_id));
           // cmd.Parameters.Add(new SqlParameter("@Product_Category_ID", category_id));
            cmd.Parameters.Add(new SqlParameter("@Product_ID", product_id));
            // cmd.Parameters.Add(new SqlParameter("@Residential_Type_ID", ));
            cmd.Parameters.Add(new SqlParameter("@Invoice_Date", dateTimePicker1.Text));
            cmd.Parameters.Add(new SqlParameter("@Quantity", textBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@price", textBox6.Text));
            cmd.Parameters.Add(new SqlParameter("@CGST", cgst));
            cmd.Parameters.Add(new SqlParameter("@SGST", sgst));
            cmd.Parameters.Add(new SqlParameter("@IGST", igst));
            cmd.Parameters.Add(new SqlParameter("@CGST_Value", cgst));
            cmd.Parameters.Add(new SqlParameter("@SGST_Value", sgst));
            cmd.Parameters.Add(new SqlParameter("@IGST_Value", igst));
            cmd.Parameters.Add(new SqlParameter("@Total_Amount", textBox5.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Invoice generated");







            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            str = "select * from TableProductGSTDetails where Gst_Deatil_Name='" + comboBox1.Text + "'";
            cmd=new SqlCommand(str, con);
            con.Open();
            dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                cgst = Convert.ToDecimal(dr["CGST"].ToString());
                sgst= Convert.ToDecimal(dr["SGST"].ToString());
            }
            dr.Close();
            con.Close();
            MessageBox.Show("CGST :" + cgst.ToString()); ;
            MessageBox.Show("sgst :" + sgst.ToString()); ;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
            total_price = Convert.ToDecimal(textBox3.Text) * Convert.ToDecimal(textBox6.Text);
            textBox4.Text = total_price.ToString();
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
            decimal inclu_tax = Convert.ToDecimal(textBox4.Text)+sgst+cgst;
            textBox5.Text = inclu_tax.ToString();

            }
            else
            {
                decimal inclu_tax = Convert.ToDecimal(textBox4.Text) + igst;
                textBox5.Text = inclu_tax.ToString();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            str = "select * from TableProductGSTDetails where Gst_Deatil_Name='" + comboBox1.Text + "'";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                igst = Convert.ToDecimal(dr["IGST"].ToString());
               // s = Convert.ToDecimal(dr["SGST"].ToString());
            }
            dr.Close();
            con.Close();
            MessageBox.Show("igst :" + igst.ToString()); 


           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //-----------------------//Read Product_category Id-----

        public void read()
        {//---------------------------product_category id----------------------
            str = "select Product_Category_ID from TableProductCategory where Product_Type_Name='" + comboBox1.Text + "'";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                category_id = Convert.ToInt32(dr["Product_Category_ID"].ToString());
            }
            dr.Close();
            con.Close();
            MessageBox.Show("Product_category_id: " + category_id.ToString());

            //-------------------product id-----------------------


            str = "select ProductID from TableProduct where Product_Name='" + comboBox2.Text + "'";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                product_id = Convert.ToInt32(dr["ProductID"].ToString());
            }
            dr.Close();
            con.Close();
            MessageBox.Show("Product_id: " + product_id.ToString());
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
