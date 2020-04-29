﻿using System;
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
    public partial class Inspector : Form
    {
        private SqlConnection conn;
        public Inspector(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void Inspector_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Inspector". При необходимости она может быть перемещена или удалена.
            this.inspectorTableAdapter.Fill(this.tADataSet.Inspector);

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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                    @"Insert into dbo.[Inspector](NameOfTheInspector, RankOfInspector) 
                    Values(@Name, @Rank)", conn);
            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters.Add("@Rank", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = textBox1.Text;
            command.Parameters["@Rank"].Value = textBox2.Text;

            command.ExecuteNonQuery();
        }

        private void end_edit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                inspectorTableAdapter.Update(this.tADataSet.Inspector);
                this.Validate();
                this.inspectorBindingSource.EndEdit();
                this.inspectorTableAdapter.Update(this.tADataSet.Inspector);
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