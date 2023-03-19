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
                if (x is TextBox)
                {
                    ((TextBox)x).Text = String.Empty;
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
            string birthday = birthDateField.Text;
            string serial = serialField.Text;
            string number = numberField.Text;
            string purpose = purposeField.Text;

            string fio = string.Join(" ", surname, name, patronymic);
            string passport_data = string.Join(" ", serial, number);

            if (validator.phone(phone))
            {

                DataBase dataBase = new DataBase();
                dataBase.openConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.InsertCommand = new MySqlCommand("INSERT INTO visit_personal (fio, phone_number, email,date_of_birth,passport_data, login, password, purpose) VALUES (@fio, @phone, @email,@birthday,@passport_data, @login, @password, @purpose)", dataBase.getConnection());
                adapter.InsertCommand.Parameters.AddWithValue("@fio", fio);
                adapter.InsertCommand.Parameters.AddWithValue("@phone", phone);
                adapter.InsertCommand.Parameters.AddWithValue("@birthday", birthday);
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
            else
            {
                MessageBox.Show("Не правильный формат телефона");
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
    }
}
