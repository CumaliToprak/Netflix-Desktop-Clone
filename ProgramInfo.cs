using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixApp
{
    public class ProgramInfo
    {
        public int Id { get; }
        public string Ad { get; }
        public string Tip { get; }
        public int BolumSayisi { get; }
        public int BolumUzunluk { get; }

        public ProgramInfo(int ID, string Ad, string Tip, int BolumSayisi, int BolumUzunluk)
        {
            this.Id = ID;
            this.Ad = Ad;
            this.Tip = Tip;
            this.BolumSayisi = BolumSayisi;
            this.BolumUzunluk = BolumUzunluk;
        }

       
    }
}
