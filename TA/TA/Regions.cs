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
    public partial class Regions : Form
    {
        public Regions()
        {
            InitializeComponent();
        }

        private void Regions_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Regions". При необходимости она может быть перемещена или удалена.
            this.regionsTableAdapter.Fill(this.tADataSet.Regions);

        }

        private void end_edit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                regionsTableAdapter.Update(this.tADataSet.Regions);
                this.Validate();
                this.regionsBindingSource.EndEdit();
                this.regionsTableAdapter.Update(this.tADataSet.Regions);
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
