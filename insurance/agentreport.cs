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
    public partial class agentreport : Form
    {
        public agentreport()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void agentreport_Load(object sender, EventArgs e)
        {
            
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            label2.Text = Form4.agent;
            var conStr = "server=localhost;user id=root;password=root;database=insurance";
            MySqlConnection cnn = new MySqlConnection(conStr);
            cnn.Open();
            var sql = "select  agent_id,commission,ph_id,pol_key from sales where agent_id='" + this.label2.Text +"'";
            MySqlDataAdapter dscmd = new MySqlDataAdapter(sql, cnn);
            cnn.Close();
            DataSet2 ds = new DataSet2();
            dscmd.Fill(ds, "DataTable1");
            CrystalReport2 objRpt = new CrystalReport2();
            objRpt.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = objRpt;
            cnn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
