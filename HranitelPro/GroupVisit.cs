using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

                    DataBase dataBase = new DataBase();
                    dataBase.openConnection();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.InsertCommand = new MySqlCommand("INSERT INTO visit_personal (fio, phone_number, email,date_of_birth,passport_data, login, password, purpose) VALUES (@fio, @phone, @email,@birthday,@passport_data, @login, @password, @purpose)", dataBase.getConnection());
                    adapter.InsertCommand.Parameters.AddWithValue("@fio", fio);
                    adapter.InsertCommand.Parameters.AddWithValue("@phone", phone);
                    adapter.InsertCommand.Parameters.AddWithValue("@birthday", date_of_birth);
                    adapter.InsertCommand.Parameters.AddWithValue("@email", email);
                    adapter.InsertCommand.Parameters.AddWithValue("@passport_data", passport_data);
                    //adapter.InsertCommand.Parameters.AddWithValue("@login", login);
                    //adapter.InsertCommand.Parameters.AddWithValue("@password", password);
                    adapter.InsertCommand.Parameters.AddWithValue("@purpose", purpose);
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
            string surname = surnameField.Text;
            string name = nameField.Text;
            string patronymic = patronymicField.Text;
            string phone = phoneField.Text;
            string email = emailField.Text;
            string organization = organizationField.Text;
            string text = purposeField.Text;
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
            else
            {
                DataBase dataBase = new DataBase();

                #region Создание Purpose
                MySqlCommand query = new MySqlCommand("SELECT employee_code FROM subdivision_employee WHERE fio = @fio", dataBase.getConnection());
                query.Parameters.AddWithValue("@fio", comboBox1.SelectedValue.ToString());


                // Открытие подключения
                dataBase.openConnection();
                // Выполнение запроса и получение результатов
                MySqlDataReader reader = query.ExecuteReader();
                string subdivisionEmployeeCode = "";
                while (reader.Read()) subdivisionEmployeeCode = reader["employee_code"].ToString();
                purpose = dateFrom.Value.Day.ToString() + "/" + dateFrom.Value.Month.ToString() + "/" + dateFrom.Value.Year.ToString() + "_" + subdivisionEmployeeCode;
                dataBase.closeConnection();
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
                panel4.Controls.Add(idText);
                idText.Location = new Point(-3, (0 + 18 * i));
                idText.Width = 10;

                var fioText = new Label();
                fioText.Text = visitor[i].fio;
                panel4.Controls.Add(fioText);
                fioText.Location = new Point(22, (0 + 18 * i));
                fioText.Width = 180;

                var contactText = new Label();
                contactText.Text = visitor[i].contacts;
                panel4.Controls.Add(contactText);
                contactText.Location = new Point(204, (0 + 18 * i));
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
    }
}
