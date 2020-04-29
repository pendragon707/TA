﻿using System;
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
    public partial class Form_chief : Form
    {

        public Form_chief()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.sas(new Inspector(Program.conn), this);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.auth.Show();
            //Program.sas(new auth(Program.conn), this);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Program.sas(new report(), this);
 //         Program.report.Show();
 //         this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.sas(new Driver(Program.conn), this);
            //Program.driver.Show();
 //           this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.sas(new Vehicle(Program.conn), this);
 //           this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.sas(new Ta(Program.conn), this);
        }
    }
}
