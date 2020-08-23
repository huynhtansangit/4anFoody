using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class ChucVu
    {
        private String macv;
        private String tencv;
        #region Getter and Setter
        public ChucVu()
        {
        }
        public ChucVu(string macv, string tencv)
        {
            this.macv = macv;
            this.tencv = tencv;
        }

        public String Macv { set => macv = value; get => macv; }
        public String Tencv { set => tencv = value; get => tencv; }
        #endregion

        #region Methods
        public List<ChucVu> loadListChucVu()
        {
            List<ChucVu> list = new List<ChucVu>();
            String query = "select * from chucvu";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                list.Add(new ChucVu(row["macv"].ToString(), row["tencv"].ToString()));
            }
            return list;
        }
        #endregion
    }
}
