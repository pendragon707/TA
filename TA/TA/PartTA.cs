using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TA
{
    public partial class PartTA : Form
    {
        public PartTA()
        {
            InitializeComponent();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(@"SELECT dbo.[Location].Town, Count(dbo.[TA].IdTA) AS NumTA 
            FROM dbo.[Location], dbo.TA 
            WHERE (dbo.TA.IdLocation = dbo.[Location].IDlocation)
	        GROUP BY dbo.[Location].Town;", Program.conn);

            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);
           

            //partTATableAdapter.Fill(tADataSet.PartTA);
            chart1.Series["Series1"].XValueMember = "Town";//(tADataSet.PartTA.Columns[0]).ToString();
            chart1.Series["Series1"].YValueMembers = "NumTA";//(tADataSet.PartTA.Columns[1]).ToString();
            chart1.DataSource = dataSet;
            chart1.DataBind();
        }


    }
}
