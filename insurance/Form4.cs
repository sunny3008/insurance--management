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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        public static string agent;
        private void button1_Click(object sender, EventArgs e)
        {
           if (label11.Text =="")
            {
                agent = label12.Text;
            }
            else
            {
                agent = label11.Text;
            }
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Close();
        }

       

        private void Form4_Load(object sender, EventArgs e)
        {
            
            this.clientTableAdapter3.Fill(this.insuranceDataSet3.client);
           
            label11.Text = Form2.agentid;
            label12.Text = agent_log.agentid;

            try
            {
                con = new MySqlConnection("server=localhost;user id=root;password=root;database=insurance");
                if (label11.Text == "")
                {
                    agent = label12.Text;
                }
                else
                {
                    agent = label11.Text;
                }
   
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("select ph_id from client where agent_id='" + agent +"'", con);
                MySqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    comboBox3.Items.Add(dr2[0].ToString());

                }
                dr2.Close();
                con.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd2 = new MySqlCommand("select * from client where ph_id=  '" + this.comboBox3.Text +"'", con);
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string str = "delete from ph where ph_id='"+ this.comboBox3.Text +"'";
            string str1 = "delete from claimant where ph_id='" + this.comboBox3.Text + "'";
            string str2 = "delete from sales where ph_id='" + this.comboBox3.Text + "'";
            string str3 = "delete from insurance where ph_id='" + this.comboBox3.Text + "'";
            MySqlCommand cmd4 = new MySqlCommand(str, con);
            cmd4.ExecuteNonQuery();
            MySqlCommand cmd5 = new MySqlCommand(str1, con);
            cmd5.ExecuteNonQuery();
            MySqlCommand cmd6 = new MySqlCommand(str2, con);
            cmd6.ExecuteNonQuery();
            MySqlCommand cmd7 = new MySqlCommand(str3, con);
            cmd7.ExecuteNonQuery();
            MessageBox.Show("deleted");
            con.Close();
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
           con.Open();
            MySqlCommand cmd4 = new MySqlCommand("select * from agent where id= '" + this.label11.Text + "' ", con);
            MySqlDataReader dr4 = cmd4.ExecuteReader();
            dr4.Read();
            this.label8.Text = dr4[0].ToString();
            this.label9.Text = dr4[1].ToString();
            this.label10.Text = dr4[2].ToString();
            dr4.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
           con.Open();
            MySqlCommand cmd4 = new MySqlCommand("select * from agent where id= '" + this.label12.Text + "' ", con);
            MySqlDataReader dr4 = cmd4.ExecuteReader();
            dr4.Read();
            this.label8.Text = dr4[0].ToString();
            this.label9.Text = dr4[1].ToString();
            this.label10.Text = dr4[2].ToString();
            dr4.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label11.Text == "")
            {
                agent = label12.Text;
            }
            else
            {
                agent = label11.Text;
            }
            agentreport ag = new agentreport();
            ag.Show();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
      

    }
}
