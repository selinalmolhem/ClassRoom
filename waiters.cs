using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dershaneSON
{
    //waiters vv= new waiters();
    //vv.printogrenci();
    class waiters
    {
        public waiters()
        {
        }
        bursluogrenci bursluogrenci;
        public waiters(bursluogrenci bursluogrenci)
        {
            this.bursluogrenci = bursluogrenci;
        }
        public void printogrenci()
        {
            iterator bursluogrenciiterator = bursluogrenci.createiterator();

            // Console.WriteLine("print burslu ogrenci");
            printogrenci(bursluogrenciiterator);
        }
        void printogrenci(iterator iterator)
        {
            while (iterator.hasnext())
            {
                Ogrenciii ogrenciii = iterator.next();

                //                Console.Write(ogrenciii.GetName() + "");
                //               Console.Write(ogrenciii.GetSoyad() + "");
                //               Console.Write(ogrenciii.GetTel() + "");
                //               Console.Write(ogrenciii.GetSinif() + "");
                //               Console.Write(ogrenciii.GetOrtalama() + "");
            }
        }

    }
}
