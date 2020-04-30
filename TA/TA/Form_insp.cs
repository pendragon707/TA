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
    public partial class Form_insp : Form
    {
        public Form_insp()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Program.sas(new report(), this);
        }

        private void button11_Click(object sender, EventArgs e)
        {
              this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.sas(new Driver(Program.conn), this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.sas(new Vehicle(Program.conn), this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.sas(new Ta(Program.conn), this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Program.sas(new osago(), this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Program.sas(new Regions(), this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.sas(new Location(), this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.sas(new Witness(), this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Program.sas(new casco(), this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.sas(new Part(), this);
        }
    }
}
