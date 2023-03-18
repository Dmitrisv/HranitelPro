using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HranitelPro
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            loginField.Text = "Введите имя";
        }





        private void label1Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginField_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = MailField.Text;
            string password = passwordField.Text;

            if (validator.email(email) )
            {
                if (validator.password(password))
                {
                    string hashedPassword = GetMd5Hash(passwordField.Text);
                    DataBase dataBase = new DataBase();

                    dataBase.openConnection();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.InsertCommand = new MySqlCommand("INSERT INTO users (username, password, email) VALUES (@username, @password, @email)", dataBase.getConnection());
                    adapter.InsertCommand.Parameters.AddWithValue("@username", loginField.Text);
                    adapter.InsertCommand.Parameters.AddWithValue("@password", hashedPassword);
                    adapter.InsertCommand.Parameters.AddWithValue("@email", MailField.Text);
                    adapter.InsertCommand.ExecuteNonQuery();

                    dataBase.closeConnection();

                    loginField.Text = "";
                    passwordField.Text = "";
                    MailField.Text = "";

                    MessageBox.Show("Регистрация прошла успешно!");
                }
                else
                {
                    MessageBox.Show("Слабый пароль");
                }
                
            }
            else
            {
                MessageBox.Show("Неправильная почта");
            }

        }

        private string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите имя")
            {
                loginField.ForeColor = Color.Black;
                loginField.Text = "";
            }
        }
        private void loginField_Leave_1(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Введите имя";
                loginField.ForeColor = Color.Gray;
            }

        }


        private void passwordFieldTextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

        }
    }
}
