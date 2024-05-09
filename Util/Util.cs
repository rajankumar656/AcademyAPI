using System.Text.RegularExpressions;

namespace AcademyAPI.Util
{
    public static class Util
    {

        private static readonly string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        private static readonly Regex emailRegex = new Regex(emailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);


        public static bool isAmtEmailValid(string email, decimal amount) 
        {

            if(email == null || email.Length == 0 || email.Length > 30)
                return false;

             if(amount <= 0 || amount > 10000)
                return false;

            return emailRegex.IsMatch(email);
        }
    }
}
