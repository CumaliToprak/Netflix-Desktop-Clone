using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixApp
{
    public class UserInfo
    {
        public int Id { get; }
        public string Ad { get; }
        public string Email { get; }
        public string Sifre { get; }
        public DateTime DogumTarihi { get; }

        public UserInfo(int ID,string Ad, string Email, string Sifre, DateTime DogumTarihi)
        {
            this.Id = ID;
            this.Ad = Ad;
            this.Email = Email;
            this.Sifre = Sifre;
            this.DogumTarihi = DogumTarihi;
        }
    }
}
