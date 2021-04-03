using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dershaneSON
{
    public abstract class odemee
    {
        private int ucret;
        public abstract int getUcret();

    }
    class kas1 : odemee
    {
        public override int getUcret()
        {
            return 3000;
        }
    }
    class taksitt : odemee
    {
        public override int getUcret()
        {
            return 3000 / 9;
        }
    }
    class burss : odemee
    {
        public override int getUcret()
        {
            return 0;
        }
    }
}
