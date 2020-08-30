using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class HoaDon
    {
        private String mahd;
        private String makh;
        private String manv;
        private DateTime ngaylap;
        private String noidung;
        private String httt;
        private String soban;
        private String tinhtranghd;
        private float vat;
        private Int32 tiensauthue;
        private Int32 tiennhankh;
        private Int32 tientralaikh;
        

        public HoaDon(
            string mahd,
            string makh,
            string manv,
            DateTime ngaylap,
            string noidung,
            string httt,
            string soban,
            string tinhtranghd,
            float vat,
            int tiensauthue,
            int tiennhankh,
            int tientralaikh)
        {
            this.mahd = mahd;
            this.makh = makh;
            this.manv = manv;
            this.ngaylap = ngaylap;
            this.noidung = noidung;
            this.httt = httt;
            this.soban = soban;
            this.tinhtranghd = tinhtranghd;
            this.vat = vat;
            this.tiensauthue = tiensauthue;
            this.tiennhankh = tiennhankh;
            this.tientralaikh = tientralaikh;
        }
        public HoaDon(
            DataRow row)
        {
            this.mahd = row["MAHD"].ToString();
            this.makh = row["MAKH"].ToString();
            this.manv = row["MANV"].ToString();
            this.ngaylap =Convert.ToDateTime( row["NGAYLAP"]);
            this.noidung = row["NOIDUNG"].ToString();
            this.httt = row["HTTT"].ToString();
            this.soban = row["SOBAN"].ToString();
            this.tinhtranghd = row["TINHTRANGHD"].ToString();
            this.vat =Convert.ToInt16( row["VAT"]);
            this.tiensauthue = Convert.ToInt16(row["TIENSAUTHUE"]);
            this.tiennhankh = Convert.ToInt16(row["TIENNHANKH"]);
            this.tientralaikh = Convert.ToInt16(row["TIENTRALAIKH"]);
        }
        public HoaDon()
        {

        }
        public string Mahd { get => mahd; set => mahd = value; }
        public string Makh { get => makh; set => makh = value; }
        public string Manv { get => manv; set => manv = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public string Noidung { get => noidung; set => noidung = value; }
        public string Httt { get => httt; set => httt = value; }
        public string Soban { get => soban; set => soban = value; }
        public string Tinhtranghd { get => tinhtranghd; set => tinhtranghd = value; }
        public float Vat { get => vat; set => vat = value; }
        public int Tiensauthue { get => tiensauthue; set => tiensauthue = value; }
        public int Tiennhankh { get => tiennhankh; set => tiennhankh = value; }
        public int Tientralaikh { get => tientralaikh; set => tientralaikh = value; }

        #region Methods
        public List<HoaDon> getListHoaDon ()
        {
            List<HoaDon> list = new List<HoaDon>();
            String query = "select * from hoadon";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                list.Add(new HoaDon(row));
            }
            return list;
        }
        public DataTable GetTableHoaDon ()
        {
            String query = "select * from hoadon";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            return table;
        }
        public HoaDon getHoaDonWithId (String mahoadon)
        {
            String query = "select * from hoadon where mahd='" +mahoadon+
                "'";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            HoaDon hoaDon = new HoaDon(table.Rows[0]);
            return hoaDon;
        }
        public String taoMaHoaDon ()
        {
            int count = (int)ConnectDataBase.SessionConnect.executeScalar("SELECT COUNT(*) FROM hoadon") + 1;
            return "HD" + Convert.ToString(count);
        }
        public int taoHoaDon ( HoaDon hd)
        {

            int result = 0;
            string query = "thaotachoadon @MAHD @MAKH @MANV @NGAYLAP @NOIDUNG @HTTT @SOBAN @TINHTRANGHD @VAT @TIENSAUTHUE @TIENNHANKH @TIENTRALAIKH @request";
            result = ConnectDataBase.SessionConnect.executeNonQuery(query,
                new object[] {
                    hd.Mahd,
                    hd.Makh,
                    hd.Manv,
                    hd.Ngaylap,
                    hd.Noidung,
                    hd.Httt,
                    hd.Soban,
                    hd.Tinhtranghd,
                    hd.Vat,
                    hd.Tiensauthue,
                    hd.Tiennhankh,
                    hd.Tientralaikh,
                    "insert" });
            return result;
        }
        public int capNhatHoaDon ()
        {
            int result = 0;
            string query = "thaotachoadon @MAHD @MAKH @MANV @NGAYLAP @NOIDUNG @HTTT @SOBAN @TINHTRANGHD @VAT @TIENSAUTHUE @TIENNHANKH @TIENTRALAIKH @request";
            result = ConnectDataBase.SessionConnect.executeNonQuery(query,
                new object[] {
                    this.Mahd,
                    this.Makh,
                    this.Manv,
                    this.Ngaylap,
                    this.Noidung,
                    this.Httt,
                    this.Soban,
                    this.Tinhtranghd,
                    this.Vat,
                    this.Tiensauthue,
                    this.Tiennhankh,
                    this.Tientralaikh,
                    "update" });
            return result;
        }
        #endregion
    }
}
