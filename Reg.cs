using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Center_education
{
    public class Reg
    {
        public bool Check_password(string text)
        {
            string password = text;
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
        public bool Regis (int role, string login, string password)
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Center_education";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
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
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении данных в базу данных: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
