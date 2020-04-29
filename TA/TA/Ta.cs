using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA
{
    public partial class Ta : Form
    {
        public Ta()
        {
            InitializeComponent();
        }

        private void Ta_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Regions". При необходимости она может быть перемещена или удалена.
            this.regionsTableAdapter.Fill(this.tADataSet.Regions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Location". При необходимости она может быть перемещена или удалена.
            this.locationTableAdapter.Fill(this.tADataSet.Location);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Driver". При необходимости она может быть перемещена или удалена.
            this.driverTableAdapter.Fill(this.tADataSet.Driver);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Vehicle". При необходимости она может быть перемещена или удалена.
            this.vehicleTableAdapter.Fill(this.tADataSet.Vehicle);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Participants". При необходимости она может быть перемещена или удалена.
            this.participantsTableAdapter.Fill(this.tADataSet.Participants);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Witness". При необходимости она может быть перемещена или удалена.
            this.witnessTableAdapter.Fill(this.tADataSet.Witness);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.TA". При необходимости она может быть перемещена или удалена.
            this.tATableAdapter.Fill(this.tADataSet.TA);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            end_edit(sender, null);
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

      /*  private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                tATableAdapter.Update(this.tADataSet.TA);
                this.Validate();
                this.tABindingSource.EndEdit();
                this.tATableAdapter.Update(this.tADataSet.TA);

                participantsTableAdapter.Update(this.tADataSet.Participants);
                this.Validate();
                this.fRPartTABindingSource.EndEdit();
                this.participantsTableAdapter.Update(this.tADataSet.Participants);

                witnessTableAdapter.Update(this.tADataSet.Witness);
                this.Validate();
                this.fRWitnTABindingSource.EndEdit();
                this.witnessTableAdapter.Update(this.tADataSet.Witness);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }*/

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void end_edit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tATableAdapter.Update(this.tADataSet.TA);
                this.Validate();
                this.tABindingSource.EndEdit();
                this.tATableAdapter.Update(this.tADataSet.TA);

                participantsTableAdapter.Update(this.tADataSet.Participants);
                this.Validate();
                this.fRPartTABindingSource.EndEdit();
                this.participantsTableAdapter.Update(this.tADataSet.Participants);

                witnessTableAdapter.Update(this.tADataSet.Witness);
                this.Validate();
                this.fRWitnTABindingSource.EndEdit();
                this.witnessTableAdapter.Update(this.tADataSet.Witness);

                locationTableAdapter.Update(this.tADataSet.Location);
                this.Validate();
                this.locationBindingSource.EndEdit();
                this.locationTableAdapter.Update(this.tADataSet.Location);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
