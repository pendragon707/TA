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
    public partial class Witness : Form
    {
        public Witness()
        {
            InitializeComponent();
        }

        private void Witness_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Witness". При необходимости она может быть перемещена или удалена.
            this.witnessTableAdapter.Fill(this.tADataSet.Witness);

        }

        private void end_edit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                witnessTableAdapter.Update(this.tADataSet.Witness);
                this.Validate();
                this.witnessBindingSource.EndEdit();
                this.witnessTableAdapter.Update(this.tADataSet.Witness);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
