using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class KhuVuc
    {
        private String makhuvuc;
        private String tenkhuvuc;

        public KhuVuc(string makhuvuc, string tenkhuvuc)
        {
            this.makhuvuc = makhuvuc;
            this.tenkhuvuc= tenkhuvuc;
        }

        public String Makhuvuc { get => makhuvuc; set => makhuvuc = value; }
        public String Tenkhuvuc { get => tenkhuvuc; set => tenkhuvuc = value; }


    }
}
