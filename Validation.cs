using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NetflixApp
{
    class Validation
    {
        public static bool isValidEmail(string Email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(Email);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Geçerli bir email adresi giriniz!");
            }
        }

        public static bool isValidName(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
            {
                throw new Exception("Geçerli bir isim giriniz!");
            }

            return true;
        }

        public static bool isValidPassword(string password)
        {

            if ((string.IsNullOrEmpty(password)))
            {
                throw new Exception("Parola boş bırakılamaz!");
            }

            return true;
        }
    }
}
