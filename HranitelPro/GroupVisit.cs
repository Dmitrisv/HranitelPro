using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace HranitelPro
{
    public partial class GroupVisit : Form
    {
        public GroupVisit()
        {
            InitializeComponent();
        }
        public List<Visitor> visitor = new List<Visitor>();
        int id = 1;

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (visitor.Count > 0)
            {
                foreach (var item in visitor)
                {
                    string fio = item.fio;
                    string phone = item.phone_number;
                    string email = item.email;
                    string purpose = item.purpose;
                    string passport_data = item.passport_data;
                    //string login = item.login;
                    //string password = item.password;
                    string date_of_birth = item.date_of_birth;
                    string group_name = item.group_name;

                    DataBase dataBase = new DataBase();
                    dataBase.openConnection();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.InsertCommand = new MySqlCommand("INSERT INTO visit_group (fio, phone_number, email,date_of_birth,passport_data, login, password, purpose, group_name) VALUES (@fio, @phone, @email,@birthday,@passport_data, @login, @password, @purpose, @group_name)", dataBase.getConnection());
                    adapter.InsertCommand.Parameters.AddWithValue("@fio", fio);
                    adapter.InsertCommand.Parameters.AddWithValue("@phone", phone);
                    adapter.InsertCommand.Parameters.AddWithValue("@birthday", date_of_birth);
                    adapter.InsertCommand.Parameters.AddWithValue("@email", email);
                    adapter.InsertCommand.Parameters.AddWithValue("@passport_data", passport_data);
                    adapter.InsertCommand.Parameters.AddWithValue("@login", "-");
                    adapter.InsertCommand.Parameters.AddWithValue("@password", "-");
                    adapter.InsertCommand.Parameters.AddWithValue("@purpose", purpose);
                    adapter.InsertCommand.Parameters.AddWithValue("@group_name", group_name);
                    adapter.InsertCommand.ExecuteNonQuery();
                    //+7 (000) 000-0000
                    dataBase.closeConnection();
                }
                MessageBox.Show("Запись успешно занесена в базу данных");
            }
            else
            {
                MessageBox.Show("Посетители не обнаружены");
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clearForm_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is Panel)
                    foreach (Control x2 in x.Controls)
                        if (x2 is TextBox)
                        {
                            ((TextBox)x2).Text = String.Empty;
                        }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPDF = new OpenFileDialog();
            openPDF.Multiselect = false;
            openPDF.Filter = "Файлы формата PDF (*.pdf;)|*.pdf;";
            openPDF.Title = "Выберите файл";

            if (openPDF.ShowDialog() == DialogResult.OK)
            {
                if (openPDF.FileName != null)
                {
                    button1.Text = "Файл прикреплен";
                }
            }
        }

        private void GroupVisit_Load(object sender, EventArgs e)
        {
            #region Загрузка списка подразделений
            DataBase dataBase = new DataBase();

            string query = "SELECT name FROM subdivision";

            // Открытие подключения
            dataBase.openConnection();
            MySqlCommand command = new MySqlCommand(query, dataBase.getConnection());
            // Выполнение запроса и получение результатов
            MySqlDataReader reader = command.ExecuteReader();

            // Добавление результатов в ListBox
            while (reader.Read())
            {
                subdivisionList.Items.Add(reader["name"].ToString());
            }

            // Закрытие чтения
            reader.Close();
            #endregion
            #region Определение дат для оформление пропуска
            dateFrom.MinDate = DateTime.Now.AddDays(1);
            dateFrom.MaxDate = DateTime.Now.AddDays(15);
            dateTo.MinDate = DateTime.Now.AddDays(1);
            dateTo.MaxDate = DateTime.Now.AddDays(15);
            #endregion
            #region Список целей посещения
            goalList.Items.Add("Ознакомительная экскурсия");
            #endregion

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string groupName = "";
            string surname = surnameField.Text;
            string name = nameField.Text;
            string patronymic = patronymicField.Text;
            string phone = phoneField.Text;
            string email = emailField.Text;
            DateTime birthday = birthDateField.Value;
            string serial = serialField.Text;
            string number = numberField.Text;
            string purpose = purposeField.Text;

            string fio = string.Join(" ", surname, name, patronymic);
            string passport_data = string.Join(" ", serial, number);

            bool isPhoneValid = validator.phone(phone);
            bool isBirthdayValid = validator.date(birthday);
            bool isSerialValid = validator.serial(serial);
            bool isNumberValid = validator.number(number);
            bool isEmailVaild = validator.email(email);
            bool isSubDivisonValid = validator.subdivision(subdivisionList.SelectedItem.ToString());
            bool isSubDivisionEmployeeValid = validator.subdivision_employee(comboBox1.SelectedItem.ToString());

            if (!isPhoneValid)
            {
                MessageBox.Show("Неверный формат телефона");
            }
            else if (!isBirthdayValid)
            {
                MessageBox.Show("Вы младше 16 лет");
            }
            else if (!isSerialValid)
            {
                MessageBox.Show("Неверная серия пасспорта");
            }
            else if (!isNumberValid)
            {
                MessageBox.Show("Неверный номер пасспорта");
            }
            else if (!isEmailVaild)
            {
                MessageBox.Show("Неверный формат почты");
            }
            else if (!isSubDivisionEmployeeValid)
            {
                MessageBox.Show("Не указан сотрудник подразделения");
            }
            else if (!isSubDivisonValid)
            {
                MessageBox.Show("Не указано подразделение");
            }
            else
            {
                DataBase dataBase = new DataBase();

                #region Создание Purpose
                MySqlCommand query = new MySqlCommand("SELECT employee_code FROM subdivision_employee WHERE fio = @fio", dataBase.getConnection());
                query.Parameters.AddWithValue("@fio", comboBox1.SelectedItem.ToString());


                // Открытие подключения
                dataBase.openConnection();
                // Выполнение запроса и получение результатов
                MySqlDataReader reader = query.ExecuteReader();
                string subdivisionEmployeeCode = "";
                while (reader.Read()) subdivisionEmployeeCode = reader["employee_code"].ToString();
                purpose = dateFrom.Value.Day.ToString() + "/" + dateFrom.Value.Month.ToString() + "/" + dateFrom.Value.Year.ToString() + "_" + subdivisionEmployeeCode;
                dataBase.closeConnection();
                #endregion
                #region Создание group_name
                string input = comboBox1.SelectedItem.ToString();
                string pattern2 = @"^\w+"; // Первое слово начинается с начала строки и состоит из одного или более символов слова (буквы, цифры, символ подчеркивания)

                Match match2 = Regex.Match(input, pattern2);


                dataBase.openConnection();
                string sql = "SELECT group_name FROM visit_group ORDER BY id DESC LIMIT 1;";
                MySqlCommand command = new MySqlCommand(sql, dataBase.getConnection());

                // выполнение запроса и получение результатов
                MySqlDataReader reader2 = command.ExecuteReader();
                string groupNumber = "";

                // проверка наличия данных
                if (reader2.HasRows)
                {
                    // чтение первой строки
                    reader2.Read();

                    // получение числа из ГР2
                    groupNumber = reader2.GetString(0);
                    string pattern = @"ГР(\d+)";
                    var match = Regex.Match(groupNumber, pattern);
                    int result = 0;
                    if (match.Groups[1].Value == "")
                        result = 0;
                    else
                        result = Convert.ToInt32(match.Groups[1].Value);

                    groupName = dateFrom.Value.Day.ToString() + "/" + dateFrom.Value.Month.ToString() + "/" + dateFrom.Value.Year.ToString() + "_Производство_" + match2.Value + "_" + subdivisionEmployeeCode + "_ГР" + (result + 1);


                    dataBase.closeConnection();

                }
                else
                {
                    string pattern = @"ГР(\d+)";
                    var match = Regex.Match(groupNumber, pattern);
                    int result = 0;
                    if (match.Groups[1].Value == "")
                        result = 0;
                    else
                        result = Convert.ToInt32(match.Groups[1].Value);

                    groupName = dateFrom.Value.Day.ToString() + "/" + dateFrom.Value.Month.ToString() + "/" + dateFrom.Value.Year.ToString() + "_Производство_" + match2.Value + "_" + subdivisionEmployeeCode + "_ГР" + (result + 1);

                }



                #endregion


                visitor.Add(new Visitor
                {
                    contacts = phone,
                    date_of_birth = birthDateField.Text,
                    fio = fio,
                    id = id,
                    email = emailField.Text,
                    passport_data = passport_data,
                    phone_number = phone,
                    purpose = purpose,
                    group_name = groupName
                });
                id++;
                AppendTable(visitor);
            }
        }

        public void AppendTable(List<Visitor> visitor)
        {
            foreach (Control x in panel5.Controls)
            {
                if (x is Label)
                    Controls.Remove(x);
            }

            for (var i = 0; i < visitor.Count; i++)
            {
                var idText = new Label();
                idText.Text = visitor[i].id.ToString();
                panel5.Controls.Add(idText);
                idText.Location = new Point(-3, (0 + 18 * i));
                idText.Width = 10;
                idText.Height = 13;

                var fioText = new Label();
                fioText.Text = visitor[i].fio;
                panel5.Controls.Add(fioText);
                fioText.Location = new Point(22, (0 + 18 * i));
                fioText.Width = 180;
                fioText.Height = 13;

                var contactText = new Label();
                contactText.Text = visitor[i].contacts;
                panel5.Controls.Add(contactText);
                contactText.Location = new Point(204, (0 + 18 * i));
                contactText.Height = 13;
            }
        }

        private void subdivisionList_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            comboBox1.Text = "";

            string name = subdivisionList.SelectedItem.ToString();

            DataBase dataBase = new DataBase();
            dataBase.openConnection();

            string query = "SELECT subdivision_employee.* FROM subdivision_employee INNER JOIN subdivision ON subdivision_employee.subdivision_id = subdivision.id WHERE subdivision.name = @name";

            MySqlCommand command = new MySqlCommand(query, dataBase.getConnection());
            command.Parameters.AddWithValue("@name", name);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader["fio"].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPDF = new OpenFileDialog();
            openPDF.Multiselect = false;
            openPDF.Filter = "Файлы формата xlsx (*.xlsx;)|*.xlsx;";
            openPDF.Title = "Выберите файл";

            if (openPDF.ShowDialog() == DialogResult.OK)
            {
                if (openPDF.FileName != null)
                {
                    var ms = new MemoryStream();
                    var file = openPDF.OpenFile().CopyToAsync(ms);
                    string sheetName = "Лист1";
                    string cellRange = "A2:I"; // Область ячеек с данными
                    string namespaceUri = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
                    string rootElement = "worksheet";

                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(ms);

                    XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
                    namespaceManager.AddNamespace("ns", namespaceUri);

                    XmlNodeList rows = xmlDocument.DocumentElement.SelectNodes("//ns:" + rootElement + "/ns:sheetData/ns:row", namespaceManager);

                    foreach (XmlNode row in rows)
                    {
                        if (row.Attributes["r"].Value == "1")
                        {
                            // Пропускаем первую строку с заголовками
                            continue;
                        }

                        XmlNodeList cells = row.SelectNodes("ns:c", namespaceManager);

                        string fio = cells[0].InnerText;
                        string phone = cells[1].InnerText;
                        string email = cells[2].InnerText;
                        DateTime birthdate = DateTime.FromOADate(double.Parse(cells[3].InnerText));
                        string passport = cells[4].InnerText;
                        string login = cells[5].InnerText;
                        string password = cells[6].InnerText;
                        string subdivision = cells[7].InnerText;
                        string subdivisionEmployee = cells[8].InnerText;
                        MessageBox.Show(fio);
                        MessageBox.Show(phone);
                        MessageBox.Show(email);
                        MessageBox.Show(birthdate.ToString());
                    }

                    button1.Text = "Файл прикреплен";
                }
            }
        }
    }
}
