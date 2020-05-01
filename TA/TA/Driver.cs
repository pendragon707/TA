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
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                        @"Insert into dbo.[Driver](FullName, DateOfIssueResidenceRights, 
                    LicenceCategories, IdRegion) 
                    Values(@Name, @Date, @Num, @ID)", conn);
                command.Parameters.Add("@Name", SqlDbType.VarChar);
                command.Parameters.Add("@Date", SqlDbType.DateTime);
                command.Parameters.Add("@Num", SqlDbType.VarChar);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@Name"].Value = textBox2.Text;
                command.Parameters["@Date"].Value = dateTimePicker1.Value;
                command.Parameters["@Num"].Value = textBox4.Text;
                command.Parameters["@ID"].Value = comboBox1.SelectedValue;

                command.ExecuteNonQuery();
                
                this.locationTableAdapter.Fill(this.tADataSet.Location);
                this.regionsTableAdapter.Fill(this.tADataSet.Regions);
                this.driverTableAdapter.Fill(this.tADataSet.Driver);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }

        private void end_edit(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                driverTableAdapter.Update(this.tADataSet.Driver);
                this.Validate();
                this.driverBindingSource.EndEdit();
                this.driverTableAdapter.Update(this.tADataSet.Driver);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selRowNum = dataGridView1.CurrentCell.RowIndex;
            int id = (int) dataGridView1.Rows[selRowNum].Cells[0].Value;
            string name = dataGridView1.Rows[selRowNum].Cells[1].Value.ToString();
            string date = ((DateTime)dataGridView1.Rows[selRowNum].Cells[2].Value).ToString("dd.MM.yyyy");
            string rights = dataGridView1.Rows[selRowNum].Cells[3].Value.ToString();
            string region;
            SqlCommand command = new SqlCommand(
                        @"Select * from dbo.[Regions]
                         WHERE Regions.IdRegion = @Reg", conn);
            command.Parameters.Add("@Reg", SqlDbType.Int);
            if (dataGridView1.Rows[selRowNum].Cells[4].Value.ToString() == "")
                region = " - ";
            else
            {
                command.Parameters["@Reg"].Value = dataGridView1.Rows[selRowNum].Cells[4].Value.ToString(); ;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    region = reader["RegionName"].ToString();
                }
                else region = " - ";
                reader.Close();
            }
            Program.sas(new Driver_one(id, name, date, rights, region), this);
        }
    }
}
