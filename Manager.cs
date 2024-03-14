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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Center_education
{
    public partial class Manager : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Center_education";
        public Manager()
        {
            InitializeComponent();
            LoadDataIntoComboBox();
            LoadData();
            label2.Text = Authorization.login;
            button_agreement.Visible = false;
        }

        private void LoadData()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // SQL-запрос для получения данных из вашей таблицы
                    string query = "SELECT * FROM "+comboBox_table.Text;
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
        private void Add_educztional ()
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
        private void Delete_item()
        {
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            if (selectedRow != null)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string request = ("DELETE FROM "+comboBox_table.SelectedItem.ToString()+" where id = @id");
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
        private void ButtonInsert_Click()
        {
            if (comboBox_table.SelectedIndex == 0)
            {
                Add_educztional();
            }
            else
            {
                Add_individual();
            }
        }
        private void LoadDataIntoComboBox()
        {
            comboBox_table.Items.Add("educational_program");
            comboBox_table.Items.Add("individual");
        }
        private void button_update_table_Click(object sender, EventArgs e)
        {
            LoadData();
            if (comboBox_table.SelectedIndex == 1)
            {
                button_agreement.Visible = true;
            }
            else
            {
                button_agreement.Visible = false;
            }
        }

        private void comboBox_table_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            ButtonInsert_Click();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            else
            {
                Update_individual();
            }
        }
        public static int id = 0;
        public static string surname;
        public static string first_name;
        public static string patronymic;
        public static DateTime date_birth;
        public static string passport;
        public static string place_residence;
        public static string phone;
        private void button_agreement_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            id = Convert.ToInt32(selectedRow.Row["id"]);
            surname = Convert.ToString(selectedRow.Row["surname"]);
            first_name = Convert.ToString(selectedRow.Row["first_name"]);
            patronymic = Convert.ToString(selectedRow.Row["patronymic"]);
            date_birth = Convert.ToDateTime(selectedRow.Row["date_birth"]);
            passport = Convert.ToString(selectedRow.Row["passport"]);
            place_residence = Convert.ToString(selectedRow.Row["place_residence"]);
            phone = Convert.ToString(selectedRow.Row["phone"]);
            Contract contract = new Contract();
            contract.FormClosed += (s, args) => Close();
            contract.Show();
        }
    }
}
