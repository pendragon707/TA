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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Regions". При необходимости она может быть перемещена или удалена.
            this.regionsTableAdapter.Fill(this.tADataSet.Regions);
            this.vehicleTableAdapter.Fill(this.tADataSet.Vehicle);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                        @"Insert into dbo.[Vehicle](KindOfTheVehicle, UsefulLife, 
                TechnicalCondition, LicensePlate, IdRegion) 
                Values(@Kind, @Life, @Cond, @Num, @Reg)", conn);
                command.Parameters.Add("@Kind", SqlDbType.VarChar);
                command.Parameters.Add("@Life", SqlDbType.Int);
                command.Parameters.Add("@Cond", SqlDbType.VarChar);
                command.Parameters.Add("@Num", SqlDbType.VarChar);
                command.Parameters.Add("@Reg", SqlDbType.Int);
                command.Parameters["@Kind"].Value = comboBox2.Text;
                command.Parameters["@Life"].Value = (int)numericUpDown1.Value;
                command.Parameters["@Cond"].Value = richTextBox1.Text;
                command.Parameters["@Num"].Value = textBox4.Text;
                command.Parameters["@Reg"].Value = comboBox1.SelectedValue;

                command.ExecuteNonQuery();

                this.regionsTableAdapter.Fill(this.tADataSet.Regions);
                this.vehicleTableAdapter.Fill(this.tADataSet.Vehicle);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }

            //   ClientsListViewTableAdapter.Fill();о
            //vehicleTableAdapter.Update(this.tADataSet.Vehicle);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void end_edit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vehicleTableAdapter.Update(this.tADataSet.Vehicle);
                this.Validate();
                this.vehicleBindingSource1.EndEdit();
                this.vehicleTableAdapter.Update(this.tADataSet.Vehicle);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }

        int[] random_num(int len)
        {
            Random rnd = new Random();
            int[] number = new int[len];
            for (int i = 0; i < len; i++)
            {
                number[i] = rnd.Next(0, 9);
            }
            return number;
        }

        char[] random_str(int len)
        {
            Random rnd = new Random();
            char[] str = new char[len];
            for (int i = 0; i < len; i++)
            {
                str[i] = (char) rnd.Next(1040, 1071);
            }
            return str;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            char one = (char)rnd.Next(1040, 1071);
            int[] s_two = new int[3];
            s_two = random_num(3);
            char[] s_three = new char[2];
            s_three = random_str(2);
            int four;

            SqlCommand command = new SqlCommand(
                    @"SELECT RegionCode FROM Regions WHERE IdRegion = @Reg", conn);
            command.Parameters.Add("@Reg", SqlDbType.Int);
            command.Parameters["@Reg"].Value = comboBox1.SelectedValue;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows && reader.Read())
                four = (int)reader["RegionCode"];
            else four = 750;
            reader.Close();

            textBox4.Text = one.ToString() + s_two[0].ToString() 
                + s_two[1].ToString() + s_two[2].ToString() + 
                s_three[0].ToString() + s_three[1].ToString() + four.ToString();
        }
    }
}
