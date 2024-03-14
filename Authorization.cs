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
    public partial class Authorization : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Center_education";
        public Authorization()
        {
            InitializeComponent();
        }
        private bool Check_login()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string login = textBox_login.Text;
                connection.Open();

                string request = ("Select id from users where login=@login");
                using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        private int Check_post()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string login = textBox_login.Text;
                string request = ("Select id_role from users where login=@login");
                using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    int role = Convert.ToInt32(command.ExecuteScalar());
                    return role;
                }

            }
        }
        private void button_reg_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.FormClosed += (s, args) => Close();
            registration.Show();
        }
        public int error = 0;
        public static string login = "";
        private void button_enter_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {   if (Check_login() == true)
                {
                    login = textBox_login.Text;
                    string password = textBox_password.Text;
                    int role;
                    connection.Open();

                    string request = ("Select id_role from users where login=@login and password=@password");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        if (count > 0)
                        {
                            role = Check_post();
                            if (role == 1)
                            {
                                Admin admin = new Admin();
                                admin.FormClosed += (s, args) => Close();
                                admin.Show();
                            }
                            else
                            {
                                Manager manager = new Manager();
                                manager.FormClosed += (s, args) => Close();
                                manager.Show();
                            }
                        }
                        else
                        {
                            error = error + 1;
                            MessageBox.Show("Неверный пароль, у вас осталось ещё "+(3-error)+" попытки");
                            if (error == 3)
                            {
                                Recover_password recover = new Recover_password();
                                recover.FormClosed += (s, args) => Close();
                                recover.Show();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не зарегестрирован");
                }
                connection.Close();
            }
        }
    }
}
