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
            string text = textBox8.Text;
            string birthday = birthDateField.Text;
            string serial = serialField.Text;
            string number = numberField.Text;

            string fio = string.Join(" ", surname, name, patronymic);
            string passport_data = string.Join(" ", serial, number);

            if (validator.phone(phone))
            {

                DataBase dataBase = new DataBase();
                dataBase.openConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.InsertCommand = new MySqlCommand("INSERT INTO visit_personal (fio, phone, email,date_of_birth,passport_data) VALUES (@fio, @phone, @email,@birthday,@passport_data)", dataBase.getConnection());
                adapter.InsertCommand.Parameters.AddWithValue("@fio", fio);
                adapter.InsertCommand.Parameters.AddWithValue("@phone", phone);
                adapter.InsertCommand.Parameters.AddWithValue("@birthday", birthday);
                adapter.InsertCommand.Parameters.AddWithValue("@email", email);
                adapter.InsertCommand.Parameters.AddWithValue("@passport_data", passport_data);
            }
        }
    }
}
