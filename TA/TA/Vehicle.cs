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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Vehicle_Reg". При необходимости она может быть перемещена или удалена.
            this.vehicle_RegTableAdapter.Fill(this.tADataSet.Vehicle_Reg); /* эо уже добавлено оу */
            //this.vehicle_viewTableAdapter.Fill(this.tADataSet.Vehicle_view);
            //this.vehicleTableAdapter.Fill(this.tADataSet.Vehicle);
        }

       /* void random_num(char* number, int len, int n)
        {
            for (char i = 0; i < len; i++)
            {
                number[i] = rand() % 9;
            }
        }
        void random_str(char* number, int len, int n)
        {
            for (int i = 0; i < len; i++)
            {
                number[i] = 192 + rand() % (223 - 192 + 1);
            }
        }*/

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
            /*
            try
            {
                vehicleTableAdapter.Update(this.tADataSet.Vehicle);
                this.Validate();
                this.vehicleBindingSource.EndEdit();
                this.vehicleTableAdapter.Update(this.tADataSet.Vehicle);
            }
            catch (Exception e3)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
            */

            //   ClientsListViewTableAdapter.Fill();
            this.vehicle_RegTableAdapter.Update(this.tADataSet.Vehicle_Reg);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
