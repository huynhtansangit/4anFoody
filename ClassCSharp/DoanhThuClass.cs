using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class DoanhThuClass
    {
        private string thoigian;
        private long doanhthu;
        public String queryDoanhThuNam = "select MONTH( CONVERT(date, NGAYLAP)) as THANG,sum (TIENSAUTHUE-VAT) as DOANHTHUTHANGTRONGNAM from hoadon as hd where ngaylap > DATEADD(MONTH,-12,GETDATE())  group by MONTH( CONVERT(date, NGAYLAP)) order by MONTH( CONVERT(date, NGAYLAP)) asc";
        public String queryDoanhThuTuan = "select datename(dw,CONVERT(date, NGAYLAP)) as TENNGAY,sum (TIENSAUTHUE-VAT) as DOANHTHUNGAYTRONGTUAN from hoadon as hd where ngaylap > DATEADD(day,-7,GETDATE())  group by CONVERT(date, NGAYLAP) order by CONVERT(date, NGAYLAP) asc";
        public String queryDoanhThuThang = "select datename(dw,CONVERT(date, NGAYLAP)) as TENNGAY,sum (TIENSAUTHUE-VAT) as DOANHTHUNGAYTRONGTHANG from hoadon as hd where ngaylap > DATEADD(day,-30,GETDATE())  group by CONVERT(date, NGAYLAP) order by CONVERT(date, NGAYLAP) asc";
        public String queryDoanhThuAll = "select CONVERT(date, NGAYLAP) as NGAY,sum (TIENSAUTHUE-VAT) as DOANHTHUTHEONGAY from hoadon as hd  group by CONVERT(date, NGAYLAP) order by CONVERT(date, NGAYLAP) asc";

        public DoanhThuClass(string thoigian, long doanhthu)
        {
            this.Thoigian = thoigian;
            this.Doanhthu = doanhthu;
        }
        public DoanhThuClass()
        {
           
        }
        public string Thoigian { get => thoigian; set => thoigian = value; }
        public long Doanhthu { get => doanhthu; set => doanhthu = value; }

        public List<DoanhThuClass> getDoanhThuNam ()
        {
            List<DoanhThuClass> doanhthu = new List<DoanhThuClass>();
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(queryDoanhThuNam);
            if (table.Rows.Count>0)
            {
                foreach (DataRow row in table.Rows)
                {
                    doanhthu.Add(new DoanhThuClass(row["THANG"].ToString(), Convert.ToInt64(row["DOANHTHUTHANGTRONGNAM"])));
                }
            }
            return doanhthu;
        }
        public List<DoanhThuClass> getDoanhThuTuan()
        {
            List<DoanhThuClass> doanhthu = new List<DoanhThuClass>();
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(queryDoanhThuTuan);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    doanhthu.Add(new DoanhThuClass(row["TENNGAY"].ToString(), Convert.ToInt64(row["DOANHTHUNGAYTRONGTUAN"])));
                }
            }
            return doanhthu;
        }
        public List<DoanhThuClass> getDoanhThuThang()
        {
            List<DoanhThuClass> doanhthu = new List<DoanhThuClass>();
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(queryDoanhThuThang);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    doanhthu.Add(new DoanhThuClass(row["TENNGAY"].ToString(), Convert.ToInt64(row["DOANHTHUNGAYTRONGTHANG"])));
                }
            }
            return doanhthu;
        }
        public List<DoanhThuClass> getDoanhThuAll()
        {
            List<DoanhThuClass> doanhthu = new List<DoanhThuClass>();
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(queryDoanhThuAll);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    doanhthu.Add(new DoanhThuClass(row["NGAY"].ToString(), Convert.ToInt64(row["DOANHTHUTHEONGAY"])));
                }
            }
            return doanhthu;
        }
    }
}
