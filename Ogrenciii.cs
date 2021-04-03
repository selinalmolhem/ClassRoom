using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dershaneSON
{
    class Ogrenciii
    {
        string ad;
        string soyad;
        string sinif;
        string tel;
        int ortalama;
        public Ogrenciii(string ad, string soyad, string sinif, string tel, int ortalama)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.sinif = sinif;
            this.tel = tel;
            this.ortalama = ortalama;
        }
        public string GetName()
        {
            return ad;
        }
        public string GetSoyad()
        {
            return soyad;
        }
        public string GetSinif()
        {
            return sinif;
        }
        public string GetTel()
        {
            return tel;
        }
        public int GetOrtalama()
        {
            return ortalama;
        }

    }
}
