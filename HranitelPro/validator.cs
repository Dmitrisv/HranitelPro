using System;
using System.Collections.Generic;
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
            string pattern = @"^\+\d \(\d{3}\) \d{3}-\d{4}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }


}
