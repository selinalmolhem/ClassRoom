using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dershaneSON
{
    class bursluogrenciterator : iterator
    {
        Ogrenciii[] ogrenciiis;
        int sayi = 0;
        public bursluogrenciterator(Ogrenciii[] ogrenciiis)
        {
            this.ogrenciiis = ogrenciiis;
        }
        public Ogrenciii next()
        {
            Ogrenciii ogrenciii = (Ogrenciii)ogrenciiis[sayi];
            sayi = sayi + 1;
            return ogrenciii;
        }
        public bool hasnext()
        {
            if (sayi >= 10 || ogrenciiis[sayi] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

