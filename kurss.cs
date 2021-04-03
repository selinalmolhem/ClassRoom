using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dershaneSON
{
    public interface ıkurss
    {

        String KursTipi();
        double KursFiyat(int fiyat);
        

    }
    public class Normal : ıkurss
    {
        public double KursFiyat(int fiyat)
        {
            return fiyat;
        }
        public string KursTipi()
        {
            return " Normal";
        }
       
    }


    class ozel : ıkurss
    {
        public double KursFiyat(int fiyat)
        {
            return fiyat;
        }
        public string KursTipi()
        {
            return "Ozel";
        }
      
    }
    public abstract class decrator: ıkurss
    {
        private readonly ıkurss _kurss;

        public decrator(ıkurss kurss)
        {
            _kurss = kurss;
        }

        public virtual double KursFiyat(int fiyat)
        {
            return _kurss.KursFiyat(fiyat);
        }

        public virtual string KursTipi()
        {
            return _kurss.KursTipi(); ;
        }
    }
    public class concrectdecratornormal : decrator
    {
        public concrectdecratornormal(ıkurss kurss) : base(kurss)
        {

        }

        public override string KursTipi()
        {
            return base.KursTipi() + " + normal";
        }

        public override double KursFiyat(int fiyat)
        {
            return base.KursFiyat(fiyat) + 1;
        }

    }

    public class concrectdecratorozel : decrator
    {
        public concrectdecratorozel(ıkurss kurss) : base(kurss)
        {

        }

        public override string KursTipi()
        {
            return base.KursTipi() + " + ozel";
        }

        public override double KursFiyat(int fiyat)
        {
            return base.KursFiyat(fiyat) *3;
        }
    }
    
}

