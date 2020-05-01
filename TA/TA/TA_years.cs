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
    public partial class TA_years : Form
    {
        public TA_years()
        {
            InitializeComponent();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(@"SELECT YEAR(DateOfAccident) AS 'Год', 
            Count(dbo.[TA].IdTA) AS 'Количество ДТП' 
            FROM dbo.TA 
	        GROUP BY YEAR(DateOfAccident);", Program.conn);

            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);


            //partTATableAdapter.Fill(tADataSet.PartTA);
            chart1.Series["Series1"].XValueMember = "Год";//(tADataSet.PartTA.Columns[0]).ToString();
            chart1.Series["Series1"].YValueMembers = "Количество ДТП";//(tADataSet.PartTA.Columns[1]).ToString();
            chart1.DataSource = dataSet;
            chart1.DataBind();
        }
    }
}
