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
    public partial class TA_one : Form
    {
        public TA_one(string[] s, int id)
        {
            InitializeComponent();

            label3.Text = "ДТП №" + id.ToString();

            label1.Text = String.Join("\n\n", s);
            string[] l2 = new string[11];
            l2[0] = "Улица";
            l2[1] = "Город";
            l2[2] = "Регион";
            l2[3] = "Инспектор";
            l2[4] = "Дата ДТП";
            l2[5] = "Вид ДТП";
            l2[6] = "Погода";
            l2[7] = "Освещение";
            l2[8] = "Состояние дороги";
            l2[9] = "Другие подробности";
            label2.Text = String.Join("\n\n", l2);

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(
            @"SELECT FullName as 'ФИО', KindOfTheVehicle as 'ТС', 
            LicensePlate as 'Номер ТС'
            From dbo.Participants, dbo.Driver, dbo.Vehicle
            WHERE (Participants.IdTA = @ID) 
            and (Driver.IdDriver = Participants.IdDriver)
            and (Vehicle.IdVehicle = Participants.IdVehicle);", Program.conn);
            command.Parameters.Add("@ID", SqlDbType.VarChar);
            command.Parameters["@ID"].Value = id;

            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);

            command = new SqlCommand(
            @"SELECT FullName as 'ФИО', Testimony as 'Показания'
            from dbo.Witness, dbo.TA
            WHERE (TA.IdTA = @ID) 
            and (Witness.IDta = TA.IdTA);", Program.conn);
            command.Parameters.Add("@ID", SqlDbType.VarChar);
            command.Parameters["@ID"].Value = id;

            adapter.SelectCommand = command;
            DataSet dataSet2 = new DataSet();
            adapter.Fill(dataSet2);
            dataGridView2.DataSource = dataSet2.Tables[0];
            adapter.Update(dataSet2);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
