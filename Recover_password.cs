using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Center_education
{
    public partial class Recover_password : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Center_education";
        public Recover_password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string login = textBox_login.Text;
                string password = textBox_new_password.Text;
                connection.Open();

                string request = ("UPDATE users SET password = @password WHERE login = @login");
                using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Пароль изменён"); this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении данных в базу данных: " + ex.Message);
                    }
                }
                connection.Close();
            }
        }
    }
}
