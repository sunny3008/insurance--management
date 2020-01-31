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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        public static string sname, snamer, sbeam,sname1,sbeam1;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection("server=localhost;user id=root;password=root;database=insurance");
                con.Open();
                //MySqlCommand cmd = new MySqlCommand("select id from agent", con);
                //MySqlDataReader dr = cmd.ExecuteReader();
                //while (dr.Read())
                //{
                //   comboBox1.Items.Add(dr[0].ToString());
                ///
                // }
                // dr.Close();
                con.Close();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
               if(textBox1.Text == "u1" && textBox2.Text == "1")
               {
               


                Form2 frm2 = new Form2();
                //frm2.MdiParent = this.MdiParent;
               frm2.Show();
               this.Close();

                }
           
            else
            {
                MessageBox.Show("WRONG PASSWORD OR USERNAME");
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            agent_log frm21 = new agent_log();
            //frm2.MdiParent = this.MdiParent;
            frm21.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
