using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Center_education
{

    public partial class Registration : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Center_education";
        public Registration()
        {
            InitializeComponent();
            LoadDataIntoComboBox();
        }
        private void LoadDataIntoComboBox()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("Select name from role", connection);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Добавляем значения из колонки в ComboBox
                            comboBox_post.Items.Add(reader["name"].ToString());
                        }
                    }

                connection.Close();
            }
        }
        private bool Check_existence()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string login = textBox_login.Text;
                connection.Open();

                string request = ("Select id from users where \"login\"=@login");
                using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Такой логин уже занят");
                        return false;
                    }
                }
                connection.Close();
            }
            return true;
                
        }
        private bool Check_password()
        {
            string password = textBox_password.Text;
            if (IsValidString(password))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Пароль должен содержать 5 букв, 3 цифры и один из знаков «@#%)(.<»");
                return false;
            }


            bool IsValidString(string input)
            {
                // Регулярное выражение для проверки условий
                string pattern = @"^(?=(.*[a-zA-Z]){5})(?=(.*\d){3})(?=.*[@#%)(.<])";
                Regex regex = new Regex(pattern);

                return regex.IsMatch(input);
            }
        }
        private bool Check_combobox()
        {
            if (comboBox_post.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите должность");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button_back_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.FormClosed += (s, args) => Close();
            authorization.Show();
        }

        private void comboBox_post_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button_reg_Click(object sender, EventArgs e)
        {
            if(Check_existence() == true && Check_password() == true && Check_combobox() )
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    int role = comboBox_post.SelectedIndex + 1;
                    string login = textBox_login.Text;
                    string password = textBox_password.Text;
                    string insertQuery = "INSERT INTO users (id_role, login, password) VALUES (@role, @login, @password)";
                    using (NpgsqlCommand command = new NpgsqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@role", role);
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Вы успешно зарегистрированы.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при добавлении данных в базу данных: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
