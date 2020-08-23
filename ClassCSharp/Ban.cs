using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    public class Ban
    {
        private String soban;
        private String tenban;
        private String trangthai;
        private String makhuvuc;
        #region Getter and Setter 
        public Ban(string soban, string tenban, string trangthai, string makhuvuc)
        {
            this.Soban = soban;
            this.Tenban = tenban;
            this.Trangthai = trangthai;
            this.Makhuvuc = makhuvuc;
        }
        public Ban()
        {

        }
        public Ban( DataRow row)
        {
            this.Soban = row["soban"].ToString();
            this.Tenban = row["tenban"].ToString();
            this.Trangthai = row["tinhtrangban"].ToString();
            this.Makhuvuc = row["makhuvuc"].ToString();
        }

        public string Soban { get => soban; set => soban = value; }
        public string Tenban { get => tenban; set => tenban = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public string Makhuvuc { get => makhuvuc; set => makhuvuc = value; }
        #endregion
        #region Methods
        public List<Ban> loadList(String makhuvuc)
        {
            String query = "select * from ban";
            if (!String.IsNullOrWhiteSpace(makhuvuc))
            {
                query = "select * from ban where makhuvuc='" +
                    makhuvuc + "'";
            }
            List<Ban> list = new List<Ban>();
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                list.Add(new Ban(
                    row["soban"].ToString(), 
                    row["tenban"].ToString(), 
                    row["tinhtrangban"].ToString(),
                    row["makhuvuc"].ToString()));
            }
            return list;
        }
        public DataTable loadTableBan()
        {
            String query = "select * from ban";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            return table;
        }
        #endregion
    }
}
