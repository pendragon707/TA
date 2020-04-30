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
    public partial class Part : Form
    {
        public Part()
        {
            InitializeComponent();
        }

        private void Part_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Vehicle". При необходимости она может быть перемещена или удалена.
            this.vehicleTableAdapter.Fill(this.tADataSet.Vehicle);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Driver". При необходимости она может быть перемещена или удалена.
            this.driverTableAdapter.Fill(this.tADataSet.Driver);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Participants". При необходимости она может быть перемещена или удалена.
            this.participantsTableAdapter.Fill(this.tADataSet.Participants);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
