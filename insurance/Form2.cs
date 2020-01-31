using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace insurance
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        public static string agentid, a;
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            agentid = comboBox1.Text;
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection("server=localhost;user id=root;password=root;database=insurance");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select id from agent", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());

                }
                dr.Close();
                con.Close();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
          
        }


        private void button6_Click(object sender, EventArgs e)
        {
            
            {
                if (String.IsNullOrEmpty(textBox1.Text))
                    MessageBox.Show("Name Cannot be Empty");
                else if (String.IsNullOrEmpty(textBox2.Text))
                    MessageBox.Show("Address Cannot be Empty");
                else if (String.IsNullOrEmpty(textBox3.Text))
                    MessageBox.Show("Contact No Cannot be Empty");
                else if (String.IsNullOrEmpty(textBox4.Text))
                    MessageBox.Show("Password Cannot  be Empty");
                else if (linkLabel1.Text == "Click To get ID")
                    MessageBox.Show("Click Generate Id");
                else
                {
                    con.Open();
                    string str = "insert into agent values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.linkLabel1.Text + "')";
                    MessageBox.Show(str);
                    MySqlCommand cmd = new MySqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("inserted");
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            con.Open();
            MySqlCommand cmd4 = new MySqlCommand("select max(id) from agent", con);
            MySqlDataReader dr4 = cmd4.ExecuteReader();
            dr4.Read();
            a = dr4[0].ToString()  ;
            int x = Convert.ToInt16(  a) + 1;

            this.linkLabel1.Text = x.ToString() ;
                
            dr4.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit_agent obj = new Edit_agent();
            obj.Show();
            this.Close();
        }

        private void textbox(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar))
            {
                e.Handled=true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)&&!char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from agent where id='" + this.comboBox1.Text + "'", con);

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string str1 = "delete from agent where id='" + this.comboBox1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(str1, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Agent deleted suceessfully");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textbox2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textbox4(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        

    }
}
