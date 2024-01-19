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
        public string login { get; set; }
        public Manager()
        {
            InitializeComponent();
            LoadDataIntoComboBox();
            LoadData();
            label2.Text = login;
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
        private void ButtonInsert_Click()
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
        private void LoadDataIntoComboBox()
        {
            comboBox_table.Items.Add("educational_program");
            comboBox_table.Items.Add("individual");
        }
        private void button_update_table_Click(object sender, EventArgs e)
        {
            LoadData();
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
    }
}
