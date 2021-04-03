using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dershaneSON
{
    abstract class kursss
    {
        string ad;
        string seviye;
        string hoca;
        public abstract int kursfiyati();
    }
    class indrim : kursss
    {
        protected int _sayi;
        public indrim(int sayi, string ad, string seviye,string hoca)
        {
            _sayi = sayi;
            ad = ad;
            seviye = seviye;
            hoca = hoca;
            
        }
        public override int kursfiyati()
        {
            return 10;

        }
    }

    abstract class kurssdecroter : kursss
    {
        protected kursss _kursss;
        public kurssdecroter(kursss kursss)
        {
            _kursss = kursss;
        }

        public override int kursfiyati()
        {

            return _kursss.kursfiyati();
        }
        
    }
    class concretdecroter : kurssdecroter
    {
        public concretdecroter(kursss kursss) :base(kursss)
        {

        }
        public override int kursfiyati()
        {
            return base.kursfiyati();
        }
    }
}
