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
    public partial class Edit_agent : Form
    {
        public Edit_agent()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        private void Edit_agent_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection("server=localhost;user id=root;password=root;database=insurance");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select ph_id from ph", con);
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

        private void button1_Click(object sender, EventArgs e)
        {
             
            con.Open();
            string str = "update agent set name='" + this.textBox1.Text + "',address='" + this.textBox2.Text + "',cont_no='" + this.textBox3.Text + "',password='" + this.textBox4.Text +"' where id= '" + this.comboBox1.Text + "'";
            MessageBox.Show(str);

            MySqlCommand cmd = new MySqlCommand(str, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated");
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
    }
}
