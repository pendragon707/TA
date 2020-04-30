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
    public partial class casco : Form
    {
        public casco()
        {
            InitializeComponent();
        }

        private void casco_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Driver". При необходимости она может быть перемещена или удалена.
            this.driverTableAdapter.Fill(this.tADataSet.Driver);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Vehicle". При необходимости она может быть перемещена или удалена.
            this.vehicleTableAdapter.Fill(this.tADataSet.Vehicle);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.CASCO". При необходимости она может быть перемещена или удалена.
            this.cASCOTableAdapter.Fill(this.tADataSet.CASCO);

        }

        private void end_edit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cASCOTableAdapter.Update(this.tADataSet.CASCO);
                this.Validate();
                this.cASCOBindingSource.EndEdit();
                this.cASCOTableAdapter.Update(this.tADataSet.CASCO);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                    @"Insert into dbo.[CASCO](Insurer, Insuree, 
                    IDvehicle, IDdriver, Commencement, Duration) 
                    Values(@In1, @In2, @Veh, @Dr, @Com, @Dur)", Program.conn);
                command.Parameters.Add("@In1", SqlDbType.VarChar);
                command.Parameters.Add("@In2", SqlDbType.VarChar);
                command.Parameters.Add("@Veh", SqlDbType.Int);
                command.Parameters.Add("@Dr", SqlDbType.Int);
                command.Parameters.Add("@Com", SqlDbType.DateTime);
                command.Parameters.Add("@Dur", SqlDbType.Int);
                command.Parameters["@In1"].Value = textBox1.Text;
                command.Parameters["@In2"].Value = textBox2.Text;
                command.Parameters["@Veh"].Value = comboBox2.SelectedValue;
                command.Parameters["@Dr"].Value = comboBox1.SelectedValue;
                command.Parameters["@Com"].Value = dateTimePicker1.Value;
                command.Parameters["@Dur"].Value = (int)numericUpDown1.Value;
                command.ExecuteNonQuery();

                this.cASCOTableAdapter.Fill(this.tADataSet.CASCO);
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
