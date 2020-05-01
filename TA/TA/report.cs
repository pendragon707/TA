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
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.sas(new TA_years(), this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.sas(new TaDate(), this);
        }

        private void report_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.sas(new WitTA(), this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.sas(new DrReg(), this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.sas(new PartTA(), this);
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
