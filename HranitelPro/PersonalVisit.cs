using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace HranitelPro
{
    public partial class PersonalVisit : Form
    {
        public PersonalVisit()
        {
            InitializeComponent();
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
                        else if (x2 is MaskedTextBox)
                        {
                            ((MaskedTextBox)x2).Text = String.Empty;
                        }
                        else if (x2 is DateTimePicker)
                        {
                            ((DateTimePicker)x2).Text = "";
                        }
                        else if (x2 is ComboBox)
                        {
                            ((ComboBox)x2).Text = "";
                        }
                string imagePath = Path.Combine(Application.StartupPath, @"assets\Фотография2.png");
                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = null;
                    // Получение потока данных для встроенного ресурса "image.jpg"
                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MyNamespace.image.jpg");

                    // Чтение содержимого потока в массив байт
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);

                    // Использование массива байт, например, для сохранения файла на диск
                    File.WriteAllBytes("image.jpg", buffer);
                    pictureBox1.BackgroundImage = buffer;
                }
                else
                {
                    MessageBox.Show("Файл не найден: " + imagePath);
                }
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
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
            bool isSubDivisonValid = validator.subdivision(subdivisionList.SelectedItem.ToString());
            bool isSubDivisionEmployeeValid = validator.subdivision_employee(comboBox1.SelectedItem.ToString());

            if (!isPhoneValid)
            {
                MessageBox.Show("Не верный формат телефона");
            }
            else if (!isBirthdayValid)
            {
                MessageBox.Show("Вы младше 16 лет");
            }
            else if (!isSerialValid)
            {
                MessageBox.Show("Не верный серия пасспорта");
            }
            else if (!isNumberValid)
            {
                MessageBox.Show("Не верный номер пасспорта");
            }
            else if (!isEmailVaild)
            {
                MessageBox.Show("Не верный формат почты");
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
                MySqlCommand query = new MySqlCommand( "SELECT employee_code FROM subdivision_employee WHERE fio = @fio", dataBase.getConnection());
                query.Parameters.AddWithValue("@fio", comboBox1.SelectedValue.ToString());


                // Открытие подключения
                dataBase.openConnection();
                // Выполнение запроса и получение результатов
                MySqlDataReader reader = query.ExecuteReader();
                string subdivisionEmployeeCode = "";
                while ( reader.Read()) subdivisionEmployeeCode = reader["employee_code"].ToString();
                purpose = dateFrom.Value.Day.ToString() + "/" + dateFrom.Value.Month.ToString() + "/" + dateFrom.Value.Year.ToString() + "_" + subdivisionEmployeeCode; 
                dataBase.closeConnection();

                #endregion
                dataBase.openConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.InsertCommand = new MySqlCommand("INSERT INTO visit_personal (fio, phone_number, email,date_of_birth,passport_data, login, password, purpose) VALUES (@fio, @phone, @email,@birthday,@passport_data, @login, @password, @purpose)", dataBase.getConnection());
                adapter.InsertCommand.Parameters.AddWithValue("@fio", fio);
                adapter.InsertCommand.Parameters.AddWithValue("@phone", phone);
                adapter.InsertCommand.Parameters.AddWithValue("@birthday", birthDateField.Text);
                adapter.InsertCommand.Parameters.AddWithValue("@email", email);
                adapter.InsertCommand.Parameters.AddWithValue("@passport_data", passport_data);
                adapter.InsertCommand.Parameters.AddWithValue("@login", HranitelPro.Properties.Settings.Default.UserName);
                adapter.InsertCommand.Parameters.AddWithValue("@password", HranitelPro.Properties.Settings.Default.UserPassword);
                adapter.InsertCommand.Parameters.AddWithValue("@purpose", purpose);
                adapter.InsertCommand.ExecuteNonQuery();
                //+7 (000) 000-0000
                dataBase.closeConnection();
                MessageBox.Show("Запись успешно занесена в базу данных");
            }
        }

        Point lastPoint = new Point();
        private void PersonalVisit_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void PersonalVisit_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void subdivisionList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PersonalVisit_Load(object sender, EventArgs e)
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

        private void goalList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //goalList.Items.Add()
        }
        private void uploadImgBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Файлы формата JPG (*.jpg;)|*.jpg;"; 
            openFileDialog.Title = "Выберите изображение"; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bool isPhotoValid = validator.photo(openFileDialog.FileName);

                    if (!isPhotoValid)
                    {
                        MessageBox.Show("Фотография не соотвествует тербованиям");
                    }
                    else
                    {
                        pictureBox1.BackgroundImage = null;
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                }
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (subdivisionList.SelectedItem != null)          
            {
                comboBox1.Text = "";
            }


        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void surnameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void patronymicField_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailField_TextChanged(object sender, EventArgs e)
        {

        }

        private void organizationField_TextChanged(object sender, EventArgs e)
        {

        }

        private void purposeField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void birthDateField_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void phoneField_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numberField_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void serialField_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
