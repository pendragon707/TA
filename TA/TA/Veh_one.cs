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
    public partial class Veh_one : Form
    {
        public Veh_one(int id)
        {
            InitializeComponent();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(
            @"Select LicensePlate, KindOfTheVehicle, UsefulLife, TechnicalCondition, RegionName
            FROM dbo.Vehicle, dbo.Regions WHERE
            (Vehicle.IdVehicle = @ID) and (Vehicle.IdRegion = Regions.IdRegion);", Program.conn);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;
            SqlDataReader reader = command.ExecuteReader();

            string[] s = new string[10];
            int k = 1;
            if (reader.HasRows && reader.Read())
            {
                    label1.Text = "Регистрационный номер: " + reader["LicensePlate"].ToString();
                for(int i = 0; i < 4; i++, k++)
                    s[i] = reader[k].ToString();
            }
            reader.Close();
            string[] s2 = new string[10];
            s2[0] = "Вид ТС";
            s2[1] = "Эксплуатация (годы)";
            s2[2] = "Техническое состояние";
            s2[3] = "Регион";
            label2.Text = String.Join("\n\n", s2);

            label3.Text = String.Join("\n\n", s);

            command = new SqlCommand(
            @"SELECT DateOfAccident as 'Дата ДТП', KindOfAccident as 'Вид ДТП', 
            Street as 'Улица', Town as 'Город', RegionName as 'Регион'
            From dbo.TA, dbo.Participants, dbo.Location, dbo.Regions
            WHERE (Participants.IdVehicle = @ID) 
            and (TA.IdTA = Participants.IdTA)
            and (Location.IdLocation = TA.IdLocation)
            and (Regions.IdRegion = Location.IdRegion);", Program.conn);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;

            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);
        }
    }
}
