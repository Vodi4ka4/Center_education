using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Center_education
{
    public partial class Contract : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Center_education";
        public Contract()
        {
            InitializeComponent();
            label1.Text = Authorization.login;
        }

        public static int id_contract;
        public static string title;
        public static string cost;
        private void button_contract_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            DateTime currentDate = DateTime.Now;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string request = "INSERT INTO contract (id_individual, date_reg, cost) values (@id_individual, @date_reg, @cost)";
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        command.Parameters.AddWithValue("@id_individual", Convert.ToInt32(Manager.id));
                        command.Parameters.AddWithValue("@date_reg", currentDate);
                        command.Parameters.AddWithValue("@cost", selectedRow["cost_training"]);
                        command.ExecuteNonQuery();
                    }
                    string query = "SELECT id FROM contract where id_individual = @id_individual and date_reg = @date_reg";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_individual", Convert.ToInt32(Manager.id));
                        command.Parameters.AddWithValue("@date_reg", currentDate);
                        id_contract = Convert.ToInt32(command.ExecuteScalar());
                    }
                    string reques = "INSERT INTO contract_educat (id_educat, id_contract) values (@id_educat, @id_contract)";
                    using (NpgsqlCommand command = new NpgsqlCommand(reques, connection))
                    {
                        command.Parameters.AddWithValue("@id_educat", Convert.ToInt32(selectedRow["id"]));
                        command.Parameters.AddWithValue("@id_contract", Convert.ToInt32(id_contract));
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                    // Обработка ошибки загрузки данных
                }
            }
            title = Convert.ToString(selectedRow.Row["title"]);
            cost = Convert.ToString(selectedRow.Row["cost_training"]);
            Document document = new Document();
            document.FormClosed += (s, args) => Close();
            document.Show();
        }

        private void button_update_table_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM educational_program";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
