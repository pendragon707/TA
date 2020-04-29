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
    public partial class Driver : Form
    {
        private SqlConnection conn;
        public Driver(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }
        private void Driver_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Location". При необходимости она может быть перемещена или удалена.
            this.locationTableAdapter.Fill(this.tADataSet.Location);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Regions". При необходимости она может быть перемещена или удалена.
            this.regionsTableAdapter.Fill(this.tADataSet.Regions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Driver". При необходимости она может быть перемещена или удалена.
            this.driverTableAdapter.Fill(this.tADataSet.Driver);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5_TextChanged(null, null);
            /*
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(
                    @"SELECT * FROM Driver WHERE (FullName LIKE @Name);", conn);
            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = String.Format("%{0}%", textBox5.Text);
            

            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Program.is_chief)
            {
                //Program.chief.Show();
                Program.sas(new Form_chief(), this);
            }
            else
            {
                //Program.insp.Show();
                Program.sas(new Form_insp(), this);
            }
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            //dbo.Driver, dbo.Regions WHERE Regions.IdRegion = Driver.IdRegion
            SqlCommand command = new SqlCommand(
@"SELECT IdDriver as '№ водителя', FullName as ФИО, DateOfIssueResidenceRights as 'Дата получения прав', LicenceCategories as 'Категория прав',
RegionName as Регион FROM Driver, Regions
WHERE (FullName LIKE @Name) and (Regions.IdRegion = Driver.IdRegion);", conn);
            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = String.Format("%{0}%", textBox5.Text);

            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                        @"Insert into dbo.[Driver](FullName, DateOfIssueResidenceRights, 
                    LicenceCategories) 
                    Values(@Name, @Date, @Num)", conn);
                command.Parameters.Add("@Name", SqlDbType.VarChar);
                command.Parameters.Add("@Date", SqlDbType.DateTime);
                command.Parameters.Add("@Num", SqlDbType.VarChar);
                command.Parameters["@Name"].Value = textBox2.Text;
                command.Parameters["@Date"].Value = dateTimePicker1.Value;
                command.Parameters["@Num"].Value = textBox4.Text;

                command.ExecuteNonQuery();
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }
    }
}
