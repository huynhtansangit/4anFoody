using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class KhuVuc
    {
        private String makhuvuc;
        private String tenkhuvuc;

        #region Getter and Setter
        public KhuVuc(string makhuvuc, string tenkhuvuc)
        {
            this.makhuvuc = makhuvuc;
            this.tenkhuvuc= tenkhuvuc;
        }
        public KhuVuc()
        {
           
        }
        public String Makhuvuc { get => makhuvuc; set => makhuvuc = value; }
        public String Tenkhuvuc { get => tenkhuvuc; set => tenkhuvuc = value; }
        #endregion
        public List<KhuVuc> loadListKhuVuc()
        {
            List<KhuVuc> list = new List<KhuVuc>();
            String query = "select * from khuvuc";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                list.Add(new KhuVuc(row["maKhuVuc"].ToString(), row["tenKhuVuc"].ToString()));
            }
            return list;
        }

    }
}
