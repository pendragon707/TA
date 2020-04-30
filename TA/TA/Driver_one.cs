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
    public partial class Driver_one : Form
    {
        public Driver_one(int id, string name, string date, string rights, string region)
        {
            InitializeComponent();

            label1.Text = name;
            label2.Text = date;
            label3.Text = rights;
            label4.Text = region;

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(
            @"SELECT DateOfAccident as 'Дата ДТП', KindOfAccident as 'Вид ДТП', 
            Street as 'Улица', Town as 'Город', RegionName as 'Регион'
            From dbo.TA, dbo.Participants, dbo.Location, dbo.Regions
            WHERE (Participants.IdDriver = @ID) 
            and (TA.IdTA = Participants.IdTA)
            and (Location.IdLocation = TA.IdLocation)
            and (Regions.IdRegion = Location.IdRegion);", Program.conn);
            command.Parameters.Add("@ID", SqlDbType.VarChar);
            command.Parameters["@ID"].Value = id;

            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);
        }

    }
}
