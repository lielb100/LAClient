using System.Text.RegularExpressions;

namespace LAClient
{
    public static class ValidatorHelper
    {
        public static bool IsValidPassword(string password)
        {
            if (password == null) return false;
            Regex regex = new Regex(@"^(?=.*[A - Za - z])(?=.*\d)[A - Za - z\d]{ 8, }$");
            return regex.IsMatch(password);
        }

        public static bool IsValidEmail(string email)
        {
            if (email == null) return false;
            Regex regex = new Regex(@"^([\w\.\-] +)@([\w\-] +)((\.(\w){ 2, 3 })+)$");
            return regex.IsMatch(email);
        }

        public static bool IsValidPhone(string phone)
        {
            if (phone == null) return false;
            return phone.Length == 7;
        }
    }
}