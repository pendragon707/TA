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
    public partial class Ta : Form
    {
        private SqlConnection conn;
        public Ta(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void Ta_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Inspector". При необходимости она может быть перемещена или удалена.
            this.inspectorTableAdapter.Fill(this.tADataSet.Inspector);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Regions". При необходимости она может быть перемещена или удалена.
            this.regionsTableAdapter.Fill(this.tADataSet.Regions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Location". При необходимости она может быть перемещена или удалена.
            this.locationTableAdapter.Fill(this.tADataSet.Location);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Driver". При необходимости она может быть перемещена или удалена.
            this.driverTableAdapter.Fill(this.tADataSet.Driver);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Vehicle". При необходимости она может быть перемещена или удалена.
            this.vehicleTableAdapter.Fill(this.tADataSet.Vehicle);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Participants". При необходимости она может быть перемещена или удалена.
            this.participantsTableAdapter.Fill(this.tADataSet.Participants);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.Witness". При необходимости она может быть перемещена или удалена.
            this.witnessTableAdapter.Fill(this.tADataSet.Witness);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tADataSet.TA". При необходимости она может быть перемещена или удалена.
            this.tATableAdapter.Fill(this.tADataSet.TA);

        }

      /*  private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                tATableAdapter.Update(this.tADataSet.TA);
                this.Validate();
                this.tABindingSource.EndEdit();
                this.tATableAdapter.Update(this.tADataSet.TA);

                participantsTableAdapter.Update(this.tADataSet.Participants);
                this.Validate();
                this.fRPartTABindingSource.EndEdit();
                this.participantsTableAdapter.Update(this.tADataSet.Participants);

                witnessTableAdapter.Update(this.tADataSet.Witness);
                this.Validate();
                this.fRWitnTABindingSource.EndEdit();
                this.witnessTableAdapter.Update(this.tADataSet.Witness);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }*/

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void end_edit_wit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                witnessTableAdapter.Update(this.tADataSet.Witness);
                this.Validate();
                this.fRWitnTABindingSource.EndEdit();
                this.witnessTableAdapter.Update(this.tADataSet.Witness);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }

        private void end_edit_part(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                participantsTableAdapter.Update(this.tADataSet.Participants);
                this.Validate();
                this.fRPartTABindingSource.EndEdit();
                this.participantsTableAdapter.Update(this.tADataSet.Participants);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }

        private void end_edit_ta(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tATableAdapter.Update(this.tADataSet.TA);
                this.Validate();
                this.tABindingSource.EndEdit();
                this.tATableAdapter.Update(this.tADataSet.TA);

                locationTableAdapter.Update(this.tADataSet.Location);
                this.Validate();
                this.locationBindingSource.EndEdit();
                this.locationTableAdapter.Update(this.tADataSet.Location);
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id_location;
            SqlCommand command = new SqlCommand(
        @"Select IDlocation from dbo.[Location] where
        Town = @Town and Street = @Street and IdRegion = @IdRegion", conn);
            command.Parameters.Add("@Town", SqlDbType.VarChar);
            command.Parameters.Add("@Street", SqlDbType.VarChar);
            command.Parameters.Add("@IdRegion", SqlDbType.Int);
            command.Parameters["@Town"].Value = comboBox3.Text;
            command.Parameters["@Street"].Value = comboBox4.Text;
            command.Parameters["@IdRegion"].Value = comboBox1.SelectedValue;
            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.HasRows && reader.Read())
            {
                //MessageBox.Show(@"1", Program.error0, MessageBoxButtons.YesNo);
                id_location = (int)reader["IDlocation"];
                reader.Close();
            }
            else
            {               
                reader.Close();
                //MessageBox.Show(@"2", Program.error0, MessageBoxButtons.YesNo);
                command = new SqlCommand(
                    @"Insert into dbo.[Location](Town, Street, IdRegion) 
                    Values(@Town, @Street, @IdRegion); SELECT CAST(scope_identity() AS int)", conn);
                command.Parameters.Add("@Town", SqlDbType.VarChar);
                command.Parameters.Add("@Street", SqlDbType.VarChar);
                command.Parameters.Add("@IdRegion", SqlDbType.Int);
                command.Parameters["@Town"].Value = comboBox3.Text;
                command.Parameters["@Street"].Value = comboBox4.Text;
                command.Parameters["@IdRegion"].Value = comboBox1.SelectedValue;
                id_location = (Int32)command.ExecuteScalar();
            }

                this.locationTableAdapter.Fill(this.tADataSet.Location);

                command = new SqlCommand(
                    @"Insert into dbo.[TA](IdLocation, IdInspector, DateOfAccident,
                    KindOfAccident, Weather, Illumination, StateOfRoad, AnotherCircumstances) 
                    Values(@Location, @Insp, @Date, @Kind, @Weather, @Illumination,
                    @StateOfRoad, @AnotherCircumstances)", conn);
            command.Parameters.Add("@Location", SqlDbType.Int);
            command.Parameters.Add("@Insp", SqlDbType.Int);
            command.Parameters.Add("@Date", SqlDbType.DateTime);
            command.Parameters.Add("@Kind", SqlDbType.VarChar);
            command.Parameters.Add("@Weather", SqlDbType.VarChar);
            command.Parameters.Add("@Illumination", SqlDbType.VarChar);
            command.Parameters.Add("@StateOfRoad", SqlDbType.VarChar);
            command.Parameters.Add("@AnotherCircumstances", SqlDbType.VarChar);
            command.Parameters["@Location"].Value = id_location;
            command.Parameters["@Insp"].Value = comboBox2.SelectedValue;
            command.Parameters["@Date"].Value = dateTimePicker1.Value;
            command.Parameters["@Kind"].Value = comboBox5.Text;
            command.Parameters["@Weather"].Value = textBox1.Text;
            command.Parameters["@Illumination"].Value = textBox2.Text;
            command.Parameters["@StateOfRoad"].Value = textBox4.Text;
            command.Parameters["@AnotherCircumstances"].Value = richTextBox2.Text;

            command.ExecuteNonQuery();

            this.tATableAdapter.Fill(this.tADataSet.TA);          
            }
            catch (Exception e2)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Program.error2, Program.error0, buttons);
                return;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] s = new string[11];
            int selRowNum = dataGridView1.CurrentCell.RowIndex;
            int id = (int)dataGridView1.Rows[selRowNum].Cells[0].Value;

            SqlCommand command = new SqlCommand(
            @"Select Street, Town, RegionName, NameOfTheInspector  from dbo.[Location], dbo.[Regions], dbo.[TA], dbo.Inspector
                         WHERE (TA.IdTA = @ID) and (Location.IdLocation = Ta.IdLocation)
                            and (Regions.IdRegion = Location.IdRegion)
                            and (Inspector.IDinspector = TA.IdInspector)", conn);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                for (int i = 0; i < 4; i++)
                {
                    s[i] = reader[i].ToString();
                }
            }
            reader.Close();
            int k = 3;
            for(int i = 4; i < 11; i++, k++)
            {
                s[i] = (i != 4) ?
                    dataGridView1.Rows[selRowNum].Cells[k].Value.ToString() :
                    ((DateTime)dataGridView1.Rows[selRowNum].Cells[k].Value).ToString("dd.MM.yyyy");
                if (s[i] == "") s[i] = " - ";
            }
            Program.sas(new TA_one(s, id), this);

            


        }
    }
}
