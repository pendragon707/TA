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
            if (Program.is_chief)
            {
                Program.sas(new Form_chief(), this);
            }
            else
            {
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
    }
}
