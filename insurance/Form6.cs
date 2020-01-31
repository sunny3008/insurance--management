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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        private void Form6_Load(object sender, EventArgs e)
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

      

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from ph where ph_id= '" + this.comboBox1.Text +"' ", con);
              MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
             this.label11.Text = dr[1].ToString();
            this.label12.Text = dr[2].ToString();
             this.label13.Text = dr[3].ToString();
             this.label14.Text = dr[4].ToString();
             this.label15.Text = dr[5].ToString();
             this.label16.Text = dr[6].ToString();
             this.label17.Text = dr[7].ToString();
             this.label18.Text = dr[8].ToString();
             this.label19.Text = dr[9].ToString();
            dr.Close();
            con.Close();

            con.Open();
            MySqlCommand cmd1 = new MySqlCommand("select * from ins where ph_id= '" + this.comboBox1.Text + "' ", con);
            MySqlDataReader dr1 = cmd1.ExecuteReader();
            dr1.Read();
            this.label26.Text = dr1[0].ToString();
            this.label27.Text = dr1[1].ToString();
            this.label28.Text = dr1[2].ToString();
            this.label29.Text = dr1[3].ToString();
            this.label30.Text = dr1[4].ToString();
            this.label31.Text = dr1[5].ToString();
          
            dr1.Close();
            con.Close();

            con.Open();
            MySqlCommand cmd2 = new MySqlCommand("select * from client where ph_id= '" + this.comboBox1.Text + "' ", con);
            MySqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            this.label36.Text = dr2[0].ToString();
            dr2.Close();
            con.Close();

            con.Open();
           MySqlCommand cmd3 = new MySqlCommand("select * from agent where id= '" + this.label36.Text + "' ", con);
            MySqlDataReader dr3 = cmd3.ExecuteReader();
            dr3.Read();
            this.label37.Text = dr3[0].ToString();
            this.label38.Text = dr3[1].ToString();
            this.label39.Text = dr3[2].ToString();
            dr3.Close();
            
            con.Close();

            con.Open();
            MySqlCommand cmd4 = new MySqlCommand("select * from claimant where ph_id= '" + this.comboBox1.Text + "' ", con);
            MySqlDataReader dr4 = cmd4.ExecuteReader();
            dr4.Read();
            this.label47.Text = dr4[0].ToString();
            this.label48.Text = dr4[1].ToString();
            this.label49.Text = dr4[4].ToString();
            this.label50.Text = dr4[5].ToString();
            this.label51.Text = dr4[6].ToString();
            this.label52.Text = dr4[7].ToString();
            this.label53.Text = dr4[8].ToString();
            dr1.Close();
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }
    }
}
