using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    public class BanDangHoatDong
    {
        private String maban;
        private String mahoadon;

        public BanDangHoatDong(string maban, string mahoadon)
        {
            this.Maban = maban;
            this.Mahoadon = mahoadon;
        }
        public BanDangHoatDong()
        {
        }

        public string Maban { get => maban; set => maban = value; }
        public string Mahoadon { get => mahoadon; set => mahoadon = value; }
        public List<BanDangHoatDong> GetBanDangHoatDongs()
        {
            List<BanDangHoatDong> bans = new List<BanDangHoatDong>();
            String query = "select mahd, soban from hoadon where TINHTRANGHD like N'%Chưa%'";
            DataTable dataTable = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                bans.Add(new BanDangHoatDong(row["soban"].ToString(), row["mahd"].ToString()));
            }
            return bans;
        }
        public String getMaHoaDonFromMaBan ( String maban)
        {
            String ketqua = "";
            String query = "select mahd from hoadon where TINHTRANGHD like N'%Chưa%' and soban ='" +maban+
                "'";
            DataTable dataTable = ConnectDataBase.SessionConnect.executeQuery(query);
            if (dataTable.Rows.Count>0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    ketqua = row["mahd"].ToString();
                }
            }
            return ketqua;
        }
    }
}
