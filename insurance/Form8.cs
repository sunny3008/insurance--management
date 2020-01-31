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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        public static string ph_id;
        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'insuranceDataSet.agent' table. You can move, or remove it, as needed.
            //this.agentTableAdapter.Fill(this.insuranceDataSet.agent);
            label24.Text = Form4.agent;
           

            try
            {
                con = new MySqlConnection("server=localhost;user id=root;password=root;database=insurance");


                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("select type from policy", con);
                MySqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    comboBox2.Items.Add(dr1[0].ToString());

                }
                dr1.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd1 = new MySqlCommand("select * from policy where type= '" + this.comboBox2.Text + "'", con);
            MySqlDataReader dr1 = cmd1.ExecuteReader();
            dr1.Read();
            this.textBox1.Text = dr1[1].ToString();
            this.textBox4.Text = dr1[2].ToString();
            // this.label10.Text = dr[1].ToString();
            dr1.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string str = "insert into ph values('" + this.linkLabel1.Text + "','" + this.textBox6.Text + "', '" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + this.comboBox3.Text + "','" + this.dateTimePicker2.Text + "'," + this.textBox17.Text + ",'" + this.comboBox4.Text + "','" + this.textBox10.Text + "'," + this.textBox11.Text + ")";
            string str1 = "insert into claimant values('" + this.textBox12.Text + "','" + this.textBox14.Text + "','" + this.linkLabel1.Text + "','" + this.textBox1.Text + "','" + this.comboBox6.Text + "','" + this.dateTimePicker1.Text + "','" + this.comboBox5.Text + "'," + this.textBox16.Text + ",'" + this.textBox13.Text + "')";
            string str2 = "insert into insurance values(" + this.textBox3.Text + "," + this.textBox3.Text + " * 0.9/(" + this.textBox4.Text + " *12)," + this.textBox4.Text + ",'" + this.linkLabel1.Text + "','" + this.textBox1.Text + "','" + this.dateTimePicker3.Text + "')";
            string str3 = "insert into sales values('" + this.label24.Text + "'," + this.textBox3.Text + "*0.05,'" + this.linkLabel1.Text + "','" + this.textBox1.Text + "')";
            MySqlCommand cmd = new MySqlCommand(str, con);
            cmd.ExecuteNonQuery();
            MySqlCommand cmd1 = new MySqlCommand(str1, con);
            cmd1.ExecuteNonQuery();
            MySqlCommand cmd2 = new MySqlCommand(str2, con);
            cmd2.ExecuteNonQuery();
            MySqlCommand cmd3 = new MySqlCommand(str3, con);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("inserted");
            con.Close();
            ph_id = this.linkLabel1.Text;
            report obj = new report();
            obj.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            con.Open();
            MySqlCommand cmd4 = new MySqlCommand("select max(ph_id) from ph", con);
            MySqlDataReader dr4 = cmd4.ExecuteReader();
            dr4.Read();
            string a = dr4[0].ToString();
            int x = Convert.ToInt16(a) + 1;
            this.linkLabel1.Text = x.ToString();
            dr4.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string b = this.textBox3.Text;
            string c = this.textBox4.Text;
            int d = Convert.ToInt32(b);
            int f = Convert.ToInt32(c);
            double h = (d * 0.9) / (f * 12);
            this.linkLabel2.Text = h.ToString();
        }

        private void text1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text3(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text4(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
