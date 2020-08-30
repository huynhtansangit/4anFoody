using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class ChiTietHoaDon
    {
        private String mahd;
        private String mamon;
        private String tenmon;
        private String makm;
        private String dvt;
        private int soluong;
        private int dongia;

        public ChiTietHoaDon(string mahd, string mamon, string makm, int soluong,String tenmon,int dongia,string dvt)
        {
            this.mahd = mahd;
            this.mamon = mamon;
            this.makm = makm;
            this.soluong = soluong;
            this.tenmon = tenmon;
            this.dongia = dongia;
            this.dvt = dvt;
        }
        public ChiTietHoaDon()
        {
        }
        public ChiTietHoaDon(
            DataRow row,String loai)
        {
            if (loai.Contains("MA")) // is food
            {
                this.mahd = row["MAHD"].ToString(); ;
                this.mamon = row["MAMON"].ToString();
                this.makm = row["MAKM"].ToString();
                this.soluong = Convert.ToInt16(row["SOLUONG"]);
                this.tenmon = row["TENMON"].ToString();
                this.dongia = Convert.ToInt32(row["GIABAN"]);
                this.dvt = row["DVT"].ToString();
            }
            else if (loai.Contains("TU"))
            {
                this.mahd = row["MAHD"].ToString(); ;
                this.mamon = row["MATHUCUONG"].ToString();
                this.makm = row["MAKM"].ToString();
                this.soluong = Convert.ToInt16(row["SOLUONG"]);
                this.tenmon = row["TENTHUCUONG"].ToString();
                this.dongia = Convert.ToInt32(row["GIABAN"]);
                this.dvt = row["DVT"].ToString();
            }
        }

        public string Mahd { get => mahd; set => mahd = value; }
        public string Mamon { get => mamon; set => mamon = value; }
        public string Makm { get => makm; set => makm = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public string Tenmon { get => tenmon; set => tenmon = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public string Dvt { get => dvt; set => dvt = value; }

        #region Methods 
        public List<ChiTietHoaDon> chiTietHoaDons (String mahoadon)
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            String queryMA = "select * from CTHD_ma as a,monan as b where mahd='" +mahoadon+
                "' and a.MAMON=b.MAMON";

            String queryTU = "select * from CTHD_tu as a,THUCUONG as b where mahd='" +mahoadon+
                "' and a.MATHUCUONG=b.MATHUCUONG";
            DataTable tableMonAn = ConnectDataBase.SessionConnect.executeQuery(queryMA);
            foreach (DataRow row in tableMonAn.Rows)
            {
                list.Add(new ChiTietHoaDon(row,"MA"));
            }
            DataTable tableThucUong = ConnectDataBase.SessionConnect.executeQuery(queryTU);
            foreach (DataRow row in tableThucUong.Rows)
            {
                list.Add(new ChiTietHoaDon(row,"TU"));
            }
            return list;
        }
        public int insertChiTietHoaDon (String kind)
        {
            int res = 0;
            String query = "thaotacchitiethoadon @mahd @mamon @makm @soluong @request";
            res = ConnectDataBase.SessionConnect.executeNonQuery(query, new object[]
            {
                Mahd,Mamon,Makm,Soluong,kind
            });
            return res;
        }
        #endregion
    }
}
