using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Npgsql.Internal;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace Center_education
{
    public partial class Document : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Center_education";
        private Deal deal_;
        public Document()
        {
            InitializeComponent();
            label1.Text = Authorization.login;
        }

        private void Document_Load(object sender, EventArgs e)
        {

        }
        public void Select()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string request = "SELECT surname, first_name, patronymic, date_birth, passport, place_residence, phone FROM individual where id = " + Manager.id;
                    using (NpgsqlCommand command = new NpgsqlCommand(request, connection))
                    {
                        var reader = command.ExecuteReader();
                        List<Deal> deals = new List<Deal>();
                        while (reader.Read())
                        {
                            Deal deal = new Deal();
                            deal.surname = (string)reader["surname"];
                            deal.first_name = (string)reader["first_name"];
                            deal.patronymic = (string)reader["patronymic"];
                            deal.date_birth = (DateTime)reader["date_birth"];
                            deal.passport = (string)reader["passport"];
                            deal.place_residence = (string)reader["place_residence"];
                            deal.phone = (string)reader["phone"];
                            deals.Add(deal);
                        }
                        reader.Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                    // Обработка ошибки загрузки данных
                }
            }
        }
        public void Contract_txt(string fileName, Deal deal)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            string filePath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
            }
            else
            {
                return;
            }

            using (StreamWriter contract = new StreamWriter(filePath))
            {
                contract.WriteLine("                                                      Договор оказания образовательных услуг");
                contract.WriteLine($"Г. Москва 20 сентября 2023 года");
                contract.WriteLine($"ООО «Образовательный центр», в лице генерального директора Хренова Николая Васильевича," +
                    $" действующего на основании Устава общества, именуемого в дальнейшем Исполнитель, с одной стороны");
                contract.WriteLine("И");
                contract.WriteLine($"{Manager.surname + " " + Manager.first_name + " " + Manager.patronymic}, " +
                    $"{Manager.date_birth.ToShortDateString()} года рождения, " +
                    $"проживающий по адресу: {Manager.place_residence}, " +
                    $"паспорт: {Manager.passport}, " +
                    $"выданный отделом УФМС России по Тюменской области в городе Тюмень " +
                    $"{Manager.date_birth.ToShortDateString()}, " +
                    $"номер телефона: {Manager.phone}, именуемый в дальнейшем Заказчик, с другой стороны");
                contract.WriteLine("заключили настоящий договор о нижеследующем");
                contract.WriteLine("Предмет");
                contract.WriteLine("В соответствии с настоящим соглашением Исполнитель в лице ООО «Образовательный центр» " +
                    $"обязуется оказать Заказчику в лице {Manager.surname + " " + Manager.first_name + " " + Manager.patronymic}, " +
                    "за оговоренную договором плату, следующие образовательные услуги:");
                    contract.WriteLine("  ● " + Contract.title);
                contract.WriteLine("Заключительные положения");
                contract.WriteLine("  ● Настоящий договор составлен в двух экземплярах. Один экземпляр передается Заказчику, другой передается Исполнителю.");
                contract.WriteLine("  ● По всем моментам, которые не оговорены в настоящем соглашении, стороны руководствуются действующим законодательством Российской Федерации.");
                contract.WriteLine();
                contract.WriteLine("Подпись директора");
                contract.WriteLine("Подпись плательщика");
            }
        }

        private void button_contract_txt_Click(object sender, EventArgs e)
        {
            string fileNameTxt = "fileNameTxt";
            Contract_txt(fileNameTxt,deal_);
        }
        private void Contract_pdf(string fileName, Deal deal)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            string filePath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
            }
            else
            {
                return;
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                SaveFileDialog saveFileDialog_ = new SaveFileDialog();
                saveFileDialog_.FileName = fileName;
                saveFileDialog_.Filter = "Текстовые файлы (*.pdf)|*.pdf";
                if (saveFileDialog_.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog_.FileName;
                }
                else
                {
                    return;
                }

                using (FileStream fs_ = new FileStream(filePath, FileMode.Create))
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document();
                    BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12);
                    iTextSharp.text.Font boldFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
                    using (PdfWriter writer = PdfWriter.GetInstance(document, fs_))
                    {
                        document.Open();
                        document.Add(new Paragraph(" Договор оказания образовательных услуг", boldFont));
                        document.Add(new Paragraph($"Г. Москва 20 сентября 2023 года", font));
                        document.Add(new Paragraph($"ООО «Sound Production», в лице генерального директора Левшина Сергея Сергеевича," +
                        $" действующего на основании Устава общества, именуемого в дальнейшем Исполнитель, с одной стороны", font));
                        document.Add(new Paragraph("И", font));
                        document.Add(new Paragraph($"{Manager.surname + " " + Manager.first_name + " " + Manager.patronymic}, " +
                        $"{Manager.date_birth.ToShortDateString()} года рождения, " +
                        $"проживающий по адресу: {Manager.place_residence}, " +
                        $"паспорт: {Manager.passport}, " +
                        $"выданный отделом УФМС России по Тюменской области в городе Тюмень " +
                        $"{Manager.date_birth.ToShortDateString()}, " +
                        $"номер телефона: {Manager.phone}, именуемый в дальнейшем Заказчик, с другой стороны", font));
                        document.Add(new Paragraph("заключили настоящий договор о нижеследующем", font));
                        document.Add(new Paragraph("Предмет", boldFont));
                        document.Add(new Paragraph("В соответствии с настоящим соглашением Исполнитель в лице ООО «Центр образования» " +
                        $"обязуется оказать Заказчику в лице {Manager.surname + " " + Manager.first_name + " " + Manager.patronymic}, " +
                        "за оговоренную договором плату, следующие образовательные услуги:", font));
                        document.Add(new Paragraph(" ● " + Contract.title, font));
                        document.Add(new Paragraph("Заключительные положения", boldFont));
                        document.Add(new Paragraph(" ● Настоящий договор составлен в двух экземплярах. Один экземпляр передается Заказчику, другой передается Исполнителю.", font));
                        document.Add(new Paragraph(" ● По всем моментам, которые не оговорены в настоящем соглашении, стороны руководствуются действующим законодательством Российской Федерации.", font));
                        document.Add(new Paragraph(""));
                        document.Add(new Paragraph("Подпись директора", boldFont));
                        document.Add(new Paragraph("Подпись плательщика", boldFont));
                        document.Close();
                    }
                }
            }
        }

        private void button_contract_pdf_Click(object sender, EventArgs e)
        {
            Contract_pdf("fileNamePdf", deal_);
        }
        private void Pdf(string fileName, Deal deal)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Filter = "Текстовые файлы (*.pdf)|*.pdf";

            string filePath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
            }
            else
            {
                return;
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document();
                BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font bigfont = new iTextSharp.text.Font(baseFont, 12);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 8);
                iTextSharp.text.Font smallFont = new iTextSharp.text.Font(baseFont, 5);
                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
                using (PdfWriter writer = PdfWriter.GetInstance(document, fs))
                {
                    document.Open();
                    PdfPTable table = new PdfPTable(2);
                    table.SetWidths(new float[] { 50, 120 });

                    PdfPCell leftCell = new PdfPCell();
                    Paragraph title = new Paragraph("Квитанция", bigfont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingBefore = 5f;
                    leftCell.AddElement(title);
                    string imagePath = "qr.png";
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
                    leftCell.AddElement(image);
                    table.AddCell(leftCell);

                    PdfPCell rightCell = new PdfPCell();
                    LineSeparator lineSeparator = new LineSeparator(0.0F, 101.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
                    Paragraph line = new Paragraph(new Chunk(lineSeparator));
                    line.SetLeading(0.5F, 0.5F);

                    Paragraph formTitle = new Paragraph("Форма №ПД-4", smallFont);
                    formTitle.Alignment = Element.ALIGN_CENTER;
                    rightCell.AddElement(formTitle);
                    Paragraph consumer = new Paragraph("ООО «Центр образования»", font);
                    consumer.Alignment = Element.ALIGN_CENTER;
                    rightCell.AddElement(consumer);
                    rightCell.AddElement(line);
                    Paragraph counsumerTitleDesc = new Paragraph("(наименование получателя платежа)", smallFont);
                    counsumerTitleDesc.Alignment = Element.ALIGN_CENTER;
                    rightCell.AddElement(counsumerTitleDesc);
                    rightCell.AddElement(new Paragraph("    ИНН 060834123664 КПП 255505341          30101810400000000886", font));
                    rightCell.AddElement(line);
                    rightCell.AddElement(new Paragraph("        (инн получателя платежа)                                        (номер счёта получателя платежа)", smallFont));
                    Paragraph bank = new Paragraph("БИК 964004621 (ОТДЕЛЕНИЕ БАНКА РОССИИ//УФК по Воронежской области г. Воронеж", font);
                    bank.Alignment = Element.ALIGN_CENTER;
                    rightCell.AddElement(bank);
                    rightCell.AddElement(line);
                    Paragraph bankTitleDesc = new Paragraph("(наименование банка получателя платежа)", smallFont);
                    bankTitleDesc.Alignment = Element.ALIGN_CENTER;
                    rightCell.AddElement(bankTitleDesc);
                    rightCell.AddElement(new Paragraph($"Договор: {Manager.id}", font));
                    rightCell.AddElement(line);
                    rightCell.AddElement(new Paragraph($"ФИО обучающегося: " +
                        $"{Manager.surname + " " + Manager.first_name + " " + Manager.patronymic}", font));
                    rightCell.AddElement(line);
                    rightCell.AddElement(new Paragraph($"Адрес плательщика: {Manager.place_residence}", font));
                    rightCell.AddElement(line);
                    rightCell.AddElement(new Paragraph($"КБК: 18210441010983012110", font));
                    rightCell.AddElement(line);
                    rightCell.AddElement(new Paragraph($"ОКТМО: 12345678", font));
                    rightCell.AddElement(line);
                    rightCell.AddElement(new Paragraph($"Сумма: {Contract.cost} рублей", font));
                    rightCell.AddElement(line);
                    rightCell.AddElement(new Paragraph("С условиями приёма указанной в платёжном документе суммы, в т.ч. " +
                       "с суммой взимаемой платы за услуги банка ознакомлен и согласен.        Подпись плательщика ________________\\", smallFont));

                    table.AddCell(rightCell);

                    document.Add(table);

                    document.Close();
                } 
            }

        }

          private void button_receipt_Click(object sender, EventArgs e)
          {
            Pdf("Pdf", deal_);
          }
    }
}
