using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dershaneSON
{
    class factoryMethod
    {
        public odemee odemeFactory(string tip)
        {
            odemee odeme = null;
            switch (tip)
            {
                case "kas":
                    odeme = new kas1();
                    break;
                case "taksit":
                    odeme = new taksitt();
                    break;
                default:
                    break;
            }
            return odeme;
        }
    }
}
