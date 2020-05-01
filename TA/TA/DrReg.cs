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
    public partial class DrReg : Form
    {
        public DrReg()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
          

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(
                 @"SELECT TA.DateOfAccident, Driver.FullName as 'ФИО', Driver.DateOfIssueResidenceRights as 'Дата получения прав', 
                LicenceCategories as 'Категория прав', DATEDIFF(year, Driver.DateOfIssueResidenceRights, TA.DateOfAccident) as 'Водительский опыт (годы)',
                IIf(([Driver].[IdRegion] = [Location].[IdRegion]), 'Да', 'Нет') AS 'Совпадает регион ДТП с пропиской?'
                FROM dbo.Location, dbo.TA, dbo.Regions, dbo.Driver, dbo.Participants
                WHERE (Location.IDlocation = [TA].IDLocation) 
                and (Driver.IDdriver = Participants.IDdriver)
                and (Regions.IdRegion = Driver.IdRegion) 
                and([TA].IDta = Participants.IDta)
                and(TA.IDta = @ID);", Program.conn);
            command.Parameters.Add("@ID", SqlDbType.VarChar);
            command.Parameters["@ID"].Value = numericUpDown1.Value;

            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);
        }
    }
}
