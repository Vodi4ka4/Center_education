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
    public partial class Admin : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Center_education";
        public Admin()
        {
            InitializeComponent();
            LoadData();
            LoadDataIntoComboBox();
            label2.Text = Authorization.login;
        }
        private void LoadData()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // SQL-запрос для получения данных из вашей таблицы
                    string query = "SELECT * FROM " + comboBox_table.Text;
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, connection);

                    // Создание DataSet для хранения данных
                    DataSet dataSet = new DataSet();

                    // Заполнение DataSet данными из таблицы
                    dataAdapter.Fill(dataSet);

                    // Привязка данных к DataGridView
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                    // Обработка ошибки загрузки данных
                }
            }

        }
        private void Add_educztional()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("INSERT INTO educational_program (title,duration_training,qualifications,cost_training) values (@title,@duration_training,@qualifications,@cost_training)");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@title", selectedRow["title"]);
                        command.Parameters.AddWithValue("@duration_training", selectedRow["duration_training"]);
                        command.Parameters.AddWithValue("@qualifications", selectedRow["qualifications"]);
                        command.Parameters.AddWithValue("@cost_training", selectedRow["cost_training"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Add_individual()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("INSERT INTO individual (surname, first_name, patronymic, date_birth, passport, place_residence, email, phone, post, place_work) values (@surname, @first_name, @patronymic, @date_birth, @passport, @place_residence, @email, @phone, @post, @place_work)");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@surname", selectedRow["surname"]);
                        command.Parameters.AddWithValue("@first_name", selectedRow["first_name"]);
                        command.Parameters.AddWithValue("@patronymic", selectedRow["patronymic"]);
                        command.Parameters.AddWithValue("@date_birth", selectedRow["date_birth"]);
                        command.Parameters.AddWithValue("@passport", selectedRow["passport"]);
                        command.Parameters.AddWithValue("@place_residence", selectedRow["place_residence"]);
                        command.Parameters.AddWithValue("@email", selectedRow["email"]);
                        command.Parameters.AddWithValue("@phone", selectedRow["phone"]);
                        command.Parameters.AddWithValue("@post", selectedRow["post"]);
                        command.Parameters.AddWithValue("@place_work", selectedRow["place_work"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Add_contract()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("INSERT INTO contract (id_individual,date_reg,cost) values (@id_individual,@date_reg,@cost)");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id_individual", selectedRow["id_individual"]);
                        command.Parameters.AddWithValue("@date_reg", selectedRow["date_reg"]);
                        command.Parameters.AddWithValue("@cost", selectedRow["cost"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Add_contract_educat() 
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("INSERT INTO contract_educat (id_educat,id_contract) values (@id_educat,@id_contract)");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id_educat", selectedRow["id_educat"]);
                        command.Parameters.AddWithValue("@id_contract", selectedRow["id_contract"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Add_role()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("INSERT INTO role (name) values (@name)");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@name", selectedRow["name"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Add_users()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("INSERT INTO users (id_role, login, password) values (@id_role, @login, @password)");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id_role", selectedRow["id_role"]);
                        command.Parameters.AddWithValue("@login", selectedRow["login"]);
                        command.Parameters.AddWithValue("@password", selectedRow["password"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Delete_item()
        {
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            if (selectedRow != null)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("DELETE FROM " + comboBox_table.SelectedItem.ToString() + " where id = @id");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedRow["id"]);

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно удалены из базы данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при удалении данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Update_educztional()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("UPDATE educational_program SET id  = @id, title = @title, duration_training =@duration_training , qualifications = @qualifications , cost_training = @cost_training WHERE id = @id");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedRow["id"]);
                        command.Parameters.AddWithValue("@title", selectedRow["title"]);
                        command.Parameters.AddWithValue("@duration_training", selectedRow["duration_training"]);
                        command.Parameters.AddWithValue("@qualifications", selectedRow["qualifications"]);
                        command.Parameters.AddWithValue("@cost_training", selectedRow["cost_training"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно изменены в базе данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при изменении данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Update_individual()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("UPDATE individual SET (id = @id, surname = @surname, first_name = @first_name, patronymic = @patronymic, @date_birth, passport = @passport, place_residence = @place_residence, email = @email, phone = @phone, post = @post, place_work = @place_work WHERE id = @id)");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedRow["id"]);
                        command.Parameters.AddWithValue("@surname", selectedRow["surname"]);
                        command.Parameters.AddWithValue("@first_name", selectedRow["first_name"]);
                        command.Parameters.AddWithValue("@patronymic", selectedRow["patronymic"]);
                        command.Parameters.AddWithValue("@date_birth", selectedRow["date_birth"]);
                        command.Parameters.AddWithValue("@passport", selectedRow["passport"]);
                        command.Parameters.AddWithValue("@place_residence", selectedRow["place_residence"]);
                        command.Parameters.AddWithValue("@email", selectedRow["email"]);
                        command.Parameters.AddWithValue("@phone", selectedRow["phone"]);
                        command.Parameters.AddWithValue("@post", selectedRow["post"]);
                        command.Parameters.AddWithValue("@place_work", selectedRow["place_work"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно изменены в базе данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при изменении данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Update_contract()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("UPDATE contract SET id = @id, id_individual = @id_individual, date_reg = @date_reg, cost = @cost where id =@id");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedRow["id"]);
                        command.Parameters.AddWithValue("@id_individual", selectedRow["id_individual"]);
                        command.Parameters.AddWithValue("@date_reg", selectedRow["date_reg"]);
                        command.Parameters.AddWithValue("@cost", selectedRow["cost"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Update_contract_educat()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("UPDATE contract_educat SET id = @id, id_educat = @id_educat, id_contract = @id_contract WHERE id = @id");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedRow["id"]);
                        command.Parameters.AddWithValue("@id_educat", selectedRow["id_educat"]);
                        command.Parameters.AddWithValue("@id_contract", selectedRow["id_contract"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Update_role()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("UPDATE role SET id = @id, name = @name WHERE id = @id");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedRow["id"]);
                        command.Parameters.AddWithValue("@name", selectedRow["name"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void Update_users()
        {
            // Получение данных из выбранной строки в DataGridView (предположим, что у вас есть выделенная строка)
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            // Проверка, что строка была выбрана
            if (selectedRow != null)
            {
                // Создание SQL-запроса для вставки данных в таблицу

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("UPDATE users SET id = @id, id_role = @id_role, login = @login, password = @password WHERE id = @id");
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedRow["id"]);
                        command.Parameters.AddWithValue("@id_role", selectedRow["id_role"]);
                        command.Parameters.AddWithValue("@login", selectedRow["login"]);
                        command.Parameters.AddWithValue("@password", selectedRow["password"]);
                        // Добавьте параметры для остальных значений

                        try
                        {
                            // Выполнение SQL-запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке данных: " + ex.Message);
                            // Обработка ошибки вставки данных
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Выберите строку для вставки данных.");
            }
        }
        private void LoadDataIntoComboBox()
        {
            comboBox_table.Items.Add("educational_program");
            comboBox_table.Items.Add("individual");
            comboBox_table.Items.Add("contract");
            comboBox_table.Items.Add("contract_educat");
            comboBox_table.Items.Add("role");
            comboBox_table.Items.Add("users");
        }

        private void button_update_table_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (comboBox_table.SelectedIndex == 0)
            {
                Add_educztional();
            }
            if (comboBox_table.SelectedIndex == 1)
            {
                Add_individual();
            }
            if (comboBox_table.SelectedIndex == 2)
            {
                Add_contract();
            }
            if (comboBox_table.SelectedIndex == 3)
            {
                Add_contract_educat();
            }
            if (comboBox_table.SelectedIndex == 4)
            {
                Add_role();
            }
            if (comboBox_table.SelectedIndex == 5)
            {
                Add_users();
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            Delete_item();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (comboBox_table.SelectedIndex == 0)
            {
                Update_educztional();
            }
            if (comboBox_table.SelectedIndex == 1)
            {
                Update_individual();
            }
            if (comboBox_table.SelectedIndex == 2)
            {
                Update_contract();
            }
            if (comboBox_table.SelectedIndex == 3)
            {
                Update_contract_educat();
            }
            if (comboBox_table.SelectedIndex == 4)
            {
                Update_role();
            }
            if (comboBox_table.SelectedIndex == 5)
            {
                Update_users();
            }
        }
    }
}
