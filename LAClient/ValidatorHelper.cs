using System.Net.Mail;
using System.Text.RegularExpressions;

namespace LAClient
{
    public static class ValidatorHelper
    {
        public static bool IsValidPassword(string password)
        {
            if (password == null) return false;
            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasMinimum8Chars = new Regex(@".{8,}");

             return  hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);

        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhone(string phone)
        {
            if (phone == null) return false;
            return phone.Length == 7;
        }

        public static bool HasComma(string text)
        {
            return text.Contains("'");
        }
    }
}