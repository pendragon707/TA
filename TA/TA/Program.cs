using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TA
{
    static class Program
    {
        static public string error0 = "Ошибка";
        static public string error1 = "Ошибка соединения с базой данных";
        static public string error2 = "Ошибка занесения в базу данных";

         static public bool is_chief;
         /*static public Form_insp insp;
         static public Form_chief chief;
         static public report report;
         static public Driver driver;
         static public Ta ta;
         static public Vehicle vehicle;*/
         static public auth auth;

        static public SqlConnection conn;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        static public void sas<T, Z>(T form, Z t) where T : Form where Z : Form
        {
            form.FormClosed += (object _sender, FormClosedEventArgs _e) => { t.Show(); };
            form.Show();
            t.Hide();
        }


        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            conn = new SqlConnection("Data Source=SERGEY297;Initial Catalog=TA;Integrated Security=True"); //DBUtils.GetDBConnection();
                      try
                      {
                          conn.Open();
                      }
                      catch (Exception e)
                      {
                          MessageBoxButtons buttons = MessageBoxButtons.OK;
                          MessageBox.Show(error1, error0, buttons);
                          return;
                      }

           /* insp = new Form_insp();
            chief = new Form_chief();
            report = new report();
            ta = new Ta();
            vehicle = new Vehicle(conn);
            driver = new Driver(conn);*/
            auth = new auth(conn);
            Application.Run(auth);
        }
    }
}
