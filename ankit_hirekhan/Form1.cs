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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ankit_Fendhal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string str = "data source=LAPTOP-N90PF862\\SQLEXPRESS;integrated security=true;Database=ankit fendhal";
        SqlConnection conn = new SqlConnection(str);
        SqlCommand cmd= null;
        string qr=null;
        SqlDataReader dr = null;
        decimal cgst=0;
        decimal sgst=0;
        decimal igst=0;
        decimal category_id;
        decimal product_id;
        private void Form1_Load(object sender, EventArgs e)
        {
            qr = "select Product_Type_Name from TableProductCategory";
            cmd=new SqlCommand(qr,conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["Product_Type_Name"].ToString());
                
            }
            dr.Close();
            conn.Close();

            qr = "select Product_Name from TableProduct ";
            cmd = new SqlCommand(qr, conn);
            conn.Open();
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {

                comboBox1.Items.Add(dr1["Product_Name"].ToString());
            }
            dr.Close();
            conn.Close();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            qr = "select * from TableProductGSTDetails where Gst_Deatil_Name='" + listBox1.Text + "'";
            cmd = new SqlCommand(qr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["CGST"].ToString();
                textBox2.Text = dr["SGST"].ToString();
                textBox3.Text = dr["IGST"].ToString();
            }
            dr.Close();
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qr = "insert into TableInvoiceDetails values(@Customer_Name,@Customer_Contact,@Product_Category_ID,@Product_ID,@Invoice_Date,@Quantity,@price,@CGST,@SGST,@IGST,@CGST_Value,@SGST_Value,@IGST_Value,@Total_Amount)";
            cmd = new SqlCommand(qr, conn);
            cmd.Parameters.Add(new SqlParameter("@Customer_Name", textBox5.Text));
            cmd.Parameters.Add(new SqlParameter("@Customer_Contact", textBox6.Text));
            cmd.Parameters.Add(new SqlParameter("@Product_Category_ID", category_id));           
            cmd.Parameters.Add(new SqlParameter("@Product_ID", product_id));      
            cmd.Parameters.Add(new SqlParameter("@Invoice_Date", dateTimePicker1.Text));
            cmd.Parameters.Add(new SqlParameter("@Quantity", textBox7.Text));
            cmd.Parameters.Add(new SqlParameter("@price", textBox8.Text));
            cmd.Parameters.Add(new SqlParameter("@CGST", cgst));
            cmd.Parameters.Add(new SqlParameter("@SGST", sgst));
            cmd.Parameters.Add(new SqlParameter("@IGST", igst));
            cmd.Parameters.Add(new SqlParameter("@CGST_Value", cgst));
            cmd.Parameters.Add(new SqlParameter("@SGST_Value", sgst));
            cmd.Parameters.Add(new SqlParameter("@IGST_Value", igst));
            cmd.Parameters.Add(new SqlParameter("@Total_Amount", textBox10.Text));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Invoice generated");





        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            double tp=Convert.ToInt32(textBox7.Text)*Convert.ToInt32(textBox8.Text);
            double cgst = tp * Convert.ToDouble(textBox1.Text)*0.01;
            double sgdt = tp * Convert.ToDouble(textBox2.Text)*0.01;
            double igdt = tp * Convert.ToDouble(textBox3.Text)*0.01;
             
            double total = cgst+ sgdt + igdt;


            textBox9.Text = Convert.ToString(Convert.ToDecimal(tp) + Convert.ToDecimal(total));
            
           
           

            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        public void read()
        {
            qr = "select Product_Category_ID from TableProductCategory where Product_Type_Name='" + comboBox1.Text + "'";
            cmd = new SqlCommand(qr, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                category_id = Convert.ToInt32(dr["Product_Category_ID"].ToString());
            }
            dr.Close();
            conn.Close();
          

           


            qr = "select ProductID from TableProduct where Product_Name='" + comboBox1.Text + "'";
            cmd = new SqlCommand(qr, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                product_id = Convert.ToInt32(dr["ProductID"].ToString());
            }
            dr.Close();
            conn.Close();
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            qr = "select * from TableProductGSTDetails where Gst_Deatil_Name='" + comboBox1.Text + "'";
            cmd = new SqlCommand(qr, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cgst = Convert.ToDecimal(dr["CGST"].ToString());
                sgst = Convert.ToDecimal(dr["SGST"].ToString());
            }
            dr.Close();
            conn.Close();
           
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                decimal tex = Convert.ToDecimal(textBox9.Text) + sgst + cgst;
                textBox10.Text = tex.ToString();

            }
            else
            {
                decimal inclu_tax = Convert.ToDecimal(textBox9.Text) + igst;
                textBox10.Text = inclu_tax.ToString();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            qr = "select * from TableProductGSTDetails where Gst_Deatil_Name='" + comboBox1.Text + "'";
            cmd = new SqlCommand(qr, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                igst = Convert.ToDecimal(dr["IGST"].ToString());
              
            }
            dr.Close();
            conn.Close();
            MessageBox.Show("igst :" + igst.ToString());
        }
    }
}
