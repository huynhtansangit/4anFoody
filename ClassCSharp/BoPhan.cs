using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class BoPhan
    {
        private String mabp;
        private String tenbp;

        public BoPhan(string mabp, string tenbp)
        {
            this.mabp = mabp;
            this.tenbp = tenbp;
        }

        public String Mabp { set => mabp = value; get => mabp; }
        public String Tenbp { set => tenbp = value; get => tenbp; }
    }
}
