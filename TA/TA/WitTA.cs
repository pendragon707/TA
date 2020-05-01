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
    public partial class WitTA : Form
    {
        public WitTA()
        {
            InitializeComponent();
            numericUpDown1_ValueChanged(null, null);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            label1.Text = "ДТП №" + id.ToString();

            string[] s1 = new string[20];
            string[] s2 = new string[20];
            int i = 0;
            SqlCommand command = new SqlCommand(
           @"Select FullName, Testimony from dbo.Witness
            WHERE (Witness.IdTA = @ID);", Program.conn);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    s1[i] = reader["FullName"].ToString();
                    s2[i] = reader["Testimony"].ToString();
                    i++;
                }
            }
            else
            {
                s1[0] = " - ";
                s2[0] = " - ";
            }
            reader.Close();

            label2.Text = String.Join("\n\n", s1);
            label3.Text = String.Join("\n\n", s2);
        }
    }
}
