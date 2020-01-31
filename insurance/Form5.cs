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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
         try
            {
                con = new MySqlConnection("server=localhost;user id=root;password=root;database=insurance");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select ph_id from client where agent_id='" + Form4.agent + "'", con);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from ph where ph_id=" + this.comboBox1.Text, con);
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string str = "update ph set name='" + this.textBox6.Text + "',address='" + this.textBox7.Text + "',phone='" + this.textBox8.Text + "',sex='" + this.comboBox3.Text +"',dob='" + this.dateTimePicker2.Text + "',age=" + this.textBox17.Text + ",ms='" + this.comboBox4.Text +"',password='" + this.textBox10.Text +"',salary="+ this.textBox11.Text +" where ph_id= '" + this.comboBox1.Text + "'";
            MessageBox.Show(str);

            MySqlCommand cmd = new MySqlCommand(str, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated");
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string str = "update claimant set name='" + this.textBox12.Text + "',address='" + this.textBox14.Text + "',phone='" + this.textBox13.Text + "',sex='" + this.comboBox6.Text + "',dob='" + this.dateTimePicker2.Text + "',age=" + this.textBox16.Text + ",ms='" + this.comboBox5.Text + "' where ph_id= '" + this.comboBox1.Text + "'";
            MessageBox.Show(str);

            MySqlCommand cmd = new MySqlCommand(str, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true ;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void text1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text3(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
