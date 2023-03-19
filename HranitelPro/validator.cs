using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HranitelPro
{
    public class validator
    {
        public static bool email(string email)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }
            else { return true; }
        }

        public static bool password(string password)
        {
            // проверяем, что длина пароля не меньше 8 символов
            if (password.Length < 8)
            {
                return false;
            }

            // проверяем, что есть хотя бы одна цифра
            if (!password.Any(c => char.IsDigit(c)))
            {
                return false;
            }

            // проверяем, что есть хотя бы одна буква в верхнем регистре
            if (!password.Any(c => char.IsUpper(c)))
            {
                return false;
            }

            // проверяем, что есть хотя бы одна буква в нижнем регистре
            if (!password.Any(c => char.IsLower(c)))
            {
                return false;
            }

            // проверяем, что есть хотя бы один спецсимвол
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                return false;
            }

            // если все проверки прошли успешно, возвращаем true
            return true;
        }
        public static bool phone(string phoneNumber)
        {
            // используем регулярное выражение для проверки соответствия формату +X (XXX) XXX-XXXX
            string pattern = @"^\+\d \(\d{3}\) \d{3}-\d{2}-\d{2}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool date(DateTime dateStr)
        {


            // Вычисляем возраст
            int age = DateTime.Today.Year - dateStr.Year;
            if (DateTime.Today < dateStr.AddYears(age))
            {
                age--;
            }

            // Проверяем, что возраст больше или равен 16
            if (age < 16)
            {
                return false;
            }

            return true;
        }
        public static bool serial(string serial)
        {
            if (Int32.TryParse(serial, out int value) && value >= 0 && value <= 9999)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool number(string number)
        {
            if (Int32.TryParse(number, out int value) && value >= 0 && value <= 999999)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool photo(string filePath)
        {
            // проверяем, выбрана ли фотография
            if (string.IsNullOrEmpty(filePath))
            {
                return true; // поле необязательное, поэтому возвращаем true
            }

            // проверяем размер файла
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length > 4 * 1024 * 1024)
            {
                return false;
            }

            // проверяем соотношение сторон
            Image image = Image.FromFile(filePath);
            double aspectRatio = (double)image.Width / image.Height;
            if (Math.Abs(aspectRatio - 0.75) > 0.01) // здесь 0.75 - соотношение сторон 3:4, допускается погрешность в 1%
            {
                return false;
            }

            // все проверки пройдены успешно
            return true;
        }
    }

}
