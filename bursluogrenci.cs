using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dershaneSON
{
    class bursluogrenci
    {
        static readonly int MAX_OGRENCİ = 10;
        int numberofogrenci = 0;
        Ogrenciii[] ogrencis;
        public void Addogrenci(string ad, string soyad, string sinif, string tel, int ortalama)
        {
            Ogrenciii ogrenci = new Ogrenciii(ad, soyad, sinif, tel, ortalama);
            if (numberofogrenci < MAX_OGRENCİ && ortalama >= 90)
            {
                ogrencis[numberofogrenci] = ogrenci;
                numberofogrenci = numberofogrenci + 1;
            }

        }
        public Ogrenciii[] GetOgrenciiis()
        {

            return ogrencis;
        }

        public iterator createiterator()
        {
            return new bursluogrenciterator(ogrencis);

        }
    }
}
