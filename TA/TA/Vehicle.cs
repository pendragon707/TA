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
    public partial class Vehicle : Form
    {
        private SqlConnection conn;
        public Vehicle(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void Vehicle_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Regions". При необходимости она может быть перемещена или удалена.
            this.regionsTableAdapter.Fill(this.tADataSet.Regions);
            this.vehicleTableAdapter.Fill(this.tADataSet.Vehicle);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                        @"Insert into dbo.[Vehicle](KindOfTheVehicle, UsefulLife, 
                TechnicalCondition, LicensePlate, IdRegion) 
                Values(@Kind, @Life, @Cond, @Num, @Reg)", conn);
                command.Parameters.Add("@Kind", SqlDbType.VarChar);
                command.Parameters.Add("@Life", SqlDbType.Int);
                command.Parameters.Add("@Cond", SqlDbType.VarChar);
                command.Parameters.Add("@Num", SqlDbType.VarChar);
                command.Parameters.Add("@Reg", SqlDbType.Int);
                command.Parameters["@Kind"].Value = textBox1.Text;
                command.Parameters["@Life"].Value = (int)numericUpDown1.Value;
                command.Parameters["@Cond"].Value = richTextBox1.Text;
                command.Parameters["@Num"].Value = textBox4.Text;
                command.Parameters["@Reg"].Value = comboBox1.SelectedValue;

                command.ExecuteNonQuery();

                this.regionsTableAdapter.Fill(this.tADataSet.Regions);
                this.vehicleTableAdapter.Fill(this.tADataSet.Vehicle);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }

            //   ClientsListViewTableAdapter.Fill();о
            //vehicleTableAdapter.Update(this.tADataSet.Vehicle);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void end_edit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vehicleTableAdapter.Update(this.tADataSet.Vehicle);
                this.Validate();
                this.vehicleBindingSource1.EndEdit();
                this.vehicleTableAdapter.Update(this.tADataSet.Vehicle);
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
