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
    public partial class Insp_one : Form
    {
        public Insp_one(int id)
        {
            InitializeComponent();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(
            @"Select NameOfTheInspector, RankOfInspector
            FROM dbo.Inspector WHERE
            (Inspector.IDinspector = @ID)", Program.conn);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;
            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows && reader.Read())
            {
                label1.Text = reader["NameOfTheInspector"].ToString();
                label3.Text = reader["RankOfInspector"].ToString();
            }
            reader.Close();

            command = new SqlCommand(
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
