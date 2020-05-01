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
    public partial class TaDate : Form
    {
        public TaDate()
        {
            InitializeComponent();
        }

        private void TaDate_Load(object sender, EventArgs e)
        {
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(@"SELECT * FROM dbo.TA WHERE 
            DateOfAccident BETWEEN @Date1 AND @Date2", Program.conn);
            command.Parameters.Add("@Date1", SqlDbType.VarChar);
            command.Parameters.Add("@Date2", SqlDbType.VarChar);
            command.Parameters["@Date1"].Value = dateTimePicker1.Value;
            command.Parameters["@Date2"].Value = dateTimePicker2.Value;

            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2_ValueChanged(null, null);
        }
    }
}
