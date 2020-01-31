using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.ReportSource;
using MySql.Data.MySqlClient;

namespace insurance
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            label1.Text = Form3.ph_id;
            var conStr = "server=localhost;user id=root;password=root;database=insurance";
            MySqlConnection cnn = new MySqlConnection(conStr);
            cnn.Open();
            var sql = "select  agent_id,ph_id,name,address,phone,c_name,amount,premium,pol_dur,type,iodate from client where ph_id='" + this.label1.Text + "'";
            MySqlDataAdapter dscmd = new MySqlDataAdapter(sql, cnn);
            cnn.Close();
            DataSet1 ds = new DataSet1();
            dscmd.Fill(ds, "DataTable1");
            CrystalReport1 objRpt = new CrystalReport1();
            objRpt.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = objRpt;
            cnn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
