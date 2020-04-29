using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace TA
{
    public partial class auth : Form
    {
        static string error0 = "Ошибка";
        static string error1 = "Введите логин и пароль";
        static string error2 = "Неверный логин или пароль";

        private SqlConnection conn;

        public auth(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show(error1, error0, MessageBoxButtons.OK);
            }
            else
            {
                SqlCommand command = new SqlCommand(
                    @"SELECT * FROM Users WHERE Username = @User and Password = @Pass;", conn);
                command.Parameters.Add("@User", SqlDbType.VarChar);
                command.Parameters.Add("@Pass", SqlDbType.VarChar);
                command.Parameters["@User"].Value = textBox1.Text;
                command.Parameters["@Pass"].Value = textBox2.Text;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
     
                    if ((bool)reader["IsAdmin"])
                    {
                        Program.is_chief = true;
                        Form_chief c = new Form_chief();
                        c.FormClosed += (object _sender, FormClosedEventArgs _e) => { this.Show(); };
                        c.Show();
                        this.Hide();
                    }
                    else
                    {
                        Program.is_chief = false;
                        Form_insp c = new Form_insp();
                        c.FormClosed += (object _sender, FormClosedEventArgs _e) => { this.Show(); };
                        c.Show();
                        this.Hide();
                    }
                }           
                else MessageBox.Show(error2, error0, MessageBoxButtons.OK);
                reader.Close();
            }
        }
    }
}
