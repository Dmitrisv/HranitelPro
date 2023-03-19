using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HranitelPro
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void labelClick(object sender, EventArgs e)
        {

        }

        private void button2Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1Click(object sender, EventArgs e)
        {
            DataBase data = new DataBase();

            // Получаем значение из поля PasswordField и LoginField
            string password = passwordField.Text;
            String loginUser = loginField.Text;
            // Преобразуем значение PasswordField в MD5 хэш-строку
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                string passwordHash = sb.ToString();

                HranitelPro.Properties.Settings.Default.UserName = loginUser;
                HranitelPro.Properties.Settings.Default.UserPassword = passwordHash;

                // Сверяем полученную хэш-строку со значением из базы данных
                using (MySqlConnection connection = data.getConnection())
                {
                    MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE username = @username AND password = @passwordHash", connection);
                    command.Parameters.AddWithValue("@passwordHash", passwordHash);
                    command.Parameters.AddWithValue("@username", loginUser);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MainForm mainForm = new MainForm();
                        //Close();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Нет");
                    }
                }
            }
        }

        private void loginField_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}
