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
    public partial class agent_log : Form
    {
        public agent_log()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        public static string sbeam, sname, agentid;
        private void agent_log_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            string Query1 = "select * from agent where id='" + comboBox1.Text + "' and password='" + textBox2.Text + "'";
            sbeam = comboBox1.Text;
            MySqlCommand cmd1 = new MySqlCommand(Query1, con);
            MySqlDataReader reader1;
            con.Open();
            reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                sname = reader1.GetString("password");
                sbeam = reader1.GetString("id");

            }
            con.Close();


            if (textBox2.Text == sname && comboBox1.Text == sbeam)
            {




                string Query2 = "select * from agent where id='" + comboBox1.Text + "' and password='" + textBox2.Text + "'";
                MySqlCommand cmd2 = new MySqlCommand(Query2, con);
                MySqlDataReader reader2;
                con.Open();
                reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    sbeam = reader2.GetString("id");


                }
                con.Close();

                agentid = comboBox1.Text;
                Form4 frm2 = new Form4();
                frm2.MdiParent = this.MdiParent;
                frm2.Show();
                this.Close();

            }

            else
            {
                MessageBox.Show("WRONG PASSWORD OR USERNAME");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from agent where id='" + this.comboBox1.Text + "'", con);

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
