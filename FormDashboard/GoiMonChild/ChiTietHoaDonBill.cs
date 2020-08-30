using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva_vegan.ClassCSharp;

namespace Viva_vegan.FormDashboard.GoiMonChild
{
    public class ChiTietHoaDonBill
    {
        private String mahd;
        private String mamon;
        private String tenmon;
        private String makm;
        private String dvt;
        private int soluong;
        private int dongia;
        private long thanhtien;

        public ChiTietHoaDonBill(string mahd, string mamon, string tenmon, string makm, string dvt, int soluong, int dongia, long thanhtien)
        {
            this.Mahd = mahd;
            this.Mamon = mamon;
            this.Tenmon = tenmon;
            this.Makm = makm;
            this.Dvt = dvt;
            this.Soluong = soluong;
            this.Dongia = dongia;
            this.Thanhtien = thanhtien;
        }
        public ChiTietHoaDonBill()
        {
            
        }
        public string Mahd { get => mahd; set => mahd = value; }
        public string Mamon { get => mamon; set => mamon = value; }
        public string Tenmon { get => tenmon; set => tenmon = value; }
        public string Makm { get => makm; set => makm = value; }
        public string Dvt { get => dvt; set => dvt = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public long Thanhtien { get => thanhtien; set => thanhtien = value; }

        public List<ChiTietHoaDonBill> GetChiTietHoaDonBillsFromMaHoaDon (String mahoadon)
        {
            if(!String.IsNullOrWhiteSpace(mahoadon))
            {
                List<ChiTietHoaDonBill> list = new List<ChiTietHoaDonBill>();
                String queryMonAn = "select *,THANHTIEN =SOLUONG*GIABAN from MONAN, CTHD_MA as a where a.MAHD ='" + mahoadon +
                    "' and a.MAMON=MONAN.MAMON";
                DataTable tableMonAn = ConnectDataBase.SessionConnect.executeQuery(queryMonAn);
                if(tableMonAn.Rows.Count>0)
                {
                    foreach (DataRow row in tableMonAn.Rows)
                    {
                        list.Add(new ChiTietHoaDonBill(
                            row["MAHD"].ToString(),
                            row[0].ToString(),
                            row["TENMON"].ToString(),
                            row["MAKM"].ToString(),
                            row["DVT"].ToString(),
                            Convert.ToInt32(row["SOLUONG"]),
                            Convert.ToInt32(row["GIABAN"]),
                            Convert.ToInt64(row["THANHTIEN"])
                            ));
                    }
                }
                String queryThucUong = "select *,THANHTIEN =SOLUONG*GIABAN from THUCUONG, CTHD_TU as a where a.MAHD ='" +mahoadon+
                    "' and a.MATHUCUONG=THUCUONG.MATHUCUONG";
                DataTable tableThucUong = ConnectDataBase.SessionConnect.executeQuery(queryThucUong);
                if (tableThucUong.Rows.Count > 0)
                {
                    foreach (DataRow row in tableThucUong.Rows)
                    {
                        list.Add(new ChiTietHoaDonBill(
                            row["MAHD"].ToString(),
                            row[0].ToString(),
                            row["TENTHUCUONG"].ToString(),
                            row["MAKM"].ToString(),
                            row["DVT"].ToString(),
                            Convert.ToInt32(row["SOLUONG"]),
                            Convert.ToInt32(row["GIABAN"]),
                            Convert.ToInt64(row["THANHTIEN"])
                            ));
                    }
                }
                return list;
            }
            return null;
        }
    }
}
