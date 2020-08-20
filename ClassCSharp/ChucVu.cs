using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class ChucVu
    {
        private String macv;
        private String tencv;

        public ChucVu(string macv, string tencv)
        {
            this.macv = macv;
            this.tencv = tencv;
        }

        public String Macv { set => macv = value; get => macv; }
        public String Tencv { set => tencv = value; get => tencv; }
    }
}
